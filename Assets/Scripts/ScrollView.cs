using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;


public class ScrollView : MonoBehaviour
{
    LoadScene SceneLoader = new LoadScene(); //Remember this syntex!! "new LoadScene()" to create virtual element and use that script's functions
    
    List<string> ProblemType = new List<string>();
    List<string> BuildingName = new List<string>();
    [SerializeField] GameObject parentScroll;
    [SerializeField] GameObject prefabButton;

    [SerializeField] GameObject Input_BuildingName;
    [SerializeField] GameObject Input_Floor;
    [SerializeField] GameObject Input_Location;

    public string record_ProblemType = "";
    public string record_BuildingName = "";
    public string record_Floor = "";
    public string record_Location = "";



    //these are to save the buttons in previous pages so that you can go back to "last page" 
    List<PrefabBehavior> button = new List<PrefabBehavior>();
    List<int> button_count = new List<int>();

    private int question_count = 0;
    private List<string> question_field = new List<string> { "input-ProblemType", "input-BuildingName" , "input-Floor","input-Location" };

    private Building AllBuildings = new Building();
    // private Building building2 = new Building();      

    string ChosenBuilding = "";

    #region Method1ToCreateButton
    //Works like a charm but i don't know how to set the button's properties.
    //set the parent gameobject as the content of the scroll view, then the button will appear in the scrollview. 
    /* [SerializeField] GameObject ParentScroll;
     void Awake()
     {
         DefaultControls.Resources uiResources = new DefaultControls.Resources();
         GameObject uiButton = DefaultControls.CreateButton(uiResources);
         uiButton.transform.SetParent(ParentScroll.transform, false);
     }*/
    #endregion

    #region Method2ToCreateButton
    //below method of instantiate a ui prefab works like a charm. 
    //thanks to this step-by-step tutorial: 
    //https://gamedev.stackexchange.com/questions/103718/what-are-the-steps-to-instantiate-a-button-in-unity

    /*
     * [SerializeField] GameObject parentCanvas;
    [SerializeField] GameObject buttonPrefabtest;
     * void Awake()
    {
         GameObject uiButton = Instantiate(buttonPrefabtest) as GameObject;
        uiButton.transform.SetParent(parentCanvas.transform, false);
        uiButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -70f);
    }
    */
    #endregion

    void Awake()
    {
        ProblemType.Add("Archi");
        ProblemType.Add("Mech");
        ProblemType.Add("HVAC");
        ProblemType.Add("Monitor");
        ProblemType.Add("Fire");
        ProblemType.Add("Info");
        CreateButton(ProblemType);

        BuildingName.Add("building1");
        BuildingName.Add("building2");

        //building1.FloorNumber = 2;
        //building2.FloorNumber = 3;

        /*
building1.BuildingDetail["1F"] = new Dictionary<int, string>();
building1.BuildingDetail["2F"] = new Dictionary<int, string>();

building2.BuildingDetail["1F"] = new Dictionary<int, string>();
building2.BuildingDetail["2F"] = new Dictionary<int, string>();
building2.BuildingDetail["3F"] = new Dictionary<int, string>();

building1.BuildingDetail["1F"][1] = "bathroom";
building1.BuildingDetail["1F"][2] = "office";
building1.BuildingDetail["1F"][3] = "lounge";

building1.BuildingDetail["2F"][1] = "bathroom";
building1.BuildingDetail["2F"][2] = "office";

building2.BuildingDetail["1F"][1] = "bathroom";
building2.BuildingDetail["1F"][2] = "office";
building2.BuildingDetail["1F"][3] = "lounge";

building2.BuildingDetail["2F"][1] = "bathroom";
building2.BuildingDetail["2F"][2] = "office";

building2.BuildingDetail["3F"][1] = "TopFloor";
*/

        AllBuildings.BuildingDetail["building1"] = new Dictionary<string, List<string>>();
        AllBuildings.BuildingDetail["building2"] = new Dictionary<string, List<string>>();

        (AllBuildings.BuildingDetail["building1"])["1F"] = new List<string>() { "bathroom", "office", "lounge" };
        (AllBuildings.BuildingDetail["building1"])["2F"] = new List<string>() { "meeting room", "kitchen" };


    }

