using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StopMenu : MonoBehaviour
{
	public static bool IsPause = false;
	//public GameObject pUI;
	/*void Updata() {
		if (Input.GetKeyDown("space"))
		{
			print("space key was pressed");
			if (IsPause)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}		
		}
	}*/

	public void Exit()
	{
		//Time.timeScale = 1;
		SceneManager.LoadScene("Main_menu_UI");
	}
	public void PauseGame()
	{
		//Time.timeScale = 0;
		IsPause = true;
		//pUI.SetActive(true);
	}

	public void ResumeGame()
	{
		//Time.timeScale = 1;
		IsPause = false;
		//pUI.SetActive(false);
	}

}
