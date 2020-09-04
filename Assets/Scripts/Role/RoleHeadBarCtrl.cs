using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleHeadBarCtrl : MonoBehaviour
{
    /// <summary>
    /// ニックネーム
    /// </summary>
    [SerializeField]
    private UILabel lblNickName;

    /// <summary>
    /// HPエフェクト
    /// </summary>
    [SerializeField]
    private HUDText hudText;

    [SerializeField]
    private UISlider pbHP;


    private Transform m_Target;


    public void Init(Transform target,string nickName,bool isShowHPBar= false)
    {
        m_Target = target;
        lblNickName.text = nickName;

        NGUITools.SetActive(pbHP.gameObject,isShowHPBar);
    }

    private void Update()
    {
        if (Camera.main == null || UICamera.mainCamera) return;

        //ワールド座標ー＞ビュー座標
        Vector3 pos = Camera.main.WorldToViewportPoint(m_Target.position);
        //ビュー座標ー＞UIカメラの世界座標
        Vector3 uiPos = UICamera.mainCamera.ViewportToWorldPoint(pos);

        gameObject.transform.position = uiPos;
    }

    /// <summary>
    /// ダメージ数字エフェクト
    /// </summary>
    /// <param name="hurtValue"></param>
    public void SetHUDText(int hurtValue)
    {
        hudText.Add(string.Format("-{0}",hurtValue) , Color.red, 0.1f);
    }

}
