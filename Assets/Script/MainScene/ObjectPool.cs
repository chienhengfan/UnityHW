using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public class GameObjectData
    {
        public GameObject gameobject;
        public bool IsUsing;
    }

    private ObjectPool _instane = null;
    public ObjectPool Instance() { return _instane; }
    private List<GameObjectData> poolList;

    private void Awake()
    {
        _instane = this;
    }

    public void InitObjectPool(int number, GameObject gameobject)
    {
        poolList = new List<GameObjectData>();
        for(int i = 0; i < number; i++)
        {
            GameObject tempObject = GameObject.Instantiate(gameobject) as GameObject;
            GameObjectData data = new GameObjectData();
            data.gameobject = tempObject;
            data.IsUsing = false;

            tempObject.SetActive(false);
            poolList.Add(data);
        }
    }

    public GameObject LoadObjectFromPool()
    {
        int count = poolList.Count;
        for(int i = 0; i < count; i++)
        {
            GameObjectData data = poolList[i];
            if (data.IsUsing) { continue; }

            data.IsUsing = true;
            return data.gameobject;
        }
        return null;
    }
}
