using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI レイアウトマネージャー
/// </summary>
public class LayerUIMgr : Singleton<LayerUIMgr>
{
    /// <summary>
    /// UI layerout depth
    /// </summary>
    private int m_UIPanelDepth = 50;

    public void Reset()
    {
        m_UIPanelDepth = 50;
    }
    
    /// <summary>
    /// 開けてるウィンドウズの数をチェック、なければ、リセットする。
    /// </summary>
    public void CheckOpenWindow()
    {
        if(WindowUIMgr.Instance.OpenWindowCount == 0)
        {
            Reset();
        }
    }

    /// <summary>
    /// set layerout
    /// </summary>
    public void SetLayer(GameObject obj)
    {
        m_UIPanelDepth += 1;

        UIPanel[] panArr = obj.GetComponentsInChildren<UIPanel>();

        if(panArr.Length >0)
        {
            for (int i = 0; i < panArr.Length; i++)
            {
                panArr[i].depth += m_UIPanelDepth;
            }
        }

    }
}
