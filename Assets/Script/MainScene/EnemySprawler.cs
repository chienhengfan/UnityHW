using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprawler : MonoBehaviour
{
    private static EnemySprawler _instance = null;
    public  static EnemySprawler Instance() { return _instance; }
    private GameObject enemyObject;
    public string enemyName = "Mummy_Mon";
    private List<GameObjectData> _enemies;
    public int enemyNumber;
    void Awake()
    {
        _instance = this;       
    }

    private void Start()
    {
        StartCoroutine(ResourceLoader.Instance().LoadGameObjectAsync(enemyName, FinishAsynicLoadGameObject));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) { GenerateEnemies(enemyNumber); }
    }

    void FinishAsynicLoadGameObject(Object o)
    {
        enemyObject = o as GameObject;
        ObjectPool.Instance().InitObjectPool(enemyNumber, enemyObject);
        Debug.Log(enemyObject);
    }
    public void RemoveEnemy(GameObject enemyShouldRemoved)
    {
        ObjectPool pool = ObjectPool.Instance();
        for (int i = 0; i < _enemies.Count; i++)
        {
            GameObjectData data = _enemies[i];
            if (data.dataObject == enemyShouldRemoved)
            {
                _enemies.RemoveAt(i);
                //data.dataObject.SetActive(false);
                pool.UnLoadObjectToPool(enemyShouldRemoved);
            }
        }
    }

    public void GenerateEnemies(int num)
    {
        //enemyObject = (enemyObject == null) ? ResourceLoader.Instance().LoadGameObject(enemyName) : enemyObject;

        // if I don't kill all enemy and want to generate enemy, bug will appear because object reference is null
        _enemies = (_enemies == null) ? new List<GameObjectData>() : _enemies;

        ObjectPool pool = ObjectPool.Instance(); 
        for (int i = 0; i < num; i++)
        {
            GameObjectData data = pool.LoadObjectFromPool();
            GameObject dataObject = data.dataObject;

            Vector3 vecdir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-0.5f, 0.5f));

            if (vecdir.magnitude == 0.0f)
            {
                vecdir.x = 0.7f;
            }
            vecdir.Normalize();
            dataObject.transform.position = vecdir * Random.Range(1f, 5f);
            dataObject.SetActive(true);
            _enemies.Add(data);

        }
    }
}
