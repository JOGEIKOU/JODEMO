using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRegCtrl : UIWindowBase
{
    /// <summary>
    /// BaseUIからオーバーライドBtnClick
    /// </summary>
    /// <param name="go"></param>
    protected override void OnBtnClick(GameObject go)
    {
        switch (go.name)
        {
            case "btnReg":

                break;
            case "btnToLogOn":
                BtnToLogOn();
                break;
            default:
                break;
        }
    }

    private void BtnToLogOn()
    {
        WindowUIMgr.Instance.CloseWindow(WindowUIType.Reg);
        m_NextOpenWindow = WindowUIType.LogOn;
    }

    protected override void BeforeOnDestroy()
    {
        if(m_NextOpenWindow == WindowUIType.LogOn)
        {
            WindowUIMgr.Instance.OpenWindow(WindowUIType.LogOn);
        }
    }
}
