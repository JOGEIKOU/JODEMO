/***
 *   作者：辺涯
 * 
 * 　2016/1/28
 * 
 * 　勉強者：徐芸航
 * 　
 * 　2020/11/03
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数据管理基类
/// </summary>
public abstract class AbstractDBModel<T,P>
    where T: class,new()
    where P:AbstractEntity
{
    protected List<P> m_List;
    protected Dictionary<int, P> m_Dic;

    public AbstractDBModel()
    {
        m_List = new List<P>();
        m_Dic = new Dictionary<int, P>();
        LoadData();
    }

    #region 单例模式
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }
    #endregion

    #region 需要子类实现的属性或方法
    /// <summary>
    /// 数据文件名称
    /// </summary>
    protected abstract string FileName { get; }

    /// <summary>
    /// 创建实体
    /// </summary>
    /// <param name="parse"></param>
    /// <returns></returns>
    protected abstract P MakeEntity(GameDataTableParser parse);
    #endregion

    #region 加载数据    LoadData
    /// <summary>
    /// 加载数据
    /// </summary>
    private void LoadData()
    {
        using (GameDataTableParser parse = new GameDataTableParser(string.Format(@"C:\Users\Xyhai\OneDrive\桌面\MyStudy\GitProject\youyouDemo\JODEMO\www\Data\{0}",FileName)))
        {
            while (!parse.Eof)
            {
                //创建实体
                P p = MakeEntity(parse);
                //表里添加实体
                m_List.Add(p);
                //字典里添加实体
                m_Dic[p.Id] = p;
                //进入下一条数据
                parse.Next();
            }
        }
    }
    #endregion

    #region  GetList 获取集合
    /// <summary>
    /// 得到列表
    /// </summary>
    /// <returns></returns>
    public List<P> GetList()
    {
        return m_List;
    }
    #endregion

    #region  Get 根据编号获取实体
    /// <summary>
    /// 根据编号查询实体
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public P Get(int id)
    {
        if (m_Dic.ContainsKey(id))
        {
            return m_Dic[id];
        }
        return null;
    }
    #endregion
}
