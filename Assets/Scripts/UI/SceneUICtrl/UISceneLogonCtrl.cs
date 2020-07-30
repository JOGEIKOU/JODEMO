using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISceneLogonCtrl : UISceneBase
{
    protected override void Onstart()
    {
        base.Onstart();

        GameObject obj = WindowUIMgr.Instance.LoadWindow(WindowUIMgr.WinUIType.LogOn,showStyle:WindowUIMgr.WindowShowStyle.CenterToBig);
    }
}
