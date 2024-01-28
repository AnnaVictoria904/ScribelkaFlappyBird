using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText, clickMe, bestScore, finalScore;
    public GameObject flashScreen;
    public GameObject resultPanel;
    private float queueTime = .5f;
    private float time = 0f;
    private float flash = 0f;
    // Start is called before the first frame update
    void Start()
    {
        clickMe.gameObject.SetActive(true);
        PlayerPrefs.SetInt("GameFinish", 2);
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Points: " + PlayerPrefs.GetInt("Points");
        if (PlayerPrefs.GetInt("GameFinish") == 2)
        {
            Time.timeScale = 1f;
            time += Time.deltaTime;
            if (time > queueTime)
            {
                clickMe.gameObject.SetActive(false);
                if (time > queueTime * 2f)
                {
                    clickMe.gameObject.SetActive(true);
                    time = 0f;
                }
            }
        }
        else if (PlayerPrefs.GetInt("GameFinish") == 1)
        {
            flash += Time.deltaTime;
            if (flash < 0.3f)
            {
                flashScreen.SetActive(true);
            }
            else { flashScreen.SetActive(false); }
            if (flash < 0.4f)
            {
                resultPanel.SetActive(true);
                finalScore.text = PlayerPrefs.GetInt("Points").ToString();
                bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
            }
        }
        else
        {
            clickMe.gameObject.SetActive(false);
        }
    }
    public void EraseBestScore()
    {
        PlayerPrefs.SetInt("BestScore", 0);
        bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
        PlayerPrefs.Save();
    }
    public void RestartGame()
    {
        Physics2D.IgnoreLayerCollision(0, 7, false);
        SceneManager.LoadScene(0);
    }
}
