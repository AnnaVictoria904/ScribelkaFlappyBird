using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("GameFinish") != 0)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
