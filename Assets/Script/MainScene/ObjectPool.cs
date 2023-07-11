using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public class GameObjectData
    {
        public GameObject dataObject;
        public bool IsUsing;
    }

    public class ListObjectData
    {
        public object dataSource;
        public List<GameObjectData> poolDataList;
    }

    private static ObjectPool _instane = null;
    public static ObjectPool Instance() { return _instane; }
    private ListObjectData pool;

    private void Awake()
    {
        _instane = this;
    }

    public void InitObjectPool(int number, GameObject go)
    {
        pool = new ListObjectData();
        pool.dataSource = go;
        pool.poolDataList = new List<GameObjectData>();
        for(int i = 0; i < number; i++)
        {
            GameObject tempObject = GameObject.Instantiate(go) as GameObject;
            GameObjectData data = new GameObjectData();
            data.dataObject = tempObject;
            data.IsUsing = false;

            tempObject.SetActive(false);
            pool.poolDataList.Add(data);
        }
    }

    public GameObject LoadObjectFromPool()
    {
        int count = pool.poolDataList.Count;
        for(int i = 0; i < count; i++)
        {
            GameObjectData data = pool.poolDataList[i];
            if (data.IsUsing) { continue; }

            data.IsUsing = true;
            return data.dataObject;
        }
        return null;
    }

    public void UnLoadObjectToPool(GameObject gameObject)
    {
        int count = pool.poolDataList.Count;
        for (int i = 0; i < count; i++)
        {
            GameObjectData data = pool.poolDataList[i];
            if (data.dataObject == gameObject)
            {
                data.dataObject.SetActive(false);
                data.IsUsing = false;
                return;
            }
        }
    }
}
