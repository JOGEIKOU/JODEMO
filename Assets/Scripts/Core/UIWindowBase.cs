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
}
