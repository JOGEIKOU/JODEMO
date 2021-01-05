using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Menu
{
    [MenuItem("JODEMOTools/Settings")]
    public static void Setting()
    {
        SettingsWindow win = (SettingsWindow)EditorWindow.GetWindow(typeof(SettingsWindow));
        win.titleContent = new GUIContent("全局设置");
        win.Show();
    }

    [MenuItem("JODEMOTools/AssetBundleCreate")]
    public static void AssetBundleCreate()
    {
        string path = Application.dataPath + "/../AssetBundles";

        if(!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }


    }



}
