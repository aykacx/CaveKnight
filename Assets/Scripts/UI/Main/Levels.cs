using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public void LoadMainScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("1-Main");
    }
    public void LoadLevelOne()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level-1");
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Level-2");
    }
}
