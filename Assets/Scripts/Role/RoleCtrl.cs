using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラクターコントローラー
/// </summary>
public class RoleCtrl : MonoBehaviour
{

    [SerializeField]
    public Transform m_HeadBarPos;

    private GameObject m_HeadBar;

    /// <summary>
    /// ターゲットのポジション
    /// </summary>
    [HideInInspector]
    public Vector3 TargetPos = Vector3.zero;

    /// <summary>
    /// プレイヤーコントローラー
    /// </summary>
    [HideInInspector]
    public CharacterController CharacterController;

    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    public float Speed = 10F;

    /// <summary>
    /// 出身地
    /// </summary>
    [HideInInspector]
    public Vector3 BornPoint;

    /// <summary>
    /// 視野範囲
    /// </summary>
    public float ViewRange;

    /// <summary>
    /// 巡り範囲
    /// </summary>
    public float PatroRange;

    /// <summary>
    /// 攻撃範囲
    /// </summary>
    public float AttackRange;

    /// <summary>
    /// プレイヤのアニメション
    /// </summary>
    [SerializeField]
    public Animator Animator;

    /// <summary>
    /// 今のキャラクタータイプ
    /// </summary>
    public RoleType CurrRoleType = RoleType.MainPlayer;

    /// <summary>
    /// 今のキャラクター情報
    /// </summary>
    public RoleInfoBase CurrRoleInfo = null;

    /// <summary>
    /// 今のキャラクターのAI
    /// </summary>
    public IRoleAI CurrRoleAI = null;

    /// <summary>
    /// 敵をロック
    /// </summary>
    [HideInInspector]
    public RoleCtrl LockEmeny;

    /// <summary>
    /// 有限状態
    /// </summary>
    public RoleFSMMgr CurrRoleFSMMgr = null;

    private RoleHeadBarCtrl roleHeadBarCtrl = null;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="roleType"></param>
    /// <param name="roleInfo"></param>
    /// <param name="ai"></param>
    public void Init(RoleType roleType,RoleInfoBase roleInfo,IRoleAI ai)
    {
        CurrRoleType = roleType;
        CurrRoleInfo = roleInfo;
        CurrRoleAI = ai;
    }

    void Start()
    {
        CharacterController = GetComponent<CharacterController>();

        if(CurrRoleType == RoleType.MainPlayer)
        {
            if (CameraCtrl.Instance != null)
            {
                CameraCtrl.Instance.Init();
            }
        }

        CurrRoleFSMMgr = new RoleFSMMgr(this);
        ToIdel();
        InitHeadBar();
    }

    void Update()
    {
        //キャラクターのAIチェック
        if (CurrRoleAI == null) return;
        CurrRoleAI.DoAI();

        if (CurrRoleFSMMgr != null)
        {
            CurrRoleFSMMgr.OnUpdate();
        }

        if (CharacterController == null) return;

        //地面と当たる
        if(!CharacterController.isGrounded)
        {
            CharacterController.Move((transform.position + new Vector3(0, -1000, 0)) - transform.position);
        }

        if (Input.GetMouseButtonUp(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Item")))
            {
                BoxCtrl boxCtrl = hit.collider.GetComponent<BoxCtrl>();
                if (boxCtrl != null)
                {
                    boxCtrl.Hit();
                }
            }
        }

        //让角色贴着地面
        if (!CharacterController.isGrounded)
        {
            CharacterController.Move((transform.position + new Vector3(0, -1000, 0)) - transform.position);
        }

        if (CurrRoleType == RoleType.MainPlayer)
        {
            CameraAutoFollow();
        }
    }

    /// <summary>
    /// キャラクターフォローネーム初期化
    /// </summary>
    private void InitHeadBar()
    {      
        if (RoleHeadBarRoot.Instance == null) return;
        if (CurrRoleInfo == null) return;
        if (m_HeadBarPos == null) return;

        //clone prefab
        m_HeadBar = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIOther, "RoleHeadBar");
        m_HeadBar.transform.parent = RoleHeadBarRoot.Instance.gameObject.transform;
        m_HeadBar.transform.localScale = Vector3.one;

        roleHeadBarCtrl = m_HeadBar.GetComponent<RoleHeadBarCtrl>();

        // prefabに値を上げる
        roleHeadBarCtrl.Init(m_HeadBarPos, CurrRoleInfo.NickName, isShowHPBar: (CurrRoleType == RoleType.MainPlayer ? false : true));

    }

    #region キャラクター操作

    public void ToIdel()
    {
        CurrRoleFSMMgr.ChangeState(RoleState.Idle);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="attackValue">ダメージ値</param>
    /// <param name="delayTime">遅延時間</param>
    public void ToHurt(int attackValue,float delayTime)
    {
        StartCoroutine(ToHurtCoroutine(attackValue,delayTime));
    }

    public IEnumerator ToHurtCoroutine(int attackValue, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        //計算
        int hurt = (int)(attackValue * UnityEngine.Random.Range(0.5f, 1f));

        roleHeadBarCtrl.SetHUDText(hurt);
        CurrRoleInfo.CurrHP -= hurt;

        if(CurrRoleInfo.CurrHP <=0)
        {
            CurrRoleFSMMgr.ChangeState(RoleState.Die);
        }
        else
        {
            CurrRoleFSMMgr.ChangeState(RoleState.Hurt);
        } 
    }

    public void ToAttack()
    {
        if (LockEmeny == null) return;
        CurrRoleFSMMgr.ChangeState(RoleState.Attack);

        //仮に書き方
        LockEmeny.ToHurt(100, 0.5f);
    }

    public void ToDie()
    {
        CurrRoleFSMMgr.ChangeState(RoleState.Die);
    }

    public void MoveTo(Vector3 targetPos)
    {
        //もしターゲットのポジションと原点同じじゃない
        if (targetPos == Vector3.zero) return;
        TargetPos = targetPos;
        CurrRoleFSMMgr.ChangeState(RoleState.Run);
    }

    #endregion

    private void CameraAutoFollow()
    {
        if (CameraCtrl.Instance == null) return;

        CameraCtrl.Instance.transform.position = gameObject.transform.position;
        CameraCtrl.Instance.AutoLookAt(gameObject.transform.position);
    }

    private void OnDestroy()
    {

    }
}
