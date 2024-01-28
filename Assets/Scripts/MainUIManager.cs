using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject endScreen;

    public GameObject scoretxt;
    public GameObject wintxt;
    public GameObject losetxt;

    private GameManager gameManager;

    public SceneChanger changer;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;

        pauseScreen.SetActive(false);
        endScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // open and close the pause menu screen
    private void TogglePause()
    {
        if (gameManager !=null)
        {
            gameManager.TogglePlayPause();
            pauseScreen.SetActive(gameManager.isPaused);
        }
    }

    // bind pause screen buttons
    public void Resume()
    {
        TogglePause();
    }

    // bind hte back to menu button
    public void ToMenu()
    {
        //changer.levelToLoad = "IntroScene";
        changer.FadeOut();
        TogglePause();
    }


    // score display update
    public void ScoreUpdate(int score)
    {
        scoretxt.GetComponent<TextMeshProUGUI>().text = "Collected memes: " + score;
    }

    // end game screen display
    public void EndGame()
    {
        endScreen.SetActive(true);
        losetxt.SetActive(true);
    }
}
