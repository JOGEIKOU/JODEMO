using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自己定義クラス
/// </summary>
public class BoxEntity
{
    protected int m_BoxSize;

    public string BoxName { get; set; }
    public int BoxSize { get => m_BoxSize; set => m_BoxSize = value; }

    /// <summary>
    /// デリゲート
    /// </summary>
    public delegate void OnClickHandler();

    /// <summary>
    /// イベント
    /// </summary>
    public event OnClickHandler OnClick;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public BoxEntity()
    {

    }


    /// <summary>
    /// 戻り値なし、引数なしメソッド
    /// </summary>
    private void getSize()
    {

    }


    /// <summary>
    /// 戻り値あり、引数なしメソッド
    /// </summary>
    /// <returns></returns>
    private int getMaxSize()
    {
        return 0;
    }

    /// <summary>
    /// 戻り値あり、引数ありメソッド
    /// </summary>
    /// <param name="name">名前</param>
    /// <returns></returns>
    private string getDisplayName(string name)
    {
        return string.Format("{0}_AA", name);
    }


}
