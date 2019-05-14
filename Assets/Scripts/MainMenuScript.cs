using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

	public string SceneToTransitionTo;
    public string PuzzleScenes;

    public void PlayGame()
    {
    	SceneManager.LoadScene(SceneToTransitionTo);
    }

    public void SkipToPuzzles()
    {
        SceneManager.LoadScene(PuzzleScenes);
    }

    public void QuitGame()
    {
    	Debug.Log("Quit");
    	Application.Quit();
    }
    
}
