using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Menu
{
    [MenuItem("JODEMOTools/设置")]
    public static void Setting()
    {
        SettingsWindow win = (SettingsWindow)EditorWindow.GetWindow(typeof(SettingsWindow));
        win.titleContent = new GUIContent("全局设置");
        win.Show();
    }

    [MenuItem("JODEMOTools//资源管理/资源打包管理")]
    public static void AssetBundleCreate()
    {
        AssetBundleWindow win = EditorWindow.GetWindow<AssetBundleWindow>();
        win.titleContent = new GUIContent("AssetBundle打包");
        win.Show();
    }

    [MenuItem("JODEMOTools/资源管理/初始资源拷贝到StreamingAsstes")]
    public static void AssetBundleCopyToStreamingAsstes()
    {
        string toPath = Application.streamingAssetsPath + "/AssetBundles:/";

        if (Directory.Exists(toPath))
        {
            Directory.Delete(toPath, true);
        }
        Directory.CreateDirectory(toPath);

        //IOUtil.CopyDirectory(Application.persistentDataPath, toPath);
        AssetDatabase.Refresh();
        Debug.Log("拷贝完毕");
    }

}
