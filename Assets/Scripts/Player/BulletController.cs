using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //Objects
    public GameObject BulletPrefab;

    public AudioClip shootSound;
    private AudioSource audioSource;
    void Start()
    {
        // Obtener o añadir el AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Opcional: ajustar configuración del audio
        audioSource.playOnAwake = false;
        audioSource.loop = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPrefab, transform.position, BulletPrefab.transform.rotation);
            if (shootSound != null)
            {
                audioSource.PlayOneShot(shootSound);
            }
        }
    }
}
