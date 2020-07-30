using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーンUIマネージャー
/// </summary>
public class SceneUIMgr : Singleton<SceneUIMgr>
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


    #region LoadSceneUI
    public GameObject LoadSceneUI(SceneUIType type)
    {
        GameObject obj = null;

        switch (type)
        {
            case SceneUIType.LogOn:
                obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIScene, "UI Root_LogOnScene");
                break;
            case SceneUIType.Loading:
                break;
            case SceneUIType.MainCity:
                break;
            default:
                break;
        }
        return obj;
    }
    #endregion

}
