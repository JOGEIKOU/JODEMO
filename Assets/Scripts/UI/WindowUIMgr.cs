using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowUIMgr : Singleton<WindowUIMgr>
{
    /// <summary>
    /// シーンUIタイプ
    /// </summary>
    public enum WinUIType
    {
        LogOn,
        Reg,
    }

    public enum WindowUIContainerType
    {
        /// <summary>
        /// 左上
        /// </summary>
        TL,
        /// <summary>
        /// 右上
        /// </summary>
        TR,
        /// <summary>
        /// 左下
        /// </summary>
        BL,
        /// <summary>
        /// 右下
        /// </summary>
        BR,
        /// <summary>
        /// 真ん中
        /// </summary>
        Center
    }


    #region LoadWindowUI
    public GameObject LoadWindow(WinUIType type, WindowUIContainerType containerType = WindowUIContainerType.Center)
    {
        GameObject obj = null;

        switch (type)
        {
            case WinUIType.LogOn:
                obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIWindow, "panLogOn", cache: true);
                break;
            case WinUIType.Reg:
                obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIWindow, "panReg", cache: true);
                break;
            default:
                break;
        }

        Transform transParent = null;

        switch (containerType)
        {
            case WindowUIContainerType.TL:
                break;
            case WindowUIContainerType.TR:
                break;
            case WindowUIContainerType.BL:
                break;
            case WindowUIContainerType.BR:
                break;
            case WindowUIContainerType.Center:
                transParent = UISceneLogonCtrl.Instance.Container_Center;
                break;
            default:
                break;
        }

        obj.transform.parent = transParent;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localScale = Vector3.one;

        return obj;
    }
    #endregion
}
