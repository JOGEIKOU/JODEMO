using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 攻撃状態
/// </summary>
public class RoleStateAttack : RoleStateAbs
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="roleFSMMgr">有限状態機マネージャー</param>
    public RoleStateAttack(RoleFSMMgr roleFSMMgr) : base(roleFSMMgr)
    {

    }

    /// <summary>
    /// 状態に入る
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.ToPhyAttack.ToString(), 1);
    }

    /// <summary>
    /// 状態を実行
    /// </summary>
    public override void OnUpdate()
    {
        base.OnUpdate();

        CurrRoleAnimatorStateInfo = CurrRoleFSMMgr.CurrRoleCtrl.Animator.GetCurrentAnimatorStateInfo(0);
        if (CurrRoleAnimatorStateInfo.IsName(RoleAnimatorName._PhyATK1.ToString())) 
        {
            CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), (int)RoleState.Attack);

            //idle に戻す
            if(CurrRoleAnimatorStateInfo.normalizedTime > 1)
            {
                CurrRoleFSMMgr.CurrRoleCtrl.ToIdel();
            }
        }
        else{
            CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), 0);
        }
    }

    /// <summary>
    /// 状態に離れ
    /// </summary>
    public override void OnLeave()
    {
        base.OnLeave();

        CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.ToPhyAttack.ToString(), 0);
    }
}
