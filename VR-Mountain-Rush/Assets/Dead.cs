using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
	public void Backmenu()
	{
		Application.Quit();
	}
	public void Loadlv1()
	{
		SceneManager.LoadScene("Level 1");
	}
	public void Loadlv0()
	{
		SceneManager.LoadScene("Level 0");
	}
}
