using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuCode : MonoBehaviour
{

    public void OpenGame()
    {
        Debug.Log("Game Machine On.");
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Game Machine Broke.");
    }
	
}
