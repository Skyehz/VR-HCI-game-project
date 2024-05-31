using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_rank : MonoBehaviour
{
    //点击按钮，显示image
     public void Click()
    {
        gameObject.SetActive(true); 
    }

    public void CloseRank()
    {
        gameObject.SetActive(false); 
    }
}
