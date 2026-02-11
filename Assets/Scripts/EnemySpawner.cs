using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public RoomTempelates tempelates;
    private int rand;
    private Transform wallsCenter;
    private int enemyCount;
    [SerializeField] private GameObject[] enemies;


    void Start()
    {
        Invoke("SpawnEnemy", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        for (int i = 1; i < tempelates.rooms.Count - 1; i++)
        {
            enemyCount = Random.Range(1, 5);

            wallsCenter = null;

            foreach (Transform child in tempelates.rooms[i].transform)
            {
                if (child.CompareTag("Walls"))
                {
                    wallsCenter = child;
                    break;
                }
            }

            if (wallsCenter == null) continue;

            Vector2 center = wallsCenter.position;

            for (int j = 0; j < enemyCount; j++)
            {
                int rand = Random.Range(0, enemies.Length);

                Vector2 spawnPos = new Vector2(Random.Range(center.x - 2f, center.x + 2f),Random.Range(center.y - 2f, center.y + 2f));

                Instantiate(enemies[rand], spawnPos, Quaternion.identity);
            }
        }
    }



}
