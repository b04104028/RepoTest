using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    [SerializeField] Camera[] m_Cameras = new Camera[2];
    // Start is called before the first frame update
    void Start()
    {
        foreach(Camera c in m_Cameras)
        {
            c.GetComponent<AudioListener>().enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
