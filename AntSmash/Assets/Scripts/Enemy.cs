using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private AudioSource audSrc;
    [SerializeField] private AudioClip[] deathSounds;
    [SerializeField] private AudioClip lifeLostSound;
    [SerializeField] private Sprite deathSprite;
    [SerializeField] private float speed;
    public bool died;
    private bool soundPlayed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audSrc = GetComponent<AudioSource>();
        died = false;
        soundPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!died)
        {
            rb.velocity = Vector2.down * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            sr.sprite = deathSprite;
            Destroy(anim);
            Destroy(gameObject, 2);

            if (!soundPlayed)
            {
                audSrc.PlayOneShot(deathSounds[Random.Range(0, deathSounds.Length)]);
                soundPlayed = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Finish"))
        {
            if (Player.lives >= 0)
            {
                Player.lives--;
                audSrc.PlayOneShot(lifeLostSound);

                for (int i = GameManager.instance.livesArray.Length - 1; i >= 0; i--)
                {
                    if (GameManager.instance.livesArray[i].activeSelf)
                    {
                        GameManager.instance.livesArray[i].SetActive(false);
                        Debug.Log("lost a life");
                        break;
                    }
                }

                Debug.Log("lives: " + Player.lives);
            }

            Destroy(gameObject, 1);
        }
    }
}
