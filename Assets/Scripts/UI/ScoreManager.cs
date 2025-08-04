using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score;

    public TMP_Text scoreText;
    public TMP_Text finalScoreGameOverText;
    public TMP_Text maxScoreGameOverText;

    public TMP_Text finalScoreVictoryText;
    public TMP_Text maxScoreVictoryText;

    public static ScoreManager Instance { get; private set; }

   
    private void Awake()
    {
        // Evitar duplicados
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        TryAssignReferences();
    }
    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, LoadSceneMode mode)
    {
        TryAssignReferences();
    }
    private void TryAssignReferences()
    {
        LevelUIManager ui = FindObjectOfType<LevelUIManager>();
        if (ui != null)
        {
            ui.UpdateScoreText();
            ui.UpdateLevelText();

            scoreText = ui.scoreText;

            finalScoreGameOverText = ui.finalGOScoreText;
            maxScoreGameOverText = ui.maxGOScoreText;

            finalScoreVictoryText = ui.finalVScoreText;
            maxScoreVictoryText = ui.maxVScoreText;
        }

        if (scoreText != null)
            scoreText.text = "Score: " + score;
        
    }
    //Update the Score in the UI
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    public void MaxScoreUpdate()
    {
        //If Already a MaxScore
        if (PlayerPrefs.HasKey("SaveMaxScore"))
        {
            //if Score is highter than the save one
            if(score > PlayerPrefs.GetInt("SaveMaxScore")){
                //Set the new MaxScore
                PlayerPrefs.SetInt("SaveMaxScore", score);
            }
        } else
        {
            //If theres no MaxScore, set it
            PlayerPrefs.SetInt("SaveMaxScore", score);
        }

        // Actualiza ambos textos si existen
        if (finalScoreGameOverText != null)
            finalScoreGameOverText.text = "Final Score: " + score;

        if (maxScoreGameOverText != null)
            maxScoreGameOverText.text = "Max Score: " + PlayerPrefs.GetInt("SaveMaxScore");

        if (finalScoreVictoryText != null)
            finalScoreVictoryText.text = "Final Score: " + score;

        if (maxScoreVictoryText != null)
            maxScoreVictoryText.text = "Max Score: " + PlayerPrefs.GetInt("SaveMaxScore");
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
