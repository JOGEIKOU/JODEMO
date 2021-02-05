using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 全てのウィンドウズUIのベース
/// </summary>
public class UIWindowBase : UIBase
{
    [SerializeField]
    public WindowUIContainerType containerType = WindowUIContainerType.Center;
    [SerializeField]
    public WindowShowStyle showStyle = WindowShowStyle.Normal;
    /// <summary>
    /// open or close panel of use time
    /// </summary>
    [SerializeField]
    public float duration = 0.2f;

    [HideInInspector]
    public WindowUIType CurrentUIType;

    /// <summary>
    /// next open window
    /// </summary>
    protected WindowUIType m_NextOpenWindow = WindowUIType.None;

    /// <summary>
    /// close window
    /// </summary>
    protected virtual void Close()
    {
        WindowUIMgr.Instance.CloseWindow(CurrentUIType);
    }

    protected override void BeforeOnDestroy()
    {
        if (m_NextOpenWindow == WindowUIType.None) return;
        WindowUIMgr.Instance.OpenWindow(m_NextOpenWindow);
    }
}
