using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int lives;
    private int score;

    void Start()
    {
        lives = 5;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

                if (hit.collider != null)
                {
                    hit.collider.GetComponent<Enemy>().died = true;
                    score++;
                    Debug.Log("score: " + score);
                }
            }
        }

        if (lives < 0)
        {
            Debug.Log("game over");
        }

        GameManager.instance.txtScore.text = score.ToString();
    }
}
