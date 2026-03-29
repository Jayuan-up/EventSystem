using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人：
//功能说明：
//***************************************** 
public class EventCenter
{
    private static Dictionary<EventType , Delegate> m_EventTable = new Dictionary<EventType , Delegate>();

    #region 添加监听

    private static void OnListenerAdding(EventType eventType , Delegate callBack)
    {
        if (!m_EventTable.ContainsKey(eventType))
        {
            m_EventTable.Add(eventType, null);
        }
        Delegate d = m_EventTable[eventType];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("尝试为事件{0}添加不同类型的委托，当前事件所对应的委托是{1}，要添加的委托类型为{2}", eventType, d.GetType(), callBack.GetType()));
        }
    }

    /// <summary>
    /// 无参的添加监听的方法
    /// </summary>
    /// <exception cref="Exception"></exception>
    public static void AddListener(EventType eventType , CallBack callBack)
    {
        OnListenerAdding(eventType , callBack);
        //添加监听
        m_EventTable[eventType] = (CallBack)m_EventTable[eventType] + callBack;
    }
    /// <summary>
    /// 一个参数的添加监听的方法
    /// </summary>
    /// <exception cref="Exception"></exception>
    public static void AddListener<T>(EventType eventType , CallBack<T> callBack)
    {
        OnListenerAdding(eventType, callBack);
        //添加监听
        m_EventTable[eventType] = (CallBack<T>)m_EventTable[eventType] + callBack;
    }
    /// <summary>
    /// 两个参数的添加监听的方法
    /// </summary>
    /// <exception cref="Exception"></exception>
    public static void AddListener<T,X>(EventType eventType, CallBack<T,X> callBack)
    {
        OnListenerAdding(eventType, callBack);
        //添加监听
        m_EventTable[eventType] = (CallBack<T,X>)m_EventTable[eventType] + callBack;
    }
    /// <summary>
    /// 三个参数的添加监听的方法
    /// </summary>
    /// <exception cref="Exception"></exception>
    public static void AddListener<T, X,Y>(EventType eventType, CallBack<T, X, Y> callBack)
    {
        OnListenerAdding(eventType, callBack);
        //添加监听
        m_EventTable[eventType] = (CallBack<T, X, Y>)m_EventTable[eventType] + callBack;
    }
    /// <summary>
    /// 四个参数的添加监听的方法
    /// </summary>
    /// <exception cref="Exception"></exception>
    public static void AddListener<T, X, Y, Z>(EventType eventType, CallBack<T, X, Y, Z> callBack)
    {
        OnListenerAdding(eventType, callBack);
        //添加监听
        m_EventTable[eventType] = (CallBack<T, X, Y, Z>)m_EventTable[eventType] + callBack;
    }
    /// <summary>
    /// 五个参数的添加监听的方法
    /// </summary>
    /// <exception cref="Exception"></exception>
    public static void AddListener<T, X, Y, Z, W>(EventType eventType, CallBack<T, X, Y, Z, W> callBack)
    {
        OnListenerAdding(eventType, callBack);
        //添加监听
        m_EventTable[eventType] = (CallBack<T, X, Y, Z, W>)m_EventTable[eventType] + callBack;
    }
    #endregion

    #region 移除监听

    private static void OnListenerRemoving(EventType eventType , Delegate callBack)
    {
        if (m_EventTable.ContainsKey(eventType))
        {
            Delegate d = m_EventTable[eventType];
            if (d == null)
            {
                throw new Exception(string.Format("移除监听错误：事件{0}没有对应的委托", eventType));
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("移除监听错误：尝试为事件{0}移除不同类型的委托,当前委托类型为{1}，要移除的委托类型为{2}", eventType, d.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("移除监听错误：没有事件码{0}", eventType));
        }
    }

    private static void OnListenerRemoved(EventType eventType)
    {
        if (m_EventTable[eventType] == null)
        {
            m_EventTable.Remove(eventType);
        }
    }

    /// <summary>
    /// 无参的移除监听的方法
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener(EventType eventType, CallBack callBack)
    {
        OnListenerRemoving(eventType, callBack);
        //移除监听
        m_EventTable[eventType] = (CallBack)m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }

    /// <summary>
    /// 一个参数的移除监听的方法
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener<T>(EventType eventType, CallBack<T> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        //移除监听
        m_EventTable[eventType] = (CallBack<T>)m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }
    /// <summary>
    /// 两个参数的移除监听的方法
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener<T,X>(EventType eventType, CallBack<T,X> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        //移除监听
        m_EventTable[eventType] = (CallBack<T,X>)m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }
    /// <summary>
    /// 三个参数的移除监听的方法
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener<T, X, Y>(EventType eventType, CallBack<T, X, Y> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        //移除监听
        m_EventTable[eventType] = (CallBack<T, X, Y>)m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }
    /// <summary>
    /// 四个参数的移除监听的方法
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener<T, X, Y, Z>(EventType eventType, CallBack<T, X, Y, Z> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        //移除监听
        m_EventTable[eventType] = (CallBack<T, X, Y, Z>)m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }
    /// <summary>
    /// 五个参数的移除监听的方法
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener<T, X, Y, Z, W>(EventType eventType, CallBack<T, X, Y, Z, W> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        //移除监听
        m_EventTable[eventType] = (CallBack<T, X, Y, Z, W>)m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }
    #endregion

    #region 广播
    /// <summary>
    /// 无参的广播监听,只需要传递一个事件码
    /// </summary>
    /// <param name="eventType"></param>
    public static void Boradcast(EventType eventType)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack callBack = d as CallBack;
            if (callBack != null)
            {
                callBack();
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应的委托具有不同类型",eventType));
            }
        }
    }
    /// <summary>
    /// 一个参数的广播监听,只需要传递一个事件码
    /// </summary>
    /// <param name="eventType"></param>
    public static void Boradcast<T>(EventType eventType , T arg1)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack<T> callBack = d as CallBack<T>;
            if (callBack != null)
            {
                callBack(arg1);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应的委托具有不同类型", eventType));
            }
        }
    }
    /// <summary>
    /// 两个参数的广播监听,只需要传递一个事件码
    /// </summary>
    /// <param name="eventType"></param>
    public static void Boradcast<T, X>(EventType eventType, T arg1, X arg2)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack<T,X> callBack = d as CallBack<T,X>;
            if (callBack != null)
            {
                callBack(arg1,arg2);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应的委托具有不同类型", eventType));
            }
        }
    }
    /// <summary>
    /// 三个参数的广播监听,只需要传递一个事件码
    /// </summary>
    /// <param name="eventType"></param>
    public static void Boradcast<T, X, Y>(EventType eventType, T arg1, X arg2, Y arg3)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y> callBack = d as CallBack<T, X, Y>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应的委托具有不同类型", eventType));
            }
        }
    }
    /// <summary>
    /// 四个参数的广播监听,只需要传递一个事件码
    /// </summary>
    /// <param name="eventType"></param>
    public static void Boradcast<T, X, Y, Z>(EventType eventType, T arg1, X arg2, Y arg3 , Z arg4)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y, Z> callBack = d as CallBack<T, X, Y, Z>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3 ,arg4);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应的委托具有不同类型", eventType));
            }
        }
    }
    /// <summary>
    /// 五个参数的广播监听,只需要传递一个事件码
    /// </summary>
    /// <param name="eventType"></param>
    public static void Boradcast<T, X, Y, Z, W>(EventType eventType, T arg1, X arg2, Y arg3, Z arg4, W arg5)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y, Z, W> callBack = d as CallBack<T, X, Y, Z, W>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3, arg4, arg5);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误：事件{0}对应的委托具有不同类型", eventType));
            }
        }
    }
    #endregion
}
