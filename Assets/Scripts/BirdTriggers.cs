using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTriggers : MonoBehaviour
{
    private int points = 0;
    private int bestScore = 0;
    private Rigidbody2D rb;
    private Animator animator;
    public AudioClip collided;
    private bool soundPlayed;
    public AudioClip exited;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Points", points);
        rb = GetComponent<Rigidbody2D>();
        bestScore = PlayerPrefs.GetInt("BestScore");
        animator = GetComponent<Animator>();
        soundPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("collided", true);
        if (!soundPlayed)
        {
            GetComponent<AudioSource>().PlayOneShot(collided);
        }
        soundPlayed = true;
        PlayerPrefs.SetInt("GameFinish", 1);
        if (collision.gameObject.CompareTag("Pipe"))
        {
            rb.velocity = Vector2.zero;
            Physics2D.IgnoreLayerCollision(0, 7, true);
            transform.eulerAngles = new Vector3(0, 0, -90f);
            rb.freezeRotation = true;
            rb.gravityScale = 1;
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            Time.timeScale = 0.0f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<AudioSource>().PlayOneShot(exited);
        points++;
        PlayerPrefs.SetInt("Points", points);
        if (points > bestScore)
        {
            bestScore++;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }
}
