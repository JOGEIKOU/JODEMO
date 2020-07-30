using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISceneLogonCtrl : UISceneBase<UISceneLogonCtrl>
{
    protected override void OnAwake()
    {
        base.OnAwake();

        GameObject obj = WindowUIMgr.Instance.LoadWindow(WindowUIMgr.WinUIType.LogOn);
    }

    void Start()
    {
        
    }
}
