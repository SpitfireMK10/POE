using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void MainGame()
    {
        SceneManager.LoadScene("Main game");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Opening Screen");
    }

    public void Quit()
    {
        Application.Quit();
    }


}
