using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailureReportScript : MonoBehaviour
{
    [SerializeField] InputField  input_ProblemType;
    [SerializeField] InputField input_BuildingName;
    [SerializeField] InputField input_Floor;
    [SerializeField] InputField input_OfficeName;

    // Start is called before he first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        input_ProblemType.GetComponentInChildren<InputField>().text = Data.ProblemTypeString;
        input_BuildingName.GetComponentInChildren<InputField>().text = Data.BuildingNameString;
        input_Floor.GetComponentInChildren<InputField>().text = Data.FloorString;
        input_OfficeName.GetComponentInChildren<InputField>().text = Data.LocationString;




    }
}
