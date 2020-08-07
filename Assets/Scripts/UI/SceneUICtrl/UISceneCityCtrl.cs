using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CityScene UI control
/// </summary>
public class UISceneCityCtrl : UISceneBase
{
    protected override void OnBtnClick(GameObject go)
    {
        switch(go.name)
        {
            case "btnHead":
                OpenRoleInfo();
                break;
        }
    }

    private void OpenRoleInfo()
    {
        WindowUIMgr.Instance.OpenWindow(WindowUIType.RoleInfo);
    }
}
