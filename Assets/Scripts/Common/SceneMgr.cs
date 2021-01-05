using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadSceneAsync("SceneLoadingCtrl");
    }

    /// <summary>
    /// 去村庄
    /// </summary>
    public void LoadToCity()
    {
        CurrentSceneType = SceneType.City;
        SceneManager.LoadSceneAsync("SceneLoadingCtrl");
    }

    /// <summary>
    /// 去沙漠
    /// </summary>
    public void LoadToShaMo()
    {
        CurrentSceneType = SceneType.City;
        SceneManager.LoadSceneAsync("SceneLoadingCtrl");
    }

}