using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PrefabBehavior : MonoBehaviour, IPointerUpHandler
{
    //Failed //how to assign this ScrollView to a specific gameobject??
    //ScrollView parentScroll;
    //Failed // [SerializeField] GameObject inputField;
    //public GameObject inputField = GameObject.Find("input-ProblemType");

    //public void PointerUp(PointerEventData eventData)
    //{

    //    //Failed   //inputField.GetComponentInChildren<Text>().text = "hellooooo";
    //   //Failed  //parentScroll.UpdateInput();
    //}
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("Pointer is Up");
        FillInputField(this);
    }

    public delegate void EntityEvent(PrefabBehavior e);
    public event EntityEvent FillInputField = (e) => { };
}
