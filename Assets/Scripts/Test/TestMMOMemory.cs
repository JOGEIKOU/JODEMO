using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;

public class TestMMOMemory : MonoBehaviour
{

    void Start()
    {
        NetWorkSocket net1 = NetWorkSocket.Instance;

        //1.连接到服务器
        //NetWorkSocket.Instance.Connect("127.0.0.1", 1011);
    }

}
