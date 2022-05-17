using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuUI;
    [SerializeField]
    private GameObject inGameUI;

    public GameObject mainMenu;
    public GameObject levelsUI;
    public GameObject player;
    public Vector2 playerDefaultPos;



    public void Menu()
    {
        SceneManager.LoadScene("1-Main");
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        mainMenu.SetActive(true);
        player.transform.position = playerDefaultPos;
        levelsUI.SetActive(true);
    }
    public void TryAgain()
    {
        mainMenu.SetActive(true);
        player.transform.position = playerDefaultPos;
        player.SetActive(false);
        levelsUI.SetActive(true);
        Time.timeScale = 1;
    }
    public void Resume()
    {
        inGameUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        inGameUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
