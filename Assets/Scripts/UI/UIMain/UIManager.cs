using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Instance_Base<UIManager>
{
    private UIBG_Base nowBG;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //Init();
    }


    private void Init()
    {
        nowBG = InstantiateObject<UIBG_Base>(UIName.prefab_loginBG);
    }

    public void JumpBG(string path)
    {
        if (nowBG != null)
        {
            nowBG.DestroySelf();
        }
        nowBG = InstantiateObject<UIBG_Base>(path);
    }

    private T LoadPrefab<T>(string path) where T : Object
    {
        return LoadResources.Load<T>(path);
    }

    private T InstantiateObject<T>(string path, Transform parent = null) where T : Object
    {
        parent = parent ? parent : transform;
        return Instantiate(LoadPrefab<T>(path), parent);
    }

    public TipWindowUI CreateTipWindow()
    {
        return TipWindowUI.Create(transform);
    }

    public JoystickEvent CreateJoystick(Transform parent)
    {

        var jEvent = InstantiateObject<JoystickEvent>(UIName.prefab_Joystick);

        return jEvent;
    }
}
