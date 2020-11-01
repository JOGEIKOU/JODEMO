using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    #region 共有变量
    #endregion
    #region 私有变量
    string dataFileName = "Price.Xml";
    XmlManager xm = new XmlManager();
    private DevicePrice m_devicePrice;
    #endregion
    // Use this for initialization
    void Start()
    {
        m_devicePrice = new DevicePrice();

        //CreatXML();
        LoadPrice();
    }

    // Update is called once per frame
    void Update() { }
    /// <summary>
    /// 创建XML
    /// 默认保存在桌面
    /// </summary>
    public void CreatXML()
    {
        string dataFilePath = GetDataPath() + "/" + dataFileName;
        string serializedDataString = xm.SerializedObj(m_devicePrice, typeof(DevicePrice));
        xm.CreateXML(dataFilePath, serializedDataString);
        string dataFilePath2 = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/" + dataFileName;
        xm.CreateXML(dataFilePath2, serializedDataString);
    }
    /// <summary>
    /// 加载价格
    /// </summary>
    public void LoadPrice()
    {
        string dataFilePath = GetDataPath() + "/" + dataFileName;
        if (xm.HasFlie(dataFilePath))
        {
            string dataString = xm.LoadXML(dataFilePath);
            print(dataString);
            DevicePrice devicePriceFromXML = xm.DeserializedObject(dataString, typeof(DevicePrice)) as DevicePrice;
            if (devicePriceFromXML != null)
            {
                m_devicePrice = devicePriceFromXML;
            }
            else
                Debug.Log("devicePriceFromXML is null");
        }
    }
    string GetDataPath()
    {
        //return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        return Application.dataPath;
        //return Application.streamingAssetsPath+"/Data";
    }
}
