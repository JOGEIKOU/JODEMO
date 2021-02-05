using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーンUIのベースクラス
/// </summary>
public class UISceneBase : UIBase
{
    /// <summary>
    /// UIコンテナ
    /// </summary>
    [SerializeField]
    public Transform Container_Center;
}
