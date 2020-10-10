using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 Reference website:
 1. RectTransform: http://blog.fourdesire.com/2018/07/03/%E6%88%90%E7%82%BA-ugui-%E7%9A%84%E6%8E%92%E7%89%88%E5%A4%A7%E5%B8%AB-%E4%B8%80%E6%AC%A1%E7%B2%BE%E9%80%9A-recttransform/

     */
public class UISetting : MonoBehaviour
{
    public RectTransform rectTransform;
    //ref: how to reach a panel in unity ui: https://answers.unity.com/questions/838387/unity-46-ui-accessing-a-panel-from-a-script.html


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, top);
        //rectTransform.anchorMin = new Vector2(0.5f, 1f); //Not working
        //rectTransform.anchorMax = new Vector2(0.5f, 0.5f); //Not working


    }
}
