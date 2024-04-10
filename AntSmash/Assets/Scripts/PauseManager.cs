using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    void OnEnable()
    {
        Time.timeScale = 0;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void ResumeButton()
    {
        GameManager.instance.pause.SetActive(false);
        GameManager.instance.gameplay.SetActive(true);
    }

    public void MenuButton()
    {
        GameManager.instance.ReturnToMenu();
    }
}
