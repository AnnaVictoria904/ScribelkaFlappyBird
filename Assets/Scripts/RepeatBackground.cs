using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private float speed = 0.5f;

    [SerializeField]
    private Renderer bgRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("GameFinish") == 0)
        {
            bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
        }
    }
}
