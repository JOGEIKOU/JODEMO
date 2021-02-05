﻿//
//                所有UI视图的基类
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIViewBase : MonoBehaviour
{
    private void Awake()
    {
        OnAwake();
    }

    void Start()
    {
        Button[] btnArr = GetComponentsInChildren<Button>(true);
        for (int i = 0; i < btnArr.Length; i++)
        {
            EventTriggerListener.Get(btnArr[i].gameObject).onClick = BtnClick;
        }

        Onstart();
    }

    private void OnDestroy()
    {
        BeforeOnDestroy();
    }

    private void BtnClick(GameObject go)
    {
        OnBtnClick(go);
    }

    protected virtual void OnAwake()
    {

    }

    protected virtual void Onstart()
    {

    }

    protected virtual void BeforeOnDestroy() { }

    protected virtual void OnBtnClick(GameObject go) { }
}