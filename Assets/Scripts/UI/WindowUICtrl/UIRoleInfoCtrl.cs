using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラクター情報UIコントローラー
/// </summary>
public class UIRoleInfoCtrl : UIWindowBase
{
    protected override void OnBtnClick(GameObject go)
    {
        switch(go.gameObject.name)
        {
            case "btnClose":
                Close();
                break;
        }
    }
}
