using UnityEngine;

public class LoadResources 
{
    public static Object Load(string path)
    {
        return Load<Object>(path);
    }

    public static T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }
}
