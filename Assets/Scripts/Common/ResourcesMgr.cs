using UnityEngine;
using System.Collections;
using System.Text;

public class ResourcesMgr: Singleton<ResourcesMgr>
{
    #region ResourceType 资源类型
    /// <summary>
    /// リソースタイプ
    /// </summary>
    public enum ResourceType
    {
        /// <summary>
        /// シーンUI
        /// </summary>
        UIScene,
        /// <summary>
        /// ウィンドウズUI
        /// </summary>
        UIWindow,
        /// <summary>
        /// キャラクター
        /// </summary>
        Role,
        /// <summary>
        /// エフェクト
        /// </summary>
        Effect,
        /// <summary>
        ///他
        /// </summary>
        UIOther
    }
    #endregion

    /// <summary>
    /// プレハブhashtable
    /// </summary>
    private Hashtable m_PrefabTable;

    public ResourcesMgr()
    {
        m_PrefabTable = new Hashtable();
    }

    #region Load 加载资源
    /// <summary>
    /// リソースロード
    /// </summary>
    /// <param name="type">リソースタイプ</param>
    /// <param name="path">パス</param>
    /// <param name="cache">キャシューか</param>
    /// <returns>プレハブのクローン</returns>
    public GameObject Load(ResourceType type, string path, bool cache=false)
    {
        GameObject obj = null;
        if (m_PrefabTable.Contains(path))
        {
            obj = m_PrefabTable[path] as GameObject;
        }
        else
        {
            StringBuilder sbr = new StringBuilder();
            switch (type)
            {
                case ResourceType.UIScene:
                    sbr.Append("UIPrefabs/UIScene/");
                    break;
                case ResourceType.UIWindow:
                    sbr.Append("UIPrefabs/UIWindows/");
                    break;
                case ResourceType.Role:
                    sbr.Append("RolePrefabs/");
                    break;
                case ResourceType.Effect:
                    sbr.Append("EffectPrefabs/");
                    break;
                case ResourceType.UIOther:
                    sbr.Append("UIPrefabs/UIOther/");
                    break;
            }

            sbr.Append(path);

            obj = Resources.Load(sbr.ToString()) as GameObject;
            if (cache)
            {
                m_PrefabTable.Add(path, obj);
            }
        }

        return Object.Instantiate(obj);
    }
    #endregion

    #region Dispose　リソース開放
    /// <summary>
    /// リソース開放
    /// </summary>
    public override void Dispose()
    {
        base.Dispose();

        m_PrefabTable.Clear();

        //使わなかったリソース釈放される
        Resources.UnloadUnusedAssets();
    }
    #endregion
}