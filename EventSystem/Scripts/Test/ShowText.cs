using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//*****************************************
//创建人：
//功能说明：
//***************************************** 
public class ShowText : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
        EventCenter.AddListener<string, string, float, int, bool>(EventType.ShowText, Show);
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener<string,string,float,int ,bool>(EventType.ShowText, Show);
    }
    public void Show(string str ,string str1 , float a , int b, bool c)
    {
        gameObject.SetActive(true);
        GetComponent<Text>().text = str + str1 + a + b + c;
    }
}
