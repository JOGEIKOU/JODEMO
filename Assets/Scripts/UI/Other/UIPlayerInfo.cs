using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerInfo : MonoBehaviour
{
    [SerializeField]
    private UILabel lblNickName;

    [SerializeField]
    private UISprite sprHP;

    public static UIPlayerInfo Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if(GlobalInit.Instance.CurrPlayer != null)
        {
            GlobalInit.Instance.CurrPlayer.OnRoleHurt = MainPlayerHurt;
        }
        
    }

    private void MainPlayerHurt()
    {
        sprHP.fillAmount = (float)(GlobalInit.Instance.CurrPlayer.CurrRoleInfo.CurrHP / GlobalInit.Instance.CurrPlayer.CurrRoleInfo.MaxHP);
    }

    public void SetPlayerInfo()
    {
        lblNickName.text = GlobalInit.Instance.CurrPlayer.CurrRoleInfo.NickName;

    }

}
