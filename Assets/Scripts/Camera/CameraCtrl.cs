using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public static CameraCtrl Instance;

    /// <summary>
    /// カメラの上下コントロール
    /// </summary>
    [SerializeField]
    private Transform m_CameraUpAndDown;

    /// <summary>
    /// 物を拡大/縮小（カメラの中に）
    /// </summary>
    [SerializeField]
    private Transform m_CameraZoomContainer;

    /// <summary>
    /// カメラコンテナ
    /// </summary>
    [SerializeField]
    private Transform m_CameraContainer;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Init()
    {
        m_CameraUpAndDown.transform.localEulerAngles = new Vector3(0,0,Mathf.Clamp(m_CameraUpAndDown.transform.localEulerAngles.z, 35f, 80f));
    }

    /// <summary>
    /// カメラ回転設置
    /// </summary>
    /// <param name="type">0 = ←、1＝→</param>
    public void SetCameraRotate(int type)
    {
        transform.Rotate(0, 20 * Time.deltaTime * (type == 0?-1:1), 0);
    }

    /// <summary>
    /// カメラ上下
    /// </summary>
    /// <param name="type">0 = ↑、1＝↓</param>
    public void SetCameraUpAndDown(int type)
    {
        m_CameraUpAndDown.transform.Rotate(15 * Time.deltaTime * (type == 0 ? -1 : 1),0,0);
        m_CameraUpAndDown.transform.localEulerAngles = new Vector3(Mathf.Clamp(m_CameraUpAndDown.transform.localEulerAngles.x, 35f, 50f), 0, 0);
    }

    /// <summary>
    /// カメラの拡大と縮小
    /// </summary>
    /// <param name="type">0 = 拡大、1 = 縮小</param>
    public void SetCameraZoom(int type)
    {
        m_CameraContainer.Translate(Vector3.forward * 10 * Time.deltaTime * (type == 1 ? -1 : 1));
        m_CameraContainer.localPosition = new Vector3(0, 0, Mathf.Clamp(m_CameraContainer.localPosition.z, -5f, 5f));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pos"></param>
    public void AutoLookAt(Vector3 pos)
    {
        m_CameraContainer.LookAt(pos);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 15f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 14f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 12f);
    }
}
