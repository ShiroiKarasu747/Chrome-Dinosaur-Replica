using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreControl : MonoBehaviour
{
    public Text scoreLabel;
    public Text scoreText;
    [SerializeField] int score = -3;

    public Text highScoreLabel;
    public Text highScore;

    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject resumeButton;
    [SerializeField] GameObject replayButton;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0000";
        highScore.text = string.Format("{0:0000}", PlayerPrefs.GetInt("High Score", 0));
        score = -3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int inc)
    {
        score = score + inc;
        scoreText.text = string.Format("{0:0000}", score);
        if (score > PlayerPrefs.GetInt("High Score", 0))
        {
            highScore.text = string.Format("{0:0000}", score);
            PlayerPrefs.SetInt("High Score", score);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        replayButton.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        replayButton.SetActive(false);
    }

    public void Replay()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        highScoreLabel.gameObject.SetActive(true);
        highScore.gameObject.SetActive(true);

        scoreLabel.rectTransform.anchoredPosition = new Vector3(0, 148, 0);
        scoreText.rectTransform.anchoredPosition = new Vector3(0, 0, 0);

        scoreLabel.fontSize = 132;
        scoreText.fontSize = 132;

        replayButton.SetActive(true);
    }
}
