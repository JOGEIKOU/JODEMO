using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogOnCtrl : UIWindowBase
{
    /// <summary>
    /// nickname
    /// </summary>
    [SerializeField]
    private UIInput m_InputNickName;

    /// <summary>
    /// password
    /// </summary>
    [SerializeField]
    private UIInput m_InputPwd;

    /// <summary>
    /// 注意用メッセージ
    /// </summary>
    [SerializeField]
    private UILabel m_LblTip;

    /// <summary>
    /// BaseUIからオーバーライドBtnClick
    /// </summary>
    /// <param name="go"></param>
    protected override void OnBtnClick(GameObject go)
    {
        switch (go.name)
        {
            case "btnStart":
                Logon();
                break;
            case "btnToReg":
                BtnToReg();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 登録ボタンメソッド
    /// </summary>
    private void BtnToReg()
    {
        Close();
        m_NextOpenWindow = WindowUIType.Reg;
    }

    private void Logon()
    {
        string nickName = m_InputNickName.value.Trim();
        string pwd = m_InputPwd.value.Trim();

        if (string.IsNullOrEmpty(nickName))
        {
            this.m_LblTip.text = "ニックネームを入力してください。";
            return;
        }

        if (string.IsNullOrEmpty(pwd))
        {
            this.m_LblTip.text = "パスワードを入力してください。";
            return;
        }

        string oldNickName = PlayerPrefs.GetString(GlobalInit.MMO_NICKNAME);
        string oldPwd = PlayerPrefs.GetString(GlobalInit.MMO_PWD);

        if(oldNickName != nickName || oldPwd != pwd)
        {
            m_LblTip.text = "ニックネームまたはパスワードが間違いました。";
            return;
        }

        GlobalInit.Instance.CurrRoleNickName = nickName;

        SceneMgr.Instance.LoadToCity();
    }
}
