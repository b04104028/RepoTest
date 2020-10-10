using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public string ProblemTypeString { get; set; }
    public string BuildingNameString { get; set; }
    public string FloorString { get; set; }
    public string LocationString { get; set; }

    [SerializeField] InputField input_Location;
    [SerializeField] InputField input_BuildingName;
    [SerializeField] InputField input_Floor;
    [SerializeField] InputField input_ProblemType;

    public void ShowData()
    {
        input_Location.text = LocationString;
        input_ProblemType.text = ProblemTypeString;
        input_Floor.text = FloorString;
        input_BuildingName.text = BuildingNameString;
    }











    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
