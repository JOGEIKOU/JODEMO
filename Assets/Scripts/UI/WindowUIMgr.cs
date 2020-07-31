using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ウィンドウズUIマネージャ
/// </summary>
public class WindowUIMgr : Singleton<WindowUIMgr>
{

    private Dictionary<WindowUIType, UIWindowBase> m_DicWindow = new Dictionary<WindowUIType, UIWindowBase>();

    #region OpenWindowUI

    /// <summary>
    /// open window
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public GameObject OpenWindow(WindowUIType type)
    {
        if (m_DicWindow.ContainsKey(type)) return null;

        GameObject obj = null;

        //enumの名前とプレハブの名前必ず同じ
        obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIWindow, string.Format("pan{0}",type.ToString()), cache: true);

        UIWindowBase windowBase = obj.GetComponent<UIWindowBase>();
        m_DicWindow.Add(type, windowBase);
        windowBase.CurrentUIType = type;

        Transform transParent = null;

        switch (windowBase.containerType)
        {
            case WindowUIContainerType.TopLeft:
                break;
            case WindowUIContainerType.TopRight:
                break;
            case WindowUIContainerType.BottomLeft:
                break;
            case WindowUIContainerType.BottomRight:
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
        StartShowWindow(windowBase, true);
        return obj;
    }
    #endregion


    #region ウィンドウズUI閉じる
    /// <summary>
    /// close window
    /// </summary>
    /// <param name="type"></param>
    public void CloseWindow(WindowUIType type)
    {
        if(m_DicWindow.ContainsKey(type))
        {
            StartShowWindow(m_DicWindow[type], false);
        }
    }
    #endregion

    /// <summary>
    /// start open window
    /// </summary>
    /// <param name="windowBase"></param>
    /// <param name="isOpen"></param>
    private void StartShowWindow(UIWindowBase windowBase,bool isOpen)
    {
        switch (windowBase.showStyle)
        {
            case WindowShowStyle.Normal:
                ShowNormal(windowBase, isOpen);
                break;
            case WindowShowStyle.CenterToBig:
                ShowCenterToBig(windowBase, isOpen);
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

    #region UI演出エフェクト
    /// <summary>
    /// 正常的に
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="isOpen"></param>
    private void ShowNormal(UIWindowBase windowBase,bool isOpen)
    {
        if(isOpen)
        {
            NGUITools.SetActive(windowBase.gameObject, true);
        }
        else
        {
            DestroyWindow(windowBase);
        }
    }

    /// <summary>
    /// 真ん中から拡大に
    /// </summary>
    /// <param name="isOpen"></param>
    private void ShowCenterToBig(UIWindowBase windowBase, bool isOpen)
    {
        TweenScale ts = windowBase.gameObject.GetOrCreatComponent<TweenScale>();
        ts.animationCurve = GlobalInit.Instance.UIAnimationCurve;
        ts.from = Vector3.zero;
        ts.to = Vector3.one;
        ts.duration = windowBase.duration;//経過時間
        ts.SetOnFinished(() =>
        {
            if (!isOpen)
                DestroyWindow(windowBase);
        }
        );
        NGUITools.SetActive(windowBase.gameObject, true);
        if (!isOpen) ts.Play(isOpen);
    }


    #endregion

    /// <summary>
    /// ウィンドウズUI潰す
    /// </summary>
    /// <param name="obj"></param>
    public void DestroyWindow(UIWindowBase windowBase)
    {
        Object.Destroy(windowBase.gameObject);
        m_DicWindow.Remove(windowBase.CurrentUIType);
    }
}