using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level-1");
    }
    public void QuitGame()
    {
        Debug.Log("kapat");
        Application.Quit();
    }
}
