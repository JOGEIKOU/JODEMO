using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラクター　ベースクラス
/// </summary>
public class RoleInfoBase
{
    /// <summary>
    /// キャラクター　サーバーID
    /// </summary>
    public long RoleServerID;

    /// <summary>
    /// キャラクターID（ロケーションID）
    /// </summary>
    public int RoleID;

    /// <summary>
    /// ニックネーム
    /// </summary>
    public string NickName;

    /// <summary>
    /// HP上限
    /// </summary>
    public int MaxHP;

    /// <summary>
    /// 今のHP
    /// </summary>
    public int CurrHP;
}
