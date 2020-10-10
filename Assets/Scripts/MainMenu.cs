using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // Cam_FailureReport.GetComponent<AudioListener>().enabled = false;
    }
    public void LoadFailureReport()
    {
        Debug.Log("failurereport is clicked.");
       // SceneManager.LoadScene()
     //  Cam_FailureReport.enabled = true;
      //  Cam_Main.enabled = false;
        
    }
    public void UnsolvedEvents()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
