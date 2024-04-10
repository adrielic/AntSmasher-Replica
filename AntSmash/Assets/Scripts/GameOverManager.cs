using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    void OnEnable()
    {
        Time.timeScale = 0;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void RetryButton()
    {
        GameManager.instance.ReloadScene();
    }

    public void MenuButton()
    {
        GameManager.instance.ReturnToMenu();
    }
}
