using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUIManager : MonoBehaviour
{
    public TMP_Text levelText, scoreText, livesText, countdownText, finalGOScoreText, maxGOScoreText, finalVScoreText, maxVScoreText;
    public GameObject victoryPanel;
    public GameObject gameoverPanel;

    private void Start()
    {
        UpdateLevelText();
        UpdateScoreText();
        UpdateLivesText();
    }

    public void UpdateLevelText()
    {
        levelText.text = "Level: " + GameManager.Instance.level;
    }
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.score;
    }
    public void UpdateLivesText()
    {
        livesText.text = ": " + GameManager.Instance.lives;
    }

    public IEnumerator ShowCountdown(string[] message, float delay = 1f)
    {
        GameManager.Instance.lives++;
        if (GameManager.Instance.level >= GameManager.Instance.maxLevel)
        {
            victoryPanel.SetActive(true);
            Time.timeScale = 0;
            ScoreManager.Instance.MaxScoreUpdate();
            yield break;
        }
        countdownText.gameObject.SetActive(true);

        foreach(string msg in message)
        {
            countdownText.text = msg;
            yield return new WaitForSeconds(delay);
        }
        countdownText.gameObject.SetActive(false);
  
        GameManager.Instance.NextLevel();
    }
}
