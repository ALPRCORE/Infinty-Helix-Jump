using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    public TMP_Text scoreTMP;

    public static int inLevelIndex;
    public static int outLevelIndex;

    public TextMeshProUGUI inLevel;
    public TextMeshProUGUI outLevel;

    public Slider inLevelSlider;

    public static bool gameOver;
    public static bool win;

    public GameObject gameoverpnl;
    public GameObject winpnl;


    public void Awake()
    {
        inLevelIndex = PlayerPrefs.GetInt("inLevelIndex", 1);
    }


    private void Start()
    {
        outLevelIndex = 0;
        Time.timeScale = 1f;
        gameOver = false;
        win = false;
    }
    private void Update()
    {
        inLevel.text = inLevelIndex.ToString();
        outLevel.text = (inLevelIndex + 1).ToString();
        int inLevelSliderr = outLevelIndex * 100 / FindObjectOfType<TowerManeger>().no0fRings;
        inLevelSlider.value = inLevelSliderr;

        if (gameOver)
        {
            Time.timeScale = 0.5f;
            gameoverpnl.SetActive(true);

        }

        if (win)
        {
            PlayerPrefs.SetInt("inLevelIndex", inLevelIndex + 1);

            Time.timeScale = 0f;
            winpnl.SetActive(true);
        }
    }

    private static void scenezero()
    {

        SceneManager.LoadScene(1);
    }

    public void IncreaseScore(int winscore)
    {
        score += winscore;
        scoreTMP.text = "Score: " + score.ToString();
    }

    public void ResetGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }

}
