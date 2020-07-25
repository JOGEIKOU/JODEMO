using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// �V���O���g���p�^�[���@�x�[�X�N���X
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
    /// �J�����\�b�h
    /// </summary>
    public virtual void Dispose()
    {
        
    }
}