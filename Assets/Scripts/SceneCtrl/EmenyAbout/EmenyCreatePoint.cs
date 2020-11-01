using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EmenyCreatePoint : MonoBehaviour
{
    /// <summary>
    /// このポイント最大数
    /// </summary>
    [SerializeField]
    private int m_MaxCount;

    /// <summary>
    /// 敵の名前
    /// </summary>
    [SerializeField]
    private string emenyName;

    /// <summary>
    /// 今の数
    /// </summary>
    private int m_CurrCount;

    private float m_PrevCreatTime = 0;

    private void Update()
    {
        if(m_CurrCount<m_MaxCount)
        {
            if (Time.time > m_PrevCreatTime + Random.Range(1.5f, 3.5f))
            {
                m_PrevCreatTime = Time.time;

                //ement creat
                GameObject objClone = RoleMgr.Instance.LoadRole(emenyName, RoleType.Emeny);

                objClone.transform.parent = this.transform;
                objClone.transform.position = transform.TransformPoint(new Vector3(Random.Range(-1f,1f),0,Random.Range(-1f,1f)));
                RoleCtrl roleCtrl = objClone.GetComponent<RoleCtrl>();
                roleCtrl.BornPoint = objClone.transform.position;


                RoleInfoEmeny roleInfo = new RoleInfoEmeny();
                roleInfo.RoleServerID = System.DateTime.Now.Ticks;
                roleInfo.RoleID = 1;
                roleInfo.CurrHP = roleInfo.MaxHP = 1000;
                roleInfo.NickName = "大魔王徐";
                roleCtrl.Init(RoleType.Emeny, roleInfo, new RoleEmenyAI(roleCtrl));

                roleCtrl.OnRoleDie = RoleDie;

                m_CurrCount++;
            }
        }
    }

    private void RoleDie(RoleCtrl obj)
    {
        m_CurrCount--;
        Destroy(obj.gameObject);
    }
}
