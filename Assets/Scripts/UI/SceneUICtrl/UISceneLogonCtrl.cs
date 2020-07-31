using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISceneLogonCtrl : UISceneBase
{
    protected override void Onstart()
    {
        base.Onstart();
        StartCoroutine("OpenLogOnWindow");
    }

    private IEnumerator OpenLogOnWindow()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject obj = WindowUIMgr.Instance.OpenWindow(WindowUIType.LogOn);
    }

}
