using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// キャラクターAIインタフェース
/// </summary>
public interface IRoleAI 
{
    /// <summary>
    /// 現在コントローラーしているキャラクター
    /// </summary>
    RoleCtrl CurrRole
    {
        get;
        set;
    }


    /// <summary>
    /// AI実行
    /// </summary>
    void DoAI();
}
