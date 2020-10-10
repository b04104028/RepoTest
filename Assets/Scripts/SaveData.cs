using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public InputField InputText;
    string text;

    // Start is called before the first frame update
    void Start()
    {
        text = PlayerPrefs.GetString("tutorialTextKeyName");
        InputText.text = text;
    }
    public void SaveThis()
    {
        text = InputText.text;
        PlayerPrefs.SetString("tutorialTextKeyName", text);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
