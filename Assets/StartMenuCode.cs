using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuCode : MonoBehaviour
{

    public void OpenGame()
    {
        Debug.Log("Game Machine On.");
        SceneManager.LoadScene(1);
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Game Machine Broke.");
    }
	
}
