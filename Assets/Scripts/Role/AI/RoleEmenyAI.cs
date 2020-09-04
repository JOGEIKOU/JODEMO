using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵のAI
/// </summary>
public class RoleEmenyAI : IRoleAI
{
    public RoleCtrl CurrRole { get; set; }

    public RoleEmenyAI(RoleCtrl roleCtrl)
    {
        CurrRole = roleCtrl;
    }

    private float m_NextPatrolTime = 0f;

    /// <summary>
    /// 次の攻撃時間
    /// </summary>
    private float m_NextAttackTime = 0f;


    public void DoAI()
    {
        if(CurrRole.LockEmeny == null)
        {
            //IDEL
            if (CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum == RoleState.Idle)
            {
                if (Time.time > m_NextPatrolTime)
                {
                    m_NextPatrolTime = Time.time + Random.Range(5f, 6f);
                    //巡り
                    CurrRole.MoveTo(new Vector3(CurrRole.BornPoint.x + Random.Range(CurrRole.PatroRange * -1, CurrRole.PatroRange),
                                                          CurrRole.BornPoint.y,
                                                          CurrRole.BornPoint.z + Random.Range(CurrRole.PatroRange * -1, CurrRole.PatroRange)));
                }
            }

            //周りの敵を検査(自分と敵の距離が敵の視界範囲以内)
            if(Vector3.Distance( CurrRole.transform.position,GlobalInit.Instance.CurrPlayer.transform.position) <= CurrRole.ViewRange)
            {
                CurrRole.LockEmeny = GlobalInit.Instance.CurrPlayer;
            }
        }
        else
        {
            //もし目標あったら
            //１．もし自分とロックした敵の距離は自分の視界範囲より長いなら、ロックキャンセル        
            if (Vector3.Distance(CurrRole.transform.position, GlobalInit.Instance.CurrPlayer.transform.position) > CurrRole.ViewRange)
            {
                CurrRole.LockEmeny = null;
                return;
            }
       
            if(Vector3.Distance(CurrRole.transform.position, GlobalInit.Instance.CurrPlayer.transform.position) <= CurrRole.AttackRange)
            {

                if(Time.time > m_NextAttackTime && CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum != RoleState.Attack)
                {
                    m_NextAttackTime = Time.time + Random.Range(3f, 5f);
                    //２．もし距離は攻撃範囲内なら直線攻撃
                    CurrRole.ToAttack();
                }
            }
            else
            {
                if(CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum != RoleState.Idle)
                {
                    //３．自分の視界範囲内なら、追いかける
                    CurrRole.MoveTo(new Vector3(CurrRole.LockEmeny.transform.position.x + Random.Range(CurrRole.AttackRange * -1, CurrRole.AttackRange),
                                                                          CurrRole.LockEmeny.transform.position.y,
                                                                          CurrRole.LockEmeny.transform.position.z + Random.Range(CurrRole.AttackRange * -1, CurrRole.AttackRange)));
                }

            }
        }







    }
}
