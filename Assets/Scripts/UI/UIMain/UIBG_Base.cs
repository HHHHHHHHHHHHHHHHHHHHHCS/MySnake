using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBG_Base : MonoBehaviour
{
    public bool IsShow()
    {
        return gameObject.activeSelf;
    }

    public void ShowHide(bool isShow = false)
    {
        if(IsShow()==isShow)
        {
            gameObject.SetActive(isShow);
        }
    }

    public void DestroySelf(float time = 0)
    {
        if(time!=0)
        {
            Destroy(gameObject,time);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
