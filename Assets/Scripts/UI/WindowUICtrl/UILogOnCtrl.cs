using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogOnCtrl : UIWindowBase
{

    /// <summary>
    /// BaseUIからオーバーライドBtnClick
    /// </summary>
    /// <param name="go"></param>
    protected override void OnBtnClick(GameObject go)
    {
        switch (go.name)
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
        GameObject obj = WindowUIMgr.Instance.OpenWindow(WindowUIType.Reg);
    }


}
