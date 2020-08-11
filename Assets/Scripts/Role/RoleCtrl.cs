using System;
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


        if(CameraCtrl.Instance != null)
        {
            CameraCtrl.Instance.Init();
        }

        if(FingerEvent.Instance != null)
        {
            FingerEvent.Instance.OnFingerDrag += OnFingerDrag;
            FingerEvent.Instance.OnZoom += OnZoom;
            FingerEvent.Instance.OnPlayerClick += OnPlayerClickGround;
        }
    }

    private void OnFingerDrag(FingerEvent.FingerDir obj)
    {
        switch (obj)
        {
            case FingerEvent.FingerDir.Left:
                CameraCtrl.Instance.SetCameraRotate(0);
                break;
            case FingerEvent.FingerDir.Right:
                CameraCtrl.Instance.SetCameraRotate(1);
                break;
            case FingerEvent.FingerDir.Up:
                CameraCtrl.Instance.SetCameraUpAndDown(1);
                break;
            case FingerEvent.FingerDir.Down:
                CameraCtrl.Instance.SetCameraUpAndDown(0);
                break;
            default:
                break;
        }
    }

    private void OnPlayerClickGround()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray,out hitInfo))
        {
            if(hitInfo.collider.gameObject.name.Equals("Ground",System.StringComparison.CurrentCultureIgnoreCase))
            {
                m_TargetPos = hitInfo.point;
                m_RotationSpeed = 0;
            }
        }

    }

    private void OnZoom(FingerEvent.ZoomType obj)
    {
        switch (obj)
        {
            case FingerEvent.ZoomType.In:
                CameraCtrl.Instance.SetCameraZoom(0);
                break;
            case FingerEvent.ZoomType.Out:
                CameraCtrl.Instance.SetCameraZoom(1);
                break;
        }
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
        if (Input.GetMouseButtonUp(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit[] hitArr = Physics.RaycastAll(ray, Mathf.Infinity, 1 << LayerMask.NameToLayer("Item"));

            //if (hitArr.Length > 0)
            //{
            //    for (int i = 0; i < hitArr.Length; i++)
            //    {
            //        Debug.Log(hitArr[i].collider.gameObject.name + "を見つけました。");
            //    }
            //}

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Item")))
            {
                BoxCtrl boxCtrl = hit.collider.GetComponent<BoxCtrl>();
                if(boxCtrl != null)
                {
                    boxCtrl.Hit();
                }
                Debug.Log(hit.collider.gameObject.name + "を見つけた");
            }
        }

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

        CameraAutoFollow();
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, 1);
    //}

    private void CameraAutoFollow()
    {
        if (CameraCtrl.Instance == null) return;

        CameraCtrl.Instance.transform.position = gameObject.transform.position;
        CameraCtrl.Instance.AutoLookAt(gameObject.transform.position);

        if (Input.GetKey(KeyCode.A))
        {
            CameraCtrl.Instance.SetCameraRotate(0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CameraCtrl.Instance.SetCameraRotate(1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            CameraCtrl.Instance.SetCameraUpAndDown(0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            CameraCtrl.Instance.SetCameraUpAndDown(1);
        }

        if (Input.GetKey(KeyCode.I))
        {
            CameraCtrl.Instance.SetCameraZoom(-1);
        }
        else if (Input.GetKey(KeyCode.L))
        {
            CameraCtrl.Instance.SetCameraZoom(1);
        }
    }

    private void OnDestroy()
    {
        if(FingerEvent.Instance != null)
        {
            FingerEvent.Instance.OnFingerDrag -= OnFingerDrag;
            FingerEvent.Instance.OnZoom -= OnZoom;
            FingerEvent.Instance.OnPlayerClick -= OnPlayerClickGround;
        }
    }

}
