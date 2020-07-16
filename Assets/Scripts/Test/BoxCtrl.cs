using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCtrl : MonoBehaviour
{
    /// <summary>
    /// ターゲットのポジション
    /// </summary>
    private Vector3 m_TargetPos = Vector3.zero;

    /// <summary>
    /// 移動速度
    /// </summary>
    private float m_Speed = 1F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = gameObject.transform.localPosition + new Vector3(0, -1 * m_Speed*Time.deltaTime, 0);

        #region 移動操作
        /*
        if(Input.GetMouseButtonUp(0) || Input.touchCount == 1)
        {
            Debug.Log("Click");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if(Physics.Raycast(ray,out hitInfo))
            {
                if(hitInfo.collider.gameObject.name.Equals("Ground",System.StringComparison.CurrentCultureIgnoreCase))
                {
                    m_TargetPos = hitInfo.point;                   
                }
            }
        }

        //ターゲットのポジションもう検証できた
        //もしターゲットのポジションと原点同じじゃない
        if (m_TargetPos != Vector3.zero)
        {
            //Debug.DrawLine(Camera.main.transform.position, m_TargetPos);

            if(Vector3.Distance(m_TargetPos,transform.position)>0.1f)
            {
                transform.LookAt(m_TargetPos);
                transform.Translate(Vector3.forward * Time.deltaTime * m_Speed);
            }
        }
        */
        #endregion

    }

    private void OnCollisionEnter(Collision info)
    {
        Debug.Log("OnCollisionEnter！！！" + info.collider.gameObject.name);
    }

    private void OnCollisionStay(Collision info)
    {
        Debug.Log("OnCollisionStay！！！" + info.collider.gameObject.name);
    }

    private void OnCollisionExit(Collision info)
    {
        Debug.Log("OnCollisionExit！！！" + info.collider.gameObject.name);
    }

    private void OnTriggerEnter(Collider info)
    {
        Debug.Log("OnTriggerEnter！！！" + info.gameObject.name);
    }

    private void OnTriggerStay(Collider info)
    {
        Debug.Log("OnTriggerStay！！！" + info.gameObject.name);
    }

    private void OnTriggerExit(Collider info)
    {
        Debug.Log("OnTriggerExit！！！" + info.gameObject.name);
    }
}
