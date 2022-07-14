using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
	public void Backmenu()
	{
		SceneManager.LoadScene("Main_menu_UI");
	}
	public void Loadlv1()
	{
		SceneManager.LoadScene("level 1");
	}
	public void Loadlv0()
	{
		SceneManager.LoadScene("level 0");
	}
}
