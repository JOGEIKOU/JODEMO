using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// キャラクタ有限状態マネージャー
/// </summary>
public class RoleFSMMgr
{
    /// <summary>
    /// キャラクターコントローラー
    /// </summary>
    public RoleCtrl CurrRoleCtrl { get; private set; }

    /// <summary>
    /// 今の状態(enum)
    /// </summary>
    public RoleState CurrRoleStateEnum { get; private set; }

    /// <summary>
    /// 今の状態（抽象クラス）
    /// </summary>
    private RoleStateAbs m_CurrRoleState = null;

    private Dictionary<RoleState, RoleStateAbs> m_RoleStateDic;


    /// <summary>
    /// コンストラクタ
    /// </summary>
    public RoleFSMMgr(RoleCtrl currRoleCtrl)
    {
        CurrRoleCtrl = currRoleCtrl;

        m_RoleStateDic = new Dictionary<RoleState, RoleStateAbs>();
        m_RoleStateDic[RoleState.Idle] = new RoleStateIdle(this);
        m_RoleStateDic[RoleState.Run] = new RoleStateRun(this);
        m_RoleStateDic[RoleState.Attack] = new RoleStateAttack(this);
        m_RoleStateDic[RoleState.Hurt] = new RoleStateHurt(this);
        m_RoleStateDic[RoleState.Die] = new RoleStateDie(this);

        if(m_RoleStateDic.ContainsKey(CurrRoleStateEnum))
        {
            m_CurrRoleState = m_RoleStateDic[CurrRoleStateEnum];
        }
    }

    #region OnUpdata
    /// <summary>
    /// 毎フレーム実行
    /// </summary>
    public void OnUpdate()
    {
        if(m_CurrRoleState!=null)
        {
            m_CurrRoleState.OnUpdate();
        }
    }
    #endregion

    /// <summary>
    /// 状態切り替え
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(RoleState newState)
    {
        if (CurrRoleStateEnum == newState) return;

        //前状態に離れ
        if(m_CurrRoleState != null)
        {
            m_CurrRoleState.OnLeave();
        }

        //状態（key->enum）更新
        CurrRoleStateEnum = newState;

        //状態更新
        m_CurrRoleState = m_RoleStateDic[newState];

        //新状態に入る
        m_CurrRoleState.OnEnter();
    }

}
