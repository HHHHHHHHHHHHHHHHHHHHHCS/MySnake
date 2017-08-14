using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Instance_Base<MapManager>
{

    private void Awake()
    {
        Instance = this;
    }

    public static MapManager CreateMap()
    {
        var prefab = Resources.Load<MapManager>(PrefabsName.mainMap);
        var map = Instantiate(prefab);
        return map;
    }
}
