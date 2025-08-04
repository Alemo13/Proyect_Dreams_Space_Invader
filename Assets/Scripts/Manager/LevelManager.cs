using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelManager : MonoBehaviour
{
    public GameObject invaders;
    public TextMeshProUGUI countdownText;
    public float delay = 1f;

    private void Start()
    {
        if (GameManager.Instance.isNextLeve)
        {
            GameManager.Instance.isNextLeve = false;
            return;
        }
        if (GameManager.Instance.isRestartLevel)
        {
            GameManager.Instance.isRestartLevel = false;
            return;
        }
        invaders.SetActive(false);
            StartCoroutine(CountDownRoutine());
    }

    private IEnumerator CountDownRoutine()
    {
        countdownText.gameObject.SetActive(true);

        string[] message = { "5", "4", "3", "2", "1", "GO!" };
        foreach(var msg in message)
        {
            countdownText.text = msg;
            yield return new WaitForSeconds(1f);
        }

        countdownText.gameObject.SetActive(false);
        invaders.SetActive(true);
    }
}
