using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppMain : MonoBehaviour
{
    void Start()
    {
        Debuger.EnableLog = true;

        this.LogWarning("打豆豆");
        this.LogError("睡觉");
        this.Log(Debuger.LogFilePath);
    }
}
