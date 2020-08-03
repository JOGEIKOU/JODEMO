using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ウィンドウズUIマネージャ
/// </summary>
public class WindowUIMgr : Singleton<WindowUIMgr>
{

    private Dictionary<WindowUIType, UIWindowBase> m_DicWindow = new Dictionary<WindowUIType, UIWindowBase>();

    /// <summary>
    /// 開けているウィンドウズの数
    /// </summary>
    public int OpenWindowCount
    {
        get => m_DicWindow.Count;
    }

    #region OpenWindowUI

    /// <summary>
    /// open window
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public GameObject OpenWindow(WindowUIType type)
    {
        if (type == WindowUIType.None) return null;

        GameObject obj = null;

        //もしウィンドウズ不存在
        if (!m_DicWindow.ContainsKey(type))
        {
            //enumの名前とプレハブの名前必ず同じ
            obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIWindow, string.Format("pan{0}", type.ToString()), cache: true);
            if (obj == null) return null;
            UIWindowBase windowBase = obj.GetComponent<UIWindowBase>();
            if (windowBase == null) return null;
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
        }
        else
        {
            obj = m_DicWindow[type].gameObject;
        }
     
        //layout 管理
        LayerUIMgr.Instance.SetLayer(obj);

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
                ShowFromDir(windowBase, 0,isOpen);
                break;
            case WindowShowStyle.FromDown:
                ShowFromDir(windowBase, 1, isOpen);
                break;
            case WindowShowStyle.FromLeft:
                ShowFromDir(windowBase, 2, isOpen);
                break;
            case WindowShowStyle.FromRight:
                ShowFromDir(windowBase, 3, isOpen);
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

    /// <summary>
    /// 上下左右からロード
    /// </summary>
    /// <param name="windowBase"></param>
    /// <param name="dirType">0 = 上から下へ, 1 = 下から上に, 2 = 左から右に, 3 = 右から左に</param>
    /// <param name="isOpen"></param>
    private void ShowFromDir(UIWindowBase windowBase,int dirType,bool isOpen)
    {
        TweenPosition tp = windowBase.gameObject.GetOrCreatComponent<TweenPosition>();
        tp.animationCurve = GlobalInit.Instance.UIAnimationCurve;

        Vector3 from = Vector3.zero;
        switch(dirType)
        {
            case 0:
                from = new Vector3(0, 1000, 0);
                break;
            case 1:
                from = new Vector3(0, -1000, 0);
                break;
            case 2:
                from = new Vector3(-1400, 0, 0);
                break;
            case 3:
                from = new Vector3(1400, 0, 0);
                break;
        }
        tp.from = from;
        tp.to = Vector3.one;
        tp.duration = windowBase.duration;//経過時間
        tp.SetOnFinished(() =>
        {
            if (!isOpen)
                DestroyWindow(windowBase);
        }
        );
        NGUITools.SetActive(windowBase.gameObject, true);
        if (!isOpen) tp.Play(isOpen);

    }

    #endregion

    /// <summary>
    /// ウィンドウズUI潰す
    /// </summary>
    /// <param name="obj"></param>
    public void DestroyWindow(UIWindowBase windowBase)
    {
        LayerUIMgr.Instance.CheckOpenWindow();
        m_DicWindow.Remove(windowBase.CurrentUIType);
        Object.Destroy(windowBase.gameObject);       
    }
}