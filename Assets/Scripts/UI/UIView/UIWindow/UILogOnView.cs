using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogOnView : UIWindowViewBase
{

    protected override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        switch (go.name)
        {
            case "Btn_Logon":
                EventDispatcher.Instance.DispatchBtn("UILogOnView_Btn_Logon");
                break;
            case "Btn_ToRegister":
                EventDispatcher.Instance.DispatchBtn("UILogOnView_Btn_ToRegister");
                break;
            default:
                break;
        }
    }


}

