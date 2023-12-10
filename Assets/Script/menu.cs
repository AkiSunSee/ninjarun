using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public string sceneGame ="";

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneGame);
    }

    public void QuitGame()
    {
    Application.Quit();
    }
    
}
