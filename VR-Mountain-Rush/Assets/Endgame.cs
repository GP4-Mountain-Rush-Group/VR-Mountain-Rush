using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour
{
	public void ExittheGame()
	{
		Application.Quit();
	}
	public void Backmenu()
	{
		SceneManager.LoadScene("Main_menu_UI");
	}
}
