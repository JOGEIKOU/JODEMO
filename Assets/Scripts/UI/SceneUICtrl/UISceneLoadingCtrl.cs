using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LoadingシーンUIマネージャー
/// </summary>
public class UISceneLoadingCtrl : UISceneBase
{
    /// <summary>
    /// processbar
    /// </summary>
    [SerializeField]
    private UIProgressBar m_Progress;

    [SerializeField]
    private UILabel m_LblProgress;

    [SerializeField]
    private UISprite m_SprProgressLight;

    /// <summary>
    /// 設置プロセスの値
    /// </summary>
    /// <param name="value"></param>
    public void SetProcessValue(float value)
    {
        m_Progress.value = value;
        m_LblProgress.text = string.Format("{0}%", (int)(value * 100));

        m_SprProgressLight.transform.localPosition = new Vector3(1250f * value, 0, 0);
    }
}
