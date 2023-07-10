using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprawler : MonoBehaviour
{
    public Object enemyObject;
    private GameObject[] _enemies;
    public int enemyNumber;
    void Start()
    {
        GenerateEnemies(enemyNumber);
    }

    public void RemoveEnemy(GameObject ey)
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] == ey)
            {
                _enemies[i] = null;
            }
        }
    }

    public void GenerateEnemies(int num)
    {
        _enemies = new GameObject[num];
        for (int i = 0; i < num; i++)
        {
            Vector3 vecdir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-0.5f, 0.5f));
            GameObject enemy = GameObject.Instantiate(enemyObject) as GameObject;

            if (vecdir.magnitude == 0.0f)
            {
                vecdir.x = 0.7f;
            }
            vecdir.Normalize();
            enemy.transform.position = vecdir * Random.Range(1f, 5f);
            _enemies[i] = enemy;

        }
    }
}
