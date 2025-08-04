using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int level = 1;
    public int lives = 3;
    public int maxLevel = 10;
    public float invaderSpeed = 1.0f;
    public bool isNextLeve = false;
    public bool isRestartLevel = false;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        level++;
        isNextLeve = true;
        invaderSpeed += 0.2f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        level = 1;
        lives = 3;
        invaderSpeed = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartLevel()
    {
        isRestartLevel = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
