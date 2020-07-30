using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ウィンドウズUIマネージャ
/// </summary>
public class WindowUIMgr : Singleton<WindowUIMgr>
{
    #region ウインドUIのタイプ

    /// <summary>
    /// シーンUIタイプ
    /// </summary>
    public enum WinUIType
    {
        LogOn,
        Reg,
    }

    #endregion

    #region ウインドUIコンテナタイプ

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

    #endregion

    #region ウィンドウズUIの出るスタイル
    public enum WindowShowStyle
    {
        Normal,
        CenterToBig,
        FromTop,
        FromDown,
        FromLeft,
        FromRight
    }
    #endregion

    #region LoadWindowUI
    public GameObject LoadWindow(WinUIType type, WindowUIContainerType containerType = WindowUIContainerType.Center, WindowShowStyle showStyle = WindowShowStyle.Normal)
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
                transParent = SceneUIMgr.Instance.CurrentUIScene.Container_Center;
                break;
            default:
                break;
        }

        obj.transform.parent = transParent;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localScale = Vector3.one;
        NGUITools.SetActive(obj, false);
        StartShowWindow(obj, showStyle, true);
        return obj;
    }
    #endregion

    private void StartShowWindow(GameObject obj, WindowShowStyle showStyle,bool isOpen)
    {
        switch (showStyle)
        {
            case WindowShowStyle.Normal:
                ShowNormal(obj,isOpen);
                break;
            case WindowShowStyle.CenterToBig:
                ShowCenterToBig(obj, isOpen);
                break;
            case WindowShowStyle.FromTop:
                break;
            case WindowShowStyle.FromDown:
                break;
            case WindowShowStyle.FromLeft:
                break;
            case WindowShowStyle.FromRight:
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// ウィンドウズUI潰す
    /// </summary>
    /// <param name="obj"></param>
    public void DestroyWindow(GameObject obj)
    {
        GameObject.Destroy(obj);
    }


    #region UI演出エフェクト
    /// <summary>
    /// 正常的に
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="isOpen"></param>
    private void ShowNormal(GameObject obj,bool isOpen)
    {
        if(isOpen)
        {
            NGUITools.SetActive(obj, true);
        }
        else
        {
            DestroyWindow(obj);
        }
    }

    /// <summary>
    /// 真ん中から拡大に
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="isOpen"></param>
    private void ShowCenterToBig(GameObject obj,bool isOpen)
    {
        TweenScale ts = obj.GetComponent<TweenScale>();
        if(ts == null)
        {
            ts = obj.AddComponent<TweenScale>();
        }
        ts.from = Vector3.zero;
        ts.to = Vector3.one;
        ts.duration = 5f;//経過時間
        ts.SetOnFinished(() =>
        {
            if (!isOpen)
                DestroyWindow(obj);
        }
        );
        NGUITools.SetActive(obj, true);
        if (!isOpen) ts.Play(isOpen);
    }







    #endregion
}