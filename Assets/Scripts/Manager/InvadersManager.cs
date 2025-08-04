using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InvadersManager : MonoBehaviour
{
    public GameObject invaders;
    public TextMeshProUGUI countdownText;

    private bool isCourotine = false;

    private void Update()
    {
        if (!isCourotine && AllInvadersDefeated())
        {
            isCourotine = true;
            StartCoroutine(FindObjectOfType<LevelUIManager>().ShowCountdown(new[] { "Next Level", "5", "4", "3", "2", "1", "GO!" }));
        }
    }
    private bool AllInvadersDefeated()
    {
        return invaders.transform.childCount == 0;
    }
}
