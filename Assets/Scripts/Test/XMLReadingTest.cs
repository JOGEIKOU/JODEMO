using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class XMLReadingTest : MonoBehaviour
{

    
    private string name1;
    private string name2;

    private string year1;
    private string year2;

    private string id1;
    private int id2;

    private void Start()
    {
        ParseXml();
    }

    private void ParseXml()
    {
        string filePath = Application.dataPath + "/Resources/XMLCollection/Test.xml";
        if (File.Exists(filePath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNodeList node = xmlDoc.SelectSingleNode("item").ChildNodes;

            foreach (XmlElement ele in node)
            {
                Debug.Log(ele.Name);

                if(ele.Name == "item1")
                {
                    foreach (XmlElement i1 in ele.ChildNodes)
                    {
                        Debug.Log(i1.Name);
                        if(i1.Name == "id")
                        {
                            id1 = i1.InnerText;
                        }
                        if(i1.Name == "name")
                        {
                            name1 = i1.InnerText;
                        }
                        if(i1.Name == "year")
                        {
                            year1 = i1.InnerText;
                        }
                    }
                }
            }

            Debug.Log("id1: " + id1);
            Debug.Log("name1: " + name1);
            Debug.Log("year1: " + year1);

        }
    }










}
