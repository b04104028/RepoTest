using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class FailureReportScript : MonoBehaviour
{
    [SerializeField] InputField input_QRcode;
    [SerializeField] InputField input_ProblemType;
    [SerializeField] InputField input_BuildingName;
    [SerializeField] InputField input_Floor;
    [SerializeField] InputField input_OfficeName;
    [SerializeField] InputField input_Description;

    private string qrcode;
    private string problemtype;
    private string buildingname;
    private string floor;
    private string officename;
    private string description;
    // Start is called before he first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShowData();
        AssignInput();
    }
    public void testshow()
    {
        Debug.Log("testshow");
    }

    void ShowData()
    {
        input_ProblemType.GetComponentInChildren<InputField>().text = Data.ProblemTypeString;
        input_BuildingName.GetComponentInChildren<InputField>().text = Data.BuildingNameString;
        input_Floor.GetComponentInChildren<InputField>().text = Data.FloorString;
        input_OfficeName.GetComponentInChildren<InputField>().text = Data.LocationString;
    }

    void AssignInput()
    {
        qrcode = input_QRcode.GetComponentInChildren<InputField>().text;
        problemtype = input_BuildingName.GetComponentInChildren<InputField>().text;
        buildingname = input_BuildingName.GetComponentInChildren<InputField>().text;
        floor = input_Floor.GetComponentInChildren<InputField>().text;
        officename = input_OfficeName.GetComponentInChildren<InputField>().text;
        description = input_Description.GetComponentInChildren<InputField>().text;
    }

   public void WriteDB()
    {
        Debug.Log("writedb");
        string conn = "URI=file:" + Application.dataPath + "/FailureReportDB"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO FailureReport VALUES(' " + qrcode + " ', ' " +problemtype  + " ', ' " + buildingname + " ', ' " + floor + " ', ' " + officename + " ', ' " + description + " ')";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

        Debug.Log("FailureReport is saved!");
    }



}
