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

    private void Start()
    {
        m_BoxPrefab =(GameObject)Resources.Load("RolePrefabs/Item/Box");
        Debug.Log("m_BoxPrefab = " + m_BoxPrefab);
    }

    private void Update()
    {
        
    }



}
