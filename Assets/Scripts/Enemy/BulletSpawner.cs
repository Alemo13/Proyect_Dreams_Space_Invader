using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject enemyBullet;
    public float spawnTimer;
    public float spawnMax = 10;
    public float spawnMin = 3;

    private AudioSource audioSource;
    public AudioClip shootSound;

    private void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
            if (audioSource != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
            spawnTimer = Random.Range(spawnMin, spawnMax);
        }
    }
}
