using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogOnCtrl : MonoBehaviour
{



    private void Awake()
    {
        UIButton[] btnArr = GetComponentsInChildren<UIButton>(true);
        for (int i = 0; i < btnArr.Length; i++)
        {
            UIEventListener.Get(btnArr[i].gameObject).onClick = BtnClick;
        }
    }

    private void BtnClick(GameObject go)
    {
        switch(go.name)
        {
            case "btnStart":

                break;
            case "btnToReg":
                BtnToReg();
                break;
            default:
                break;
        }
    }


    private void BtnToReg()
    {
        Destroy(gameObject);
        GameObject obj = WindowUIMgr.Instance.LoadWindow(WindowUIMgr.WinUIType.Reg);
    }





}
