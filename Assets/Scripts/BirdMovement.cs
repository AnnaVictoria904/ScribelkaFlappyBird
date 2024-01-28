using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public GameObject bird;
    private Rigidbody2D rb;
    private bool clicked, jump, touched;
    private float coolDown = 0.6f;
    private float sumTime;
    public AudioClip jumpSound;
    private bool soundPlayed;
    // Start is called before the first frame update
    void Start()
    {
        sumTime = 0f;
        rb = bird.GetComponent<Rigidbody2D>();
        jump = false;
        soundPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("GameFinish") != 1)
        {
            clicked = Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.X);
            touched = Input.touchCount > 0;
            if (touched)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:

                        break;
                }
            }

            if (Application.isEditor || Application.platform == RuntimePlatform.WebGLPlayer)
            {
                clicked = clicked || Input.GetKeyDown(KeyCode.X);
            }

            if (clicked && !jump)
            {
                if (!soundPlayed)
                {
                    GetComponent<AudioSource>().PlayOneShot(jumpSound);
                }
                soundPlayed = true;
                PlayerPrefs.SetInt("GameFinish", 0);
                jump = true;
                bird.transform.eulerAngles = new Vector3(0, 0, 30f);
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * 100f);
            }

            if (jump)
            {
                sumTime += Time.deltaTime;

                if (sumTime >= coolDown)
                {
                    jump = false;
                    sumTime = 0f;
                    bird.transform.eulerAngles = new Vector3(0, 0, -30f);
                    rb.AddForce(Vector2.down * 200f);
                    soundPlayed = false;
                }
            }
        }
    }
}
