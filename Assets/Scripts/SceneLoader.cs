using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    // cached references
    GameSession gameStatus;
    

    public void LoadNextScene() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadFirstScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - currentSceneIndex);
        // FindObjectOfType<GameSession>().DestroyItSelf(); <-- same as next 2 lines
        gameStatus = FindObjectOfType<GameSession>();
        gameStatus.DestroyItSelf();
    }

    public void QiutGame()
    {
        Application.Quit();
    }

}
