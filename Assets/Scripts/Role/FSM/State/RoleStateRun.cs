using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 走る状態
/// </summary>
public class RoleStateRun : RoleStateAbs
{
    /// <summary>
    /// プレイヤー回転速度
    /// </summary>
    private float m_RotationSpeed = 0.2f;

    /// <summary>
    /// ターゲットのクォータニオン
    /// </summary>
    private Quaternion m_TargetQuaternion;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="roleFSMMgr">有限状態機マネージャー</param>
    public RoleStateRun(RoleFSMMgr roleFSMMgr) : base(roleFSMMgr)
    {

    }

    /// <summary>
    /// 状態に入る
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();

        m_RotationSpeed = 0f;
        CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToRun.ToString(), true);
    }

    /// <summary>
    /// 状態を実行
    /// </summary>
    public override void OnUpdate()
    {
        base.OnUpdate();

        CurrRoleAnimatorStateInfo = CurrRoleFSMMgr.CurrRoleCtrl.Animator.GetCurrentAnimatorStateInfo(0);
        if (CurrRoleAnimatorStateInfo.IsName(RoleAnimatorName._Run.ToString()))
        {
            CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), (int)RoleState.Run);
        }
        else
        {
            CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger(ToAnimatorCondition.CurrState.ToString(), 0);
        }

        if (Vector3.Distance(new Vector3(CurrRoleFSMMgr.CurrRoleCtrl.TargetPos.x, 0, CurrRoleFSMMgr.CurrRoleCtrl.TargetPos.z), new Vector3(CurrRoleFSMMgr.CurrRoleCtrl.transform.position.x, 0, CurrRoleFSMMgr.CurrRoleCtrl.transform.position.z)) > 0.1f)
        {
            Vector3 direction = CurrRoleFSMMgr.CurrRoleCtrl.TargetPos - CurrRoleFSMMgr.CurrRoleCtrl.transform.position;
            direction = direction.normalized;//ノーマライズ
            direction = direction * Time.deltaTime * CurrRoleFSMMgr.CurrRoleCtrl.Speed;
            direction.y = 0f;

            //キャラクター回転（ターゲット向け）
            if (m_RotationSpeed <= 1)
            {
                m_RotationSpeed += 10f * Time.deltaTime;
                m_TargetQuaternion = Quaternion.LookRotation(direction);
                CurrRoleFSMMgr.CurrRoleCtrl.transform.rotation = Quaternion.Lerp(CurrRoleFSMMgr.CurrRoleCtrl.transform.rotation, m_TargetQuaternion, m_RotationSpeed);

                if (Quaternion.Angle(CurrRoleFSMMgr.CurrRoleCtrl.transform.rotation, m_TargetQuaternion) < 1)
                {
                    m_RotationSpeed = 0;
                }
            }
            CurrRoleFSMMgr.CurrRoleCtrl.CharacterController.Move(direction);
        }
        else
        {
            CurrRoleFSMMgr.CurrRoleCtrl.ToIdel();
        }
    }

    /// <summary>
    /// 状態に離れ
    /// </summary>
    public override void OnLeave()
    {
        base.OnLeave();
        CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetBool(ToAnimatorCondition.ToRun.ToString(), false);
    }
}
