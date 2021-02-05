using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOnSceneCtrl : MonoBehaviour
{
    GameObject obj;
    private void Awake()
    {
        UISceneCtrl.Instance.LoadSceneUI(UISceneCtrl.SceneUIType.LogOn);
        //SceneUIMgr.Instance.LoadSceneUI(SceneUIMgr.SceneUIType.LogOn);
    }

}
