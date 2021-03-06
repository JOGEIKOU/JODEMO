﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneCtrl : MonoBehaviour
{
    /// <summary>
    /// シーンUIコントローラー
    /// </summary>
    [SerializeField]
    private UISceneLoadingCtrl m_UILoadingCtrl;

    private AsyncOperation m_Async = null;

    private int m_CurrentProcess = 0;

    private void Start()
    {
        DelegateDefine.Instance.OnSceneLoadOK += OnSceneLoadOK;
        LayerUIMgr.Instance.Reset();
        StartCoroutine(LoadingScene());
    }

    private void OnDestroy()
    {
        DelegateDefine.Instance.OnSceneLoadOK -= OnSceneLoadOK;
    }


    private void OnSceneLoadOK()
    {
        if(m_UILoadingCtrl != null)
        {
            Destroy(m_UILoadingCtrl.gameObject);
        }
    }

    private IEnumerator LoadingScene()
    {
        string strSceneName = string.Empty;
        switch (SceneMgr.Instance.CurrentSceneType)
        {
            case SceneType.LogOn:
                strSceneName = "LogOn";
                break;
            case SceneType.City:
                strSceneName = "TestDemo";
                break;
            case SceneType.ShaMo:
                strSceneName = "GameScene_ShaMo";
                break;
            default:
                break;
        }
        
        m_Async = SceneManager.LoadSceneAsync(strSceneName,LoadSceneMode.Additive);
        m_Async.allowSceneActivation = false;
        yield return m_Async;
    }

    private void Update()
    {
        int toProgress = 0;

        if (m_Async.progress < 0.9f)
        {
            toProgress = Mathf.Clamp((int)m_Async.progress * 100,1,100);
        }
        else
        {
            toProgress = 100;
        }

        if (m_CurrentProcess < toProgress)
        {
            m_CurrentProcess++;
        }
        else
        {
            m_Async.allowSceneActivation = true;
        }


        m_UILoadingCtrl.SetProcessValue(m_CurrentProcess * 0.01f);
    }

}
