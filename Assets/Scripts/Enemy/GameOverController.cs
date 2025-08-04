using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject gameOverPanel;
    public TMP_Text livesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            GameManager.Instance.lives -= 1;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            livesText.text = ": " + GameManager.Instance.lives.ToString();
            if (GameManager.Instance.lives <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);

                //Call the MaxScore Metod
                ScoreManager.Instance.MaxScoreUpdate();

            }
        }
    }
}
