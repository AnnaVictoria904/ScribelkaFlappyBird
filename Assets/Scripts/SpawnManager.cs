using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject pipeParent;
    private float queueTime = 1f;
    private float time = 0f;
    private float height = 2f;
    private GameObject newPipe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("GameFinish") == 0) {
            if (time > queueTime)
            {
                newPipe = Instantiate(pipePrefab, pipeParent.transform);
                newPipe.transform.position = transform.position + new Vector3(5f, Random.Range(-height, height-0.8f), 0);

                time = 0;

                Destroy(newPipe, 10);
            }
            time += Time.deltaTime;
        }
    }
}
