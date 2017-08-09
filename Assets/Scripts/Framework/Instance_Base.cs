using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance_Base<T> : MonoBehaviour where T : Instance_Base<T>
{
    public static T Instance
    {
        get;
        protected set;
    }
}
