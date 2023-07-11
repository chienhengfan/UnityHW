using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprawler : MonoBehaviour
{
    private static EnemySprawler _instance = null;
    public  static EnemySprawler Instance() { return _instance; }
    private GameObject enemyObject;
    public string enemyName = "Mummy_Mon";
    private List<GameObject> _enemies = new List<GameObject>();
    public int enemyNumber;
    void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        GenerateEnemies(enemyNumber);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) { GenerateEnemies(enemyNumber); }
    }

    public void RemoveEnemy(GameObject enemyShouldRemoved)
    {
        ObjectPool pool = ObjectPool.Instance();
        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i] == enemyShouldRemoved)
            {
                _enemies.RemoveAt(i);
                pool.UnLoadObjectToPool(enemyShouldRemoved);
            }
        }
    }

    public void GenerateEnemies(int num)
    {
        enemyObject = (enemyObject == null) ? ResourceLoader.Instance().LoadGameObject(enemyName) : enemyObject;

        for (int i = 0; i < num; i++)
        {
            Vector3 vecdir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-0.5f, 0.5f));

            if (vecdir.magnitude == 0.0f)
            {
                vecdir.x = 0.7f;
            }
            vecdir.Normalize();
            enemyObject.transform.position = vecdir * Random.Range(1f, 5f);
            _enemies[i] = enemyObject;

        }
    }
}
