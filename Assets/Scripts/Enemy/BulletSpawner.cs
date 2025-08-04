using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject enemyBullet;
    public float spawnTimer;
    public float spawnMax = 10;
    public float spawnMin = 3;

    private void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
            spawnTimer = Random.Range(spawnMin, spawnMax);
        }
    }
}
