using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public int Score = 0;

    public int NumberOfBalls = 0;
    public int MaximumBalls = 15;

    //public Text ScoreText;

    public TextMeshProUGUI ScoreText;
    public Button PlayAgainButton;

    public GameObject OneBallPrefab;

    public bool GameOver = true;

    void Update()
    {
        ScoreText.text = Score.ToString();
    }

    public void ClickedOnBall()
    {
        Score++;
        NumberOfBalls--;
    }

    public void StartGame()
    {
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("GameController"))
        {
            Destroy(ball);
        }
        PlayAgainButton.gameObject.SetActive(false);
        Score = 0;
        NumberOfBalls = 0;
        GameOver = false;
    }


    void Start()
    {
        InvokeRepeating("AddABall", 1.5F, 1);
    }

    void AddABall()
    {
        if (!GameOver)
        {
            Instantiate(OneBallPrefab);
            NumberOfBalls++;

            if (NumberOfBalls >= MaximumBalls)
            {
                GameOver = true;
                PlayAgainButton.gameObject.SetActive(true);
            }
        }
    }
}
