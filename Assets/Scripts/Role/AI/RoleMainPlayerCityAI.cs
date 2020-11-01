using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// role main city scene AI
/// </summary>
public class RoleMainPlayerCityAI : IRoleAI
{
    public RoleCtrl CurrRole { get; set; }

    public RoleMainPlayerCityAI(RoleCtrl roleCtrl)
    {
        CurrRole = roleCtrl;
    }

    public void DoAI()
    {
        //1もし敵にロックしたら、攻撃
        if(CurrRole.LockEmeny != null)
        {
            if(CurrRole.LockEmeny.CurrRoleInfo.CurrHP <= 0)
            {
                CurrRole.LockEmeny = null;
                return;
            }

            if (CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum != RoleState.Attack)
            {
                CurrRole.ToAttack();
            }
        }
    }
}
