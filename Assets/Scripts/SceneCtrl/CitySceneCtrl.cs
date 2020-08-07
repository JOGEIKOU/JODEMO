using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySceneCtrl : MonoBehaviour
{
    private void Awake()
    {
        SceneUIMgr.Instance.LoadSceneUI(SceneUIMgr.SceneUIType.MainCity);
    }
}
