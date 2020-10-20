using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

#region Error need to be fixed.
//20201019.This is the error message now I encounter. Couldn't solve it for days. Need try to fix it!!!!
/*
 SqliteException: SQLite error
no such table: FailureReport
Mono.Data.Sqlite.SQLite3.Prepare (Mono.Data.Sqlite.SqliteConnection cnn, System.String strSql, Mono.Data.Sqlite.SqliteStatement previous, System.UInt32 timeoutMS, System.String& strRemain) (at <19353db254a740fe959894498d1d3fd1>:0)
Mono.Data.Sqlite.SqliteCommand.BuildNextCommand () (at <19353db254a740fe959894498d1d3fd1>:0)
Mono.Data.Sqlite.SqliteCommand.GetStatement (System.Int32 index) (at <19353db254a740fe959894498d1d3fd1>:0)
(wrapper remoting-invoke-with-check) Mono.Data.Sqlite.SqliteCommand.GetStatement(int)
Mono.Data.Sqlite.SqliteDataReader.NextResult () (at <19353db254a740fe959894498d1d3fd1>:0)
(wrapper remoting-invoke-with-check) Mono.Data.Sqlite.SqliteDataReader.NextResult()
Mono.Data.Sqlite.SqliteDataReader..ctor (Mono.Data.Sqlite.SqliteCommand cmd, System.Data.CommandBehavior behave) (at <19353db254a740fe959894498d1d3fd1>:0)
(wrapper remoting-invoke-with-check) Mono.Data.Sqlite.SqliteDataReader..ctor(Mono.Data.Sqlite.SqliteCommand,System.Data.CommandBehavior)
Mono.Data.Sqlite.SqliteCommand.ExecuteReader (System.Data.CommandBehavior behavior) (at <19353db254a740fe959894498d1d3fd1>:0)
Mono.Data.Sqlite.SqliteCommand.ExecuteDbDataReader (System.Data.CommandBehavior behavior) (at <19353db254a740fe959894498d1d3fd1>:0)
System.Data.Common.DbCommand.System.Data.IDbCommand.ExecuteReader () (at <42e541e8c16f40a0bb07f790a66ccf3c>:0)
FailureReportScript.ReadDB () (at Assets/Scripts/FailureReportScript.cs:92)
FailureReportScript.testshow () (at Assets/Scripts/FailureReportScript.cs:39)
UnityEngine.Events.InvokableCall.Invoke () (at C:/buildslave/unity/build/Runtime/Export/UnityEvent.cs:166)
UnityEngine.Events.UnityEvent.Invoke () (at C:/buildslave/unity/build/Runtime/Export/UnityEvent_0.cs:58)
UnityEngine.UI.Button.Press () (at C:/buildslave/unity/build/Extensions/guisystem/UnityEngine.UI/UI/Core/Button.cs:66)
UnityEngine.UI.Button.OnPointerClick (UnityEngine.EventSystems.PointerEventData eventData) (at C:/buildslave/unity/build/Extensions/guisystem/UnityEngine.UI/UI/Core/Button.cs:108)
UnityEngine.EventSystems.ExecuteEvents.Execute (UnityEngine.EventSystems.IPointerClickHandler handler, UnityEngine.EventSystems.BaseEventData eventData) (at C:/buildslave/unity/build/Extensions/guisystem/UnityEngine.UI/EventSystem/ExecuteEvents.cs:50)
UnityEngine.EventSystems.ExecuteEvents.Execute[T] (UnityEngine.GameObject target, UnityEngine.EventSystems.BaseEventData eventData, UnityEngine.EventSystems.ExecuteEvents+EventFunction`1[T1] functor) (at C:/buildslave/unity/build/Extensions/guisystem/UnityEngine.UI/EventSystem/ExecuteEvents.cs:261)
UnityEngine.EventSystems.EventSystem:Update() (at C:/buildslave/unity/build/Extensions/guisystem/UnityEngine.UI/EventSystem/EventSystem.cs:377)
   
     
     */
#endregion

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
    // Start is called before the first frame update
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
        Debug.Log("tstshow");
        testReadDB();
        //ReadDB();
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
        string conn = "URI=file:" + Application.dataPath + "/TestDB"; //Path to database.

        Debug.Log("writedb");//ERROR!!
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO FailureReport VALUES(' " + qrcode + " ', ' " + problemtype + " ')";//, ' " + buildingname + " ', ' " + floor + " ', ' " + officename + " ', ' " + description + " ')";
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

    void ReadDB()
    {
        //Debug.Log("ReadDB");
        string conn = "URI = file:" + Application.dataPath + "/TestDB"; //Path to database.
        
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        
        IDbCommand dbcmd = dbconn.CreateCommand();
        
        string sqlQuery = "SELECT * FROM TestTable";
        
        dbcmd.CommandText = sqlQuery;
       
        IDataReader reader = dbcmd.ExecuteReader();

        if (reader.Read())
        {
            Debug.Log("reader.Read ok");//OK
        }
        if (reader.IsDBNull(0))
        { //Check for a null value at the 0 index
            Debug.Log("reader is null");
        }
        else
        {
            Debug.Log(reader.GetString(0));
        }

        while (reader.Read())
        {
            string DBQRcode = reader.GetString(0);
            
            //string DBProblemType = reader.GetString(1);
            //string DBBuildingName = reader.GetString(2);
            //string DBFloor = reader.GetString(3);
            //string DBOfficeName = reader.GetString(4);
            //string DBDescription = reader.GetString(5);

  
            Debug.Log("QRcode: " + DBQRcode );//+ "  " + DBProblemType + "  " + DBBuildingName + "   " + DBFloor + "   " + DBOfficeName + "   " + description);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }


    void testReadDB()
    {
            string conn = "URI=file:" + Application.dataPath + "/TestDB"; //Path to database.
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT qrcode, ProblemType " + "FROM FailureReport";
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                string qrcode = reader.GetString(0);
                string problemtype = reader.GetString(1);

            Debug.Log("qrcode: " + qrcode + ",   problemtype: " + problemtype);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;


        
    }
}
