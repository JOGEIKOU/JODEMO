using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISceneLogonCtrl : UISceneBase
{
    protected override void Onstart()
    {
        base.Onstart();

        
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.O))
        {
            GameObject obj = WindowUIMgr.Instance.OpenWindow(WindowUIType.LogOn);
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            WindowUIMgr.Instance.CloseWindow(WindowUIType.LogOn);
        }
    }
}
