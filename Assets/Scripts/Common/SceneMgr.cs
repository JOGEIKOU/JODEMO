using UnityEngine;
using System.Collections;

/// <summary>
/// シーンマネージャー
/// </summary>
public class SceneMgr : Singleton<SceneMgr>
{
    /// <summary>
    /// シーンのタイプ
    /// </summary>
    public SceneType CurrentSceneType
    {
        get;
        private set;
    }

    public void LoadToLogOn()
    {
        CurrentSceneType = SceneType.LogOn;
        
        Application.LoadLevel("TestDemo");
    }

    /// <summary>
    /// 町シーンに行く
    /// </summary>
    public void LoadToCity()
    {
        CurrentSceneType = SceneType.City;
        Application.LoadLevel("TestDemo");
    }
}