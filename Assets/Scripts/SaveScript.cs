using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[RequireComponent(typeof(Data))]
public class SaveScript : MonoBehaviour
{

    private Data data;
    private string savePath;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<Data>();
        savePath = Application.persistentDataPath + "/savedata.save";
    }

    public void SaveData()
    {
        var save = new Save()
        {
            SavedProblemType = data.ProblemTypeString,
            SavedBuildingName = data.BuildingNameString,
            SavedFloor = data.FloorString,
            SavedLocation = data.LocationString
        };

        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))//using syntex: just like those 'using' on the top to import what you need. Here 'using' can be seen as "only use these items in the following range"
        {
            binaryFormatter.Serialize(fileStream, save);
        }

        Debug.Log("Data Saved.");
    }
    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            Save save;

            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }
            data.ProblemTypeString = save.SavedProblemType;
            data.BuildingNameString = save.SavedBuildingName;
            data.FloorString = save.SavedFloor;
            data.LocationString = save.SavedLocation;
            data.ShowData();

            Debug.Log("data loaded");
        }
        else
        {
            Debug.LogWarning("save file doesn't exist.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
