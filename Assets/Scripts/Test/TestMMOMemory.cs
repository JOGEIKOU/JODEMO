using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;

public class TestMMOMemory : MonoBehaviour
{

    void Start()
    {
        //1.连接到服务器
        NetWorkSocket.Instance.Connect("127.0.0.1", 1011);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Goods_EquipPutProto proto = new Goods_EquipPutProto();

            NetWorkSocket.Instance.SendMsg(proto.ToArray());
        }

    }
}
