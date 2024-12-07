using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(() => StartGame());
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Asteroids");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
