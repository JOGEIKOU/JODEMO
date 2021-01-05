using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoadScene : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("dataPath = " + Application.dataPath);
        Debug.Log("persistentDataPath = " + Application.persistentDataPath);
        Debug.Log("streamingAssetsPath = " + Application.streamingAssetsPath);
        Debug.Log("temporaryCachePath = " + Application.temporaryCachePath);

    }
}
