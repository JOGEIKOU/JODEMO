using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/// <summary>
/// ウィンドウズUIマネージャ
/// </summary>
public class WindowUIMgr : Singleton<WindowUIMgr>
{

    private Dictionary<WindowUIType, UIWindowViewBase> m_DicWindow = new Dictionary<WindowUIType, UIWindowViewBase>();

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
            obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIWindow, string.Format("pan_{0}", type.ToString()), cache: true);
            Debug.Log("得到注册窗口" + obj.name);
            if (obj == null) return null;
            UIWindowViewBase windowBase = obj.GetComponent<UIWindowViewBase>();
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
                    transParent = UISceneCtrl.Instance.CurrentUIScene.Container_Center;
                    break;
                default:
                    break;
            }

            obj.transform.parent = transParent;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            obj.gameObject.SetActive(false);
            StartShowWindow(windowBase, true);
        }
        else
        {
            obj = m_DicWindow[type].gameObject;
        }
     
        //layout 管理
        //LayerUIMgr.Instance.SetLayer(obj);

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
    private void StartShowWindow(UIWindowViewBase windowBase,bool isOpen)
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
    private void ShowNormal(UIWindowViewBase windowBase,bool isOpen)
    {
        if(isOpen)
        {
            windowBase.gameObject.SetActive(true);
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
    private void ShowCenterToBig(UIWindowViewBase windowBase, bool isOpen)
    {

        windowBase.gameObject.SetActive(true);
        windowBase.transform.localScale = Vector3.zero;
        windowBase.transform.DOScale(Vector3.one, windowBase.duration)
            .SetAutoKill(false)
            .SetEase(GlobalInit.Instance.UIAnimationCurve)
            .Pause().OnRewind(() =>
        {
                DestroyWindow(windowBase);
        });

        if(isOpen)
        {
            windowBase.transform.DOPlayForward();
        }
        else
        {
            windowBase.transform.DOPlayBackwards();
        }
    }

    /// <summary>
    /// 上下左右からロード
    /// </summary>
    /// <param name="windowBase"></param>
    /// <param name="dirType">0 = 上から下へ, 1 = 下から上に, 2 = 左から右に, 3 = 右から左に</param>
    /// <param name="isOpen"></param>
    private void ShowFromDir(UIWindowViewBase windowBase,int dirType,bool isOpen)
    {
        windowBase.gameObject.SetActive(true);

        Vector3 from = Vector3.zero;
        switch (dirType)
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
        windowBase.transform.localPosition = from;
        windowBase.transform.DOLocalMove(Vector3.zero,windowBase.duration)
            .SetAutoKill(false)
            .SetEase(GlobalInit.Instance.UIAnimationCurve)
            .Pause().OnRewind(() =>
        {
            DestroyWindow(windowBase);
        });

        if (isOpen)
        {
            windowBase.transform.DOPlayForward();
        }
        else
        {
            windowBase.transform.DOPlayBackwards();
        }
    }

    #endregion

    /// <summary>
    /// ウィンドウズUI潰す
    /// </summary>
    /// <param name="obj"></param>
    public void DestroyWindow(UIWindowViewBase windowBase)
    {
        LayerUIMgr.Instance.CheckOpenWindow();
        m_DicWindow.Remove(windowBase.CurrentUIType);
        Object.Destroy(windowBase.gameObject);       
    }
}