using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 事件监听 观察者模式
/// </summary>
public class EventDispatcher : Singleton<EventDispatcher>
{
    //委托原型
    public delegate void OnActionHandler(byte[] buffer);

    //委托字典
    private Dictionary<ushort, List<OnActionHandler>> dic = new Dictionary<ushort, List<OnActionHandler>>();

    /// <summary>
    /// 添加监听
    /// </summary>
    /// <param name="protoCode"></param>
    /// <param name="handler"></param>
    public void AddEventListener(ushort protoCode,OnActionHandler handler)
    {
        if(dic.ContainsKey(protoCode))
        {
            dic[protoCode].Add(handler);
        }
        else
        {
            List<OnActionHandler> lstHandler = new List<OnActionHandler>();
            lstHandler.Add(handler);
            dic[protoCode] = lstHandler;
        }
    }

    /// <summary>
    /// 移除监听
    /// </summary>
    /// <param name="protoCode"></param>
    /// <param name="handler"></param>
    public void RemoveEventListener(ushort protoCode,OnActionHandler handler)
    {
        if(dic.ContainsKey(protoCode))
        {
            List<OnActionHandler> lstHandler = dic[protoCode];
            lstHandler.Remove(handler);
            if(lstHandler.Count == 0)
            {
                dic.Remove(protoCode);
            }
        }
    }

    /// <summary>
    /// 派发协议
    /// </summary>
    /// <param name="protoCode"></param>
    /// <param name="buffer"></param>
    public void Dispatch(ushort protoCode , byte[] buffer)
    {
        if(dic.ContainsKey(protoCode))
        {
            List<OnActionHandler> lstHandler = dic[protoCode];
            if(lstHandler != null && lstHandler.Count >0)
            {
                for (int i = 0; i < lstHandler.Count; i++)
                {
                    if(lstHandler[i]!=null)
                    {
                        lstHandler[i](buffer);
                    }
                }
            }
        }
    }


    //====================================================================================================

    //按钮的点击事件的委托和原型
    public delegate void OnBtnClickHandler(params object[] param);
    private Dictionary<string, List<OnBtnClickHandler>> dic_ButtonClick = new Dictionary<string, List<OnBtnClickHandler>>();

    /// <summary>
    /// 添加按钮点击监听
    /// </summary>
    /// <param name="btnKey"></param>
    /// <param name="handler"></param>
    public void AddBtnEventListener(string btnKey, OnBtnClickHandler handler)
    {
        if (dic_ButtonClick.ContainsKey(btnKey))
        {
            dic_ButtonClick[btnKey].Add(handler);
        }
        else
        {
            List<OnBtnClickHandler> lstHandler = new List<OnBtnClickHandler>();
            lstHandler.Add(handler);
            dic_ButtonClick[btnKey] = lstHandler;
        }
    }

    /// <summary>
    /// 移除按钮点击监听
    /// </summary>
    /// <param name="protoCode"></param>
    /// <param name="handler"></param>
    public void RemoveBtnEventListener(string btnKey, OnBtnClickHandler handler)
    {
        if (dic_ButtonClick.ContainsKey(btnKey))
        {
            List<OnBtnClickHandler> lstHandler = dic_ButtonClick[btnKey];
            lstHandler.Remove(handler);
            if (lstHandler.Count == 0)
            {
                dic_ButtonClick.Remove(btnKey);
            }
        }
    }

    /// <summary>
    /// 派发按钮点击
    /// </summary>
    /// <param name="protoCode"></param>
    /// <param name="buffer"></param>
    public void DispatchBtn(string btnKey, params object[] param)
    {
        if (dic_ButtonClick.ContainsKey(btnKey))
        {
            List<OnBtnClickHandler> lstHandler = dic_ButtonClick[btnKey];
            if (lstHandler != null && lstHandler.Count > 0)
            {
                for (int i = 0; i < lstHandler.Count; i++)
                {
                    if (lstHandler[i] != null)
                    {
                        lstHandler[i](param);
                    }
                }
            }
        }
    }
}
