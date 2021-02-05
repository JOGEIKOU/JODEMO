﻿using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class AssetBundleDAL
{
    /// <summary>
    /// xml路径
    /// </summary>
    private string m_Path;

    /// <summary>
    /// 返回的数据集合
    /// </summary>
    private List<AssetBundleEntity> m_list = null;


    public AssetBundleDAL(string path)
    {
        m_Path = path;
        m_list = new List<AssetBundleEntity>();
    }

    /// <summary>
    /// 返回XML数据
    /// </summary>
    /// <returns></returns>
    public List<AssetBundleEntity> GetList()
    {
        m_list.Clear();

        //读取Xml，把数据添加到m_List里面
        XDocument xDoc = XDocument.Load(m_Path);
        XElement root = xDoc.Root;

        XElement assetBundleNode = root.Element("AssetBundle");

        IEnumerable<XElement> lst = assetBundleNode.Elements("Item");

        int index = 0;
        foreach (XElement item in lst)
        {
            AssetBundleEntity entity = new AssetBundleEntity();
            entity.Key = "key" + ++index;
            entity.Name = item.Attribute("Name").Value;
            entity.Tag = item.Attribute("Tag").Value;
            entity.IsFolder = item.Attribute("IsFolder").Value.Equals("True", System.StringComparison.CurrentCultureIgnoreCase);
            entity.IsFirstData = item.Attribute("IsFirstData").Value.Equals("True", System.StringComparison.CurrentCultureIgnoreCase);

            IEnumerable<XElement> pathList = item.Elements("Path");

            foreach (XElement path in pathList)
            {
                entity.PathList.Add(string.Format("Assets/{0}", path.Attribute("Value").Value));
            }
            m_list.Add(entity);
        }
        return m_list;
    }
}