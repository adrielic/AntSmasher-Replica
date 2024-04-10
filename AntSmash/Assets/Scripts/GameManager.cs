using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] livesArray;
    public TMP_Text txtScore;

    void Awake()
    {
        instance = this;
    }
}
