using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour {

	public void Exit()
	{
		Application.Quit ();
	}

	public void StartGame()
	{
		SceneManager.LoadScene ("MainScene");
	}
}
