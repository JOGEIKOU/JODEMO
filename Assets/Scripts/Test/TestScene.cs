using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : MonoBehaviour
{
    void Start()
    {

        //int a = 10;
        //int b = a;
        //a = 20;
        //Debug.Log("a = " + a);
        //Debug.Log("b = " + b);


        //BoxEntity entity = new BoxEntity();
        //entity.BoxSize = 20;

        //BoxEntity entity2 = entity;
        //entity2.BoxSize = 30;

        //Debug.Log("entity.BoxSize = " + entity.BoxSize);


        //string の特徴：改められない
        //string a = "aaa";
        //string b = a;

        //b = "bbb";
        //Debug.Log("a = " + a);

    }

    void Update()
    {
        if(Input.GetMouseButtonUp(1))
        {
            int a = 10;
            Debug.Log(Mathf.Clamp(a,20,100));
        }
    }
}
