using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIBG_Base : MonoBehaviour
{

    public Button AddButtonListener(Transform parent, string path, UnityAction call)
    {
        var btn = parent.Find(path).GetComponent<Button>();
        btn.onClick.AddListener(call);
        return btn;
    }

    public Button[] AddButtonsListener(Transform parent, string[] paths, UnityAction[] calls)
    {
        Button[] btns = null;
        if (paths != null && calls != null
            && paths.Length != 0 && paths.Length == calls.Length)
        {
            btns = new Button[paths.Length];
            for (int i = 0; i < paths.Length; i++)
            {
                btns[i] = AddButtonListener(parent, paths[i], calls[i]);
            }
        }
        else
        {
            Debug.LogError("AddButtonsListener() >:The parameter Number does not match ");
        }
        return btns;
    }

    public bool IsShow()
    {
        return gameObject.activeSelf;
    }

    public void ShowHide(bool isShow = false)
    {
        if (IsShow() == isShow)
        {
            gameObject.SetActive(isShow);
        }
    }

    public void DestroySelf(float time = 0)
    {
        if (time != 0)
        {
            Destroy(gameObject, time);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
