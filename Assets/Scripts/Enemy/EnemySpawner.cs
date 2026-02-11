using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public EnemyData[] enemyTypes;

    public void SpawnEnemy(Vector2 pos)
    {
        var enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
        enemy.GetComponent<EnemyController>().data =
            enemyTypes[Random.Range(0, enemyTypes.Length)];
    }
}

