using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRegCtrl : UIWindowBase
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
    /// password 確認用
    /// </summary>
    [SerializeField]
    private UIInput m_InputPwd2;

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
            case "btnReg":
                Reg();
                break;
            case "btnToLogOn":
                BtnToLogOn();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// ログインウィンドウズに行く
    /// </summary>
    private void BtnToLogOn()
    {
        Close();
        m_NextOpenWindow = WindowUIType.LogOn;
    }

    private void Reg()
    {
        string nickName = m_InputNickName.value.Trim();
        string pwd = m_InputPwd.value.Trim();
        string pwd2 = m_InputPwd2.value.Trim();

        if(string.IsNullOrEmpty(nickName))
        {
            this.m_LblTip.text = "ニックネームを入力してください。";
            return;
        }

        if (string.IsNullOrEmpty(pwd))
        {
            this.m_LblTip.text = "パスワードを入力してください。";
            return;
        }

        if (string.IsNullOrEmpty(pwd2))
        {
            this.m_LblTip.text = "パスワードを再入力してください。";
            return;
        }

        if(pwd != pwd2)
        {
            m_LblTip.text = "パスワードを正しく入力してください。";
        }

        PlayerPrefs.SetString(GlobalInit.MMO_NICKNAME, nickName);
        PlayerPrefs.SetString(GlobalInit.MMO_PWD, pwd);

        SceneMgr.Instance.LoadToCity();
    }
}
