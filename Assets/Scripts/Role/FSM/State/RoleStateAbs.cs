using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// キャラクター状態の抽象baseclass
/// </summary>
public abstract class RoleStateAbs
{
    /// <summary>
    /// 今の有限状態マネージャー
    /// </summary>
    public RoleFSMMgr CurrRoleFSMMgr { get; private set; }

    /// <summary>
    /// 今のアニメーション状態状態
    /// </summary>
    public AnimatorStateInfo CurrRoleAnimatorStateInfo { get; set; }

    public RoleStateAbs(RoleFSMMgr roleFSMMgr)
    {
        CurrRoleFSMMgr = roleFSMMgr;
    }

    /// <summary>
    /// 状態に入る
    /// </summary>
    public virtual void OnEnter()
    {

    }

    /// <summary>
    /// 状態を実行
    /// </summary>
    public virtual void OnUpdate()
    {

    }

    /// <summary>
    /// 状態に離れる
    /// </summary>
    public virtual void OnLeave()
    {

    }
}
