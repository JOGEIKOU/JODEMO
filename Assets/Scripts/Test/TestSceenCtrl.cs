using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceenCtrl : MonoBehaviour
{
    /// <summary>
    /// ボックスクリエイトエリア
    /// </summary>
    [SerializeField]
    private Transform transCreatBox;

    /// <summary>
    /// ボックスの親
    /// </summary>
    [SerializeField]
    private Transform boxParent;

    /// <summary>
    /// ボックスのプレハブ
    /// </summary>
    private GameObject m_BoxPrefab;

    /// <summary>
    /// 今ボックスの数
    /// </summary>
    private int m_CurrentBoxCount = 0;

    /// <summary>
    /// 生成の最大数
    /// </summary>
    private int m_MaxCount = 10;

    /// <summary>
    /// 次のクローン時間
    /// </summary>
    private float m_NextCloneTime = 0f;

    private string m_BoxKey = "BoxKey";

    /// <summary>
    /// 前回拾ったボックスの数
    /// </summary>
    private int m_PrevCount;

    private void Start()
    {
        m_BoxPrefab =(GameObject)Resources.Load("RolePrefabs/Item/Box");
        Debug.Log("m_BoxPrefab = " + m_BoxPrefab);
       m_PrevCount = PlayerPrefs.GetInt("m_BoxKey", 0);
    }

    private void Update()
    {
        if(m_CurrentBoxCount<m_MaxCount)
        {
            if(Time.time > m_NextCloneTime)
            {
                m_NextCloneTime = Time.time + 1f;

                //クローン
                GameObject objClone = Instantiate(m_BoxPrefab);
                objClone.transform.parent = boxParent;
                objClone.transform.position = transCreatBox.transform.TransformPoint(new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f)));
                BoxCtrl boxCtrl = objClone.GetComponent<BoxCtrl>();
                if(boxCtrl != null)
                {
                    boxCtrl.OnHit = BoxHit;
                    m_CurrentBoxCount++;
                }              
            }
        }
    }

    private void BoxHit(GameObject obj)
    {
        m_CurrentBoxCount--;
        m_PrevCount++;
        PlayerPrefs.SetInt("m_BoxKey", m_PrevCount);

        GameObject.Destroy(obj);

        Debug.Log("計" + m_PrevCount + "を拾いました。");
    }
}
