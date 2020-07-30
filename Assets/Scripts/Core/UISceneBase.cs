using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISceneBase<T> : MonoBehaviour where T :MonoBehaviour
{
    public static T Instance;

    /// <summary>
    /// UIコンテナ
    /// </summary>
    [SerializeField]
    public Transform Container_Center;

    private void Awake()
    {
        Instance = this as T;
        OnAwake();
    }

    protected virtual void OnAwake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
