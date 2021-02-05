using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーンUIマネージャー
/// </summary>
public class UISceneCtrl : Singleton<UISceneCtrl>
{
    /// <summary>
    /// シーンUIタイプ
    /// </summary>
    public enum SceneUIType
    {
        LogOn,
        Loading,
        MainCity
    }

    /// <summary>
    /// 今のシーンUI
    /// </summary>
    public UISceneViewBase CurrentUIScene;

    #region LoadSceneUI
    public GameObject LoadSceneUI(SceneUIType type)
    {
        GameObject obj = null;

        switch (type)
        {
            case SceneUIType.LogOn:
                obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIScene, "UI_Root_Logon");
                CurrentUIScene = obj.GetComponent<UISceneViewBase>();
                break;
            case SceneUIType.Loading:
                break;
            case SceneUIType.MainCity:
                obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIScene, "UI Root_City");
                CurrentUIScene = obj.GetComponent<UISceneViewBase>();
                break;
            default:
                break;
        }
        return obj;
    }
    #endregion

}
