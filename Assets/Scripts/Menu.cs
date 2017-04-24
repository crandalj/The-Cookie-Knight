using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void RetryButton()
	{
		SceneManager.LoadScene ("Game");
	}

	public void QuitButton()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
