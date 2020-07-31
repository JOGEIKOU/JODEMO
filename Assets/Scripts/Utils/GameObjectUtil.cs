﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectUtil
{
    /// <summary>
    /// コンポーネントを取得又はクリエイト
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T GetOrCreatComponent<T>(this GameObject obj) where T:MonoBehaviour
    {
        T t = obj.GetComponent<T>();
        if(t==null)
        {
            t = obj.AddComponent<T>();
        }
        return t;
    }
}