using UnityEngine;
using System.Collections;

#region SceneType 
/// <summary>
///シーンタイプ
/// </summary>
public enum SceneType
{
    LogOn,
    City,
    ShaMo
}
#endregion

#region WindowUIType 
/// <summary>
/// ウィンドウズUIタイプ
/// </summary>
public enum WindowUIType
{

    None,

    LogOn,

    Reg,

    RoleInfo
}
#endregion

#region WindowUIContainerType
/// <summary>
/// UIコンテナタイプ
/// </summary>
public enum WindowUIContainerType
{

    TopLeft,

    TopRight,

    BottomLeft,

    BottomRight,

    Center
}
#endregion

#region WindowShowStyle 
/// <summary>
/// ウィンドウズUI演出効果
/// </summary>
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

#region RoleType
/// <summary>
/// キャラクタータイプ
/// </summary>
public enum RoleType
{
    None = 0,
    /// <summary>
    /// プレイヤー
    /// </summary>
    MainPlayer = 1,
    /// <summary>
    /// モンスター
    /// </summary>
    Emeny = 2
}
#endregion

/// <summary>
/// キャラクター状態
/// </summary>
public enum RoleState
{
    /// <summary>
    /// 正常
    /// </summary>
    None = 0,
    /// <summary>
    /// 休憩
    /// </summary>
    Idle = 1,
    /// <summary>
    /// 走る
    /// </summary>
    Run = 2,
    /// <summary>
    /// 攻撃
    /// </summary>
    Attack = 3,
    /// <summary>
    /// 傷つけ
    /// </summary>
    Hurt = 4,
    /// <summary>
    /// 死亡
    /// </summary>
    Die = 5
}

/// <summary>
/// キャラクターアニメーション状態名前
/// </summary>
public enum RoleAnimatorName
{
    _Idel_Normal,
    _Idle_Fight,
    _Run,
    _Hurt,
    _Die,
    _PhyATK1,
    _PhyATK2,
    _PhyATK3
}

public enum ToAnimatorCondition
{
    ToIdleNormal,
    ToIdelFighting,
    ToRun,
    ToHurt,
    ToDie,
    ToPhyAttack,
    CurrState
}