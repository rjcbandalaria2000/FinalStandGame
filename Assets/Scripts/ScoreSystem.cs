using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;

    [SerializeField]
    TMPro.TextMeshProUGUI scoreText;

    [SerializeField]
    TMPro.TextMeshProUGUI highscoreText;

    int highScore;
    int playerScore;

    const string highscorePrefs = "highscore";

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(highscorePrefs, 0);
        RefreshScores();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshScores();
    }

    public void AddScore(int score)
    {
        playerScore += score; 
    }

    public void SetHighScore()
    {
        if(playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt(highscorePrefs, highScore);
        }
        playerScore = 0; 
    }

    private void RefreshScores()
    {
        if(scoreText!= null)
        {
            scoreText.text = string.Format("Score: {0}", playerScore);
        }
        if(highscoreText != null)
        {
            highscoreText.text = string.Format("High Score: {0}", highScore);
        }
        
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(highscorePrefs);
        highScore = 0;
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }
}
