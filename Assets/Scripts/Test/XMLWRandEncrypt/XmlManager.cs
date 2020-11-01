using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System;

public class XmlManager
{
    /// <summary>
    /// 加密和解密密钥
    /// </summary>
    byte[] _keyArray = UTF8Encoding.UTF8.GetBytes("12348578902329367887724456789012");
    public bool HasFlie(string flieName)
    {
        return File.Exists(flieName);
    }

    /// <summary>
    /// 创建XML
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="dataString"></param>
    public void CreateXML(string fileName,String dataString)
    {
        StreamWriter writer;
        writer = File.CreateText(fileName);
        writer.Write(/*dataString*/Encrypt(dataString));
        writer.Close();
    }

    public string LoadXML(string flieName)
    {
        StreamReader reader = File.OpenText(flieName);
        string dataString = reader.ReadToEnd();
        reader.Close();
        return Decrypt(dataString);
    }


    #region 序列化/反序列化
    /// <summary>
    /// 序列化
    /// </summary>
    /// <param name="pObj"></param>
    /// <param name="ty"></param>
    /// <returns></returns>
    public String SerializedObj(object pObj,System.Type ty)
    {
        MemoryStream mStream = new MemoryStream();
        XmlSerializer xs = new XmlSerializer(ty);
        XmlTextWriter xmlTextWriter = new XmlTextWriter(mStream, Encoding.UTF8);
        xs.Serialize(xmlTextWriter, pObj);
        mStream = (MemoryStream)xmlTextWriter.BaseStream;
        return UTF8ByteArrayToString(mStream.ToArray());
    }

    /// <summary>
    /// 反序列化
    /// </summary>
    /// <param name="serializedString"></param>
    /// <param name="ty"></param>
    /// <returns></returns>
    public object DeserializedObject(string serializedString, System.Type ty)
    {
        XmlSerializer xs = new XmlSerializer(ty);
        MemoryStream mStream = new MemoryStream(stringToUTF8ByteArray(serializedString));
        return xs.Deserialize(mStream);
    }



    public string UTF8ByteArrayToString(byte[] bytes)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        return encoding.GetString(bytes);
    }

    byte[] stringToUTF8ByteArray(string dataString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        return encoding.GetBytes(dataString);
    }
    #endregion

    #region 使用ICryptTransfrom加密/解密

    /// <summary>
    /// 使用CryptTransform进行加密
    /// </summary>
    /// <param name="toEncrypt"></param>
    /// <returns></returns>
    public string Encrypt(string toEncrypt)
    {
        ICryptoTransform cTransform = GetRijndaelManaged().CreateEncryptor();
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    /// <summary>
    /// 使用ICryptTransform进行解密
    /// </summary>
    /// <param name="toDecrypt"></param>
    /// <returns></returns>
    public string Decrypt(string toDecrypt)
    {
        ICryptoTransform cTransform = GetRijndaelManaged().CreateDecryptor();
        byte[] toDecrypyArray = Convert.FromBase64String(toDecrypt);
        byte[] resultArray = cTransform.TransformFinalBlock(toDecrypyArray, 0, toDecrypyArray.Length);
        return UTF8Encoding.UTF8.GetString(resultArray);
    }

    RijndaelManaged GetRijndaelManaged()
    {
        RijndaelManaged rDel = new RijndaelManaged();
        rDel.Key = _keyArray;
        rDel.Mode = CipherMode.ECB;
        rDel.Padding = PaddingMode.PKCS7;
        return rDel;
    }
    #endregion
}
