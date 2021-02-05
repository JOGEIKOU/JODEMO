//
//       账户系统控制器
//

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountCtrl : Singleton<AccountCtrl>
{
    /// <summary>
    /// 登录窗口的视图
    /// </summary>
    private UILogOnView m_LogOnView;

    public AccountCtrl()
    {
        EventDispatcher.Instance.AddBtnEventListener("UILogOnView_Btn_Logon", LogOnViewBtnLogOnClick);
        EventDispatcher.Instance.AddBtnEventListener("UILogOnView_Btn_ToRegister", LogOnViewBtnToRegClick);
    }

    /// <summary>
    ///监听登录按钮
    /// </summary>
    /// <param name="param"></param>
    private void LogOnViewBtnLogOnClick(object[] param)
    {
        Debug.Log("监听登录按钮 LogOnViewBtnLogOnClick");
    }

    /// <summary>
    /// 监听登录按钮监听立即注册按钮
    /// </summary>
    /// <param name="param"></param>
    private void LogOnViewBtnToRegClick(object[] param)
    {
        Debug.Log("监听立即注册按钮 LogOnViewBtnToRegClick");
    }

    public void OpenLogOnView()
    {
        m_LogOnView = WindowUIMgr.Instance.OpenWindow(WindowUIType.LogOn).GetComponent<UILogOnView>();
    }

    public override void Dispose()
    {
        base.Dispose();
        EventDispatcher.Instance.RemoveBtnEventListener("UILogOnView_Btn_Logon", LogOnViewBtnLogOnClick);
        EventDispatcher.Instance.RemoveBtnEventListener("UILogOnView_Btn_ToRegister", LogOnViewBtnToRegClick);
    }
}
