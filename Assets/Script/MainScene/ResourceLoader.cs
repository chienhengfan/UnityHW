using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : MonoBehaviour
{
    private static ResourceLoader _instance = null;
    public static ResourceLoader Instance() { return _instance; }
    private void Awake() { _instance = this; }

    public GameObject LoadGameObject(string name)
    {
        GameObject go = Resources.Load(name) as GameObject;
        return go;
    }

    public IEnumerator LoadGameObjectAsync(string name, System.Action<Object> act)
    {
        ResourceRequest resource = Resources.LoadAsync(name);
        yield return resource;

        if(resource.isDone && resource.asset != null) { act(resource.asset); }
    }
}
