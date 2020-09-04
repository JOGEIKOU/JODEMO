using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 休憩状態
/// </summary>
public class RoleStateIdle : RoleStateAbs
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="roleFSMMgr">有限状態機マネージャー</param>
    public RoleStateIdle(RoleFSMMgr roleFSMMgr) : base(roleFSMMgr)
    {

    }

    /// <summary>
    /// 状態に入る
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToIdelFighting.ToString(), true);
    }

    /// <summary>
    /// 状態を実行
    /// </summary>
    public override void OnUpdate()
    {
        base.OnUpdate();

        CurrRoleAnimatorStateInfo = CurrRoleFSMMgr.CurrRoleCtrl.Animator.GetCurrentAnimatorStateInfo(0);
        if (CurrRoleAnimatorStateInfo.IsName(RoleAnimatorName._Idle_Fight.ToString()));
        {
            CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), (int)RoleState.Idle);
        }
    }

    /// <summary>
    /// 状態に離れ
    /// </summary>
    public override void OnLeave()
    {
        base.OnLeave();
        CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToIdelFighting.ToString(), false);
    }
}
