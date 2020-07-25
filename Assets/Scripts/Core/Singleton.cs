using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// シングルトンパターン　ベースクラス
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : IDisposable where T :new()
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }

    /// <summary>
    /// 開放メソッド
    /// </summary>
    public virtual void Dispose()
    {
        
    }
}