    void Update()
    {
        record_BuildingName = GameObject.Find("input-ProblemType").GetComponentInChildren<InputField>().text;
    }
    public void ChangeContent()
    {
        GameObject InputFieldContent = GameObject.Find(question_field[question_count] );
        string CheckInputTextFilled = InputFieldContent.GetComponentInChildren<InputField>().text;

        if(CheckInputTextFilled != "")
        {
            foreach (PrefabBehavior item in button)
            {
                item.gameObject.SetActive(false);
            }
            question_count++;
            if (question_count == 1)//only the first change page need to show the building
            {
                CreateButton(BuildingName);
            }
            else if(question_count == 2)
            {
                //Debug.Log("it's the second time");
                //Debug.Log(trim);
                ChosenBuilding = CheckInputTextFilled.Replace(" ", "");
                CreatePage_BuildingFloor(ChosenBuilding);
                //  GameObject Input_ProblemTypeText = GameObject.Find(question_field[question_count]);
                // CreateButton_BuildingInfo(buildingname);
            }
            else if(question_count == 3)
            {
                //Debug.Log("it's the third time");
                CreateButton(AllBuildings.BuildingDetail[ChosenBuilding][CheckInputTextFilled.Replace(" ", "")]);
               //CreatePage_FloorLocation(ChosenBuilding, CheckInputTextFilled.Replace(" ",""));
            }else if (question_count == 4)
            {
                SceneLoader.SceneLoader(1);
            }
        }
        else
        {
            Debug.Log("You Need to Choose an Item.");
        }
       
    }

   // void CreateButton_BuildingInfo(Dictionary<string, Dictionary<int, string>> FloorDetail)
   // {}

    public void ClearContent()
    {
        foreach(string name in question_field)
        {
            GameObject InputText = GameObject.Find(name);
            InputText.GetComponentInChildren<InputField>().text = ("");
           //InputText.GetComponentInChildren<InputField>().GetComponentInChildren<Text>().text = name.Replace("input-", "");

        }
        CreateButton(ProblemType);
        question_count = 0;
    }

   // public void CreatePage_FloorLocation(string buildingName_DictKey, string Floor_DictKey)
   // {
    //   CreateButton()
     //   foreach (string location in AllBuildings.BuildingDetail[buildingName_DictKey][Floor_DictKey])
     //   {
     //       Debug.Log(location);
    //    }
   // }
    public void CreatePage_BuildingFloor(string buildingName_DictKey)
    {
        List<string> FloorsOfThisBuilding = new List<string>();
        foreach (KeyValuePair<string, List<string>> floors in AllBuildings.BuildingDetail[buildingName_DictKey])
        {
            FloorsOfThisBuilding.Add(floors.Key);
            //Debug.Log(floors.Key);
            // CreateButton();
            //GameObject Input_ProblemTypeText = GameObject.Find(the selected building);
            //then find the building floor number

            // foreach (KeyValuePair<int, string> location in floor.thisfloor's location)
            // {

            //  }
        }
        CreateButton(FloorsOfThisBuilding);
    }
    public void CreateButton(List<string> ButtonContent)
    {
        for (int i = 0; i < ButtonContent.Count; i++)
        {
            //ScrollView.cs //Method2ToCreateButton
            var uiButton = Instantiate(Resources.Load<PrefabBehavior>("Prefab/btn-02mech"));
            uiButton.transform.SetParent(parentScroll.transform, false);
            uiButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -70f * i);
            uiButton.GetComponentInChildren<Text>().text = "   "+ButtonContent[i];
            uiButton.FillInputField += OnFillInputField;
            button.Add(uiButton);            
        }
        button_count.Add(ButtonContent.Count);  
    }

    void OnFillInputField(PrefabBehavior pref)
    {
        GameObject inputGameObject = GameObject.Find(question_field[question_count]);        
        inputGameObject.GetComponentInChildren<InputField> ().text = pref.GetComponentInChildren<Text>().text;
        //PlayerPrefs.SetString("ProblemType", question_field[question_count]);
        //Input_ProblemTypeText.transform.GetChild(2).GetComponent<Text>().text = pref.GetComponentInChildren<Text>().text;
    }


}
