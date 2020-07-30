using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOnSceneCtrl : MonoBehaviour
{
    GameObject obj;
    private void Awake()
    {
        SceneUIMgr.Instance.LoadSceneUI(SceneUIMgr.SceneUIType.LogOn);
    }

    private void Update()
    {

    }
}
