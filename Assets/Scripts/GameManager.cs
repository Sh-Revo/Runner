using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject ScoreDisplayUI;

    void Update()
    {
        if (EndGame.IsEnd == true)
        {
            EndGameScreen();
        }
    }

    void EndGameScreen()
    {
        gameOverUI.SetActive(true);
        ScoreDisplayUI.SetActive(false);
    }
}
