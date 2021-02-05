//
//  登录场景UI
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISceneLogOnView : UISceneViewBase
{
    protected override void Onstart()
    {
        base.Onstart();
        StartCoroutine("OpenLogOnWindow");
    }

    private IEnumerator OpenLogOnWindow()
    {
        yield return new WaitForSeconds(0.2f);
        AccountCtrl.Instance.OpenLogOnView();
    }
}
