using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleCtrl : MonoBehaviour
{
    /// <summary>
    /// ターゲットのポジション
    /// </summary>
    private Vector3 m_TargetPos = Vector3.zero;

    /// <summary>
    /// プレイヤーコントローラー
    /// </summary>
    private CharacterController m_CharacterController;

    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float m_Speed = 10F;

    /// <summary>
    /// プレイヤー回転速度
    /// </summary>
    private float m_RotationSpeed = 0.2f;

    /// <summary>
    /// ターゲットのクォータニオン
    /// </summary>
    private Quaternion m_TargetQuaternion;



    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetMouseButtonUp(0))
        //{
        //    GameObject[] boxobjs = GameObject.FindGameObjectsWithTag("Box");
        //    if (boxobjs != null && boxobjs.Length>0)
        //    {
        //        for (int i = 0; i < boxobjs.Length; i++)
        //        {
        //            boxobjs[i].transform.localPosition = boxobjs[i].transform.localPosition + new Vector3(0, 0, 1);
        //        }             
        //    }
        //}
        //return;

        if (m_CharacterController == null) return;

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Click");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.name.Equals("Ground", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    m_TargetPos = hitInfo.point;
                    m_RotationSpeed = 0f;
                }
            }
        }

        //右クリック　もの拾い
        //if(Input.GetMouseButtonUp(1))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit[] hitArr = Physics.RaycastAll(ray , Mathf.Infinity, 1 << LayerMask.NameToLayer("Item"));

        //    if(hitArr.Length > 0)
        //    {
        //        for (int i = 0; i < hitArr.Length; i++)
        //        {
        //            Debug.Log(hitArr[i].collider.gameObject.name + "を見つけました。");
        //        }            
        //    }

        //    //if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Item")))
        //    //{
        //    //    Debug.Log(hit.collider.gameObject.name + "を見つけた");
        //    //}           
        //}

        if (Input.GetMouseButtonUp(1))
        {
            Collider[] colliderArr = Physics.OverlapSphere(transform.position, 1, 1 << LayerMask.NameToLayer("Item"));
            if (colliderArr.Length > 0)
            {
                for (int i = 0; i < colliderArr.Length; i++)
                {
                    Debug.Log(colliderArr[i].gameObject.name + "を見つけました。");
                }
            }
        }



        //地面と当たる
        if(!m_CharacterController.isGrounded)
        {
            m_CharacterController.Move((transform.position + new Vector3(0, -1000, 0)) - transform.position);
        }


        //もしターゲットのポジションと原点同じじゃない
        if (m_TargetPos != Vector3.zero)
        {
            if (Vector3.Distance(m_TargetPos, transform.position) > 0.1f)
            {
                Vector3 direction = m_TargetPos - transform.position;
                direction = direction.normalized;//ノーマライズ
                direction = direction * Time.deltaTime * m_Speed;
                direction.y = 0f;
                //キャラクター回転（ターゲット向け）
                if (m_RotationSpeed<=1)
                {
                    m_RotationSpeed += 5f * Time.deltaTime;
                    m_TargetQuaternion = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Lerp(transform.rotation, m_TargetQuaternion, m_RotationSpeed);
                }
                m_CharacterController.Move(direction);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
    }

}
