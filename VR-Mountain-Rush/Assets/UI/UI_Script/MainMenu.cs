using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void ExitGame()
	{
		Application.Quit();
	}
	public void StartTraining()
	{
		SceneManager.LoadScene("Scenes/level 0");
	}
	public void StartLevel1()
	{
		SceneManager.LoadScene("Scenes/level 1");
	}

}
