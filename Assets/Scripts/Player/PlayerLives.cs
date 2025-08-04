using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject gameOverPanel;
    public TMP_Text livesText;
    void Start()
    {
        livesText.text = ": " + GameManager.Instance.lives.ToString();
        TryAssignReferences();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        TryAssignReferences();
    }
    private void TryAssignReferences()
    {
        LevelUIManager ui = FindObjectOfType<LevelUIManager>();
        if (ui != null)
        {
            gameOverPanel = ui.gameoverPanel;
        }
        else
        {
        gameOverPanel = GameObject.Find("GameOverPanel");
        }

        livesText = GameObject.Find("LivesText")?.GetComponent<TMP_Text>();
    }
    private void HitManager(GameObject collisionObject)
    {
        Destroy(collisionObject);
        GameManager.Instance.lives--;
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        livesText.text = ": " + GameManager.Instance.lives.ToString();
        if (GameManager.Instance.lives <= 0)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            //Call the MaxScore Metod
            ScoreManager.Instance.MaxScoreUpdate();
            Destroy(gameObject);
        }
        else
        {
            GameManager.Instance.RestartLevel();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            HitManager(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HitManager(collision.gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
