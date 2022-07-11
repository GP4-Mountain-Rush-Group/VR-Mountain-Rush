using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Mainmenu2 : MonoBehaviour
{
	public void Back()
	{
		SceneManager.LoadScene("Main_menu_UI");
	}
	public void Training()
	{
		SceneManager.LoadScene("Training");
	}
	public void MainGame()
	{
		SceneManager.LoadScene("Game");
	}
}
