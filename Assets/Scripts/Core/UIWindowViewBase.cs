using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindowViewBase : UIViewBase
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

    protected override void OnBtnClick(GameObject go)
    {
        base.OnBtnClick(go);
        if(go.name.Equals("Btn_Close", StringComparison.CurrentCultureIgnoreCase))
        {
            Close();
        }
    }


    /// <summary>
    /// close window
    /// </summary>
    protected virtual void Close()
    {
        WindowUIMgr.Instance.CloseWindow(CurrentUIType);
    }

    protected override void BeforeOnDestroy()
    {

    }
}
