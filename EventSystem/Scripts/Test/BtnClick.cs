using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//*****************************************
//创建人：
//功能说明：
//***************************************** 
public class BtnClick : MonoBehaviour
{

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            EventCenter.Boradcast(EventType.ShowText , "我是编程高手" , "哈哈哈", 11.1f ,2, true);
        });
    }
}
