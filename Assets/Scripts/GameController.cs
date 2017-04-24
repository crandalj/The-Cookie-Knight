using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public static GameController gamecontroller;

	public GameObject completemenu;
	public GameObject retrymenu;

	private string sceneName;
	private int keyitemCount = 0;

	public AudioClip itemGet;
	private AudioSource aud;

	// Use this for initialization
	void Start () {
		gamecontroller = this;
		sceneName = SceneManager.GetActiveScene ().name;
		aud = GetComponent<AudioSource> ();
		Debug.Log (sceneName);
		completemenu.SetActive (false);
		retrymenu.SetActive (false);
	}

	public void RetryMenu(){
		retrymenu.SetActive (true);
	}

	public void LevelComplete(){
		completemenu.SetActive (true);
	}

	public void KeyItemFound(string keyitem){
		Debug.Log (sceneName);
		Debug.Log (keyitem);
		if (sceneName == "Level1") {
			if (keyitem == "basketball") {
				PlayerPrefs.SetInt ("quest1", 1);
				LevelComplete ();
			}
		} else if (sceneName == "Level2") {
			if (keyitem == "flour") {
				PlayerPrefs.SetInt ("quest2", 1);
				LevelComplete ();
			}
		} else if (sceneName == "Level3") {
			if (keyitem == "pants" || keyitem == "underwear" || keyitem == "shirt") {
				keyitemCount += 1;
			}
			if (keyitemCount == 3) {
				PlayerPrefs.SetInt ("quest3", 1);
				LevelComplete ();
			}

		} else if (sceneName == "Level4") {
			if (keyitem == "cat") {
				PlayerPrefs.SetInt ("quest4", 1);
				LevelComplete ();
			}
		} else if (sceneName == "Level5") {
			if (keyitem == "ribbon") {
				PlayerPrefs.SetInt ("quest5", 1);
				LevelComplete ();
			}
		}
		aud.PlayOneShot(itemGet);
	}

	public void BackToMenu()
	{
		SceneManager.LoadScene ("LevelSelect");
	}

	public void Retry(){
		SceneManager.LoadScene (sceneName);
	}
}
