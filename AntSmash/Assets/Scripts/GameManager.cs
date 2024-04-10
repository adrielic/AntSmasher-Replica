using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameplay, pause, gameOver;
    public GameObject[] livesArray;
    public TMP_Text txtScore;

    void Awake()
    {
        instance = this;
    }

    public void PauseButton()
    {
        pause.SetActive(true);
        gameplay.SetActive(false);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
