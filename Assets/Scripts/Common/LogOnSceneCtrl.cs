using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOnSceneCtrl : MonoBehaviour
{
    GameObject obj;
    private void Awake()
    {
        obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIScene,"UI Root_LogOnScene",cache:true);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.D))
        {
            Destroy(obj);
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            obj = ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.UIScene, "UI Root_LogOnScene", cache: true);
        }
    }
}
