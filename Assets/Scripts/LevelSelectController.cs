using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour {

	public bool quest1;
	public Image quest1image;
	public Sprite quest1_0;
	public Sprite quest1_1;
	public bool quest2;
	public Image quest2image;
	public Sprite quest2_0;
	public Sprite quest2_1;
	public bool quest3;
	public Image quest3image;
	public Sprite quest3_0;
	public Sprite quest3_1;
	public bool quest4;
	public Image quest4image;
	public Sprite quest4_0;
	public Sprite quest4_1;
	public bool quest5;
	public Image quest5image;
	public Sprite quest5_0;
	public Sprite quest5_1;

	public Button home;
	// Use this for initialization
	void Start () {
		QuestCheck ();
	}

	public void PlayLevel(GameObject clicked){
		SceneManager.LoadScene (clicked.name);
	}

	void QuestCheck()
	{
		//Quest 1 - basketball
		if (PlayerPrefs.GetInt ("quest1", 0) == 1) {
			quest1 = true;
			quest1image.sprite = quest1_1;
		} else {
			quest1 = false;
			quest1image.sprite = quest1_0;
		}
		//Quest 2 - flour
		if (PlayerPrefs.GetInt ("quest2", 0) == 1) {
			quest2 = true;
			quest2image.sprite = quest2_1;
		} else {
			quest2 = false;
			quest2image.sprite = quest2_0;
		}
		//Quest 3 - laundry
		if (PlayerPrefs.GetInt ("quest3", 0) == 1) {
			quest3 = true;
			quest3image.sprite = quest3_1;
		} else {
			quest3 = false;
			quest3image.sprite = quest3_0;
		}
		//Quest 4 - cat
		if (PlayerPrefs.GetInt ("quest4", 0) == 1) {
			quest4 = true;
			quest4image.sprite = quest4_1;
		} else {
			quest4 = false;
			quest4image.sprite = quest4_0;
		}
		//Quest 5 - ribbon
		if (PlayerPrefs.GetInt ("quest5", 0) == 1) {
			quest5 = true;
			quest5image.sprite = quest5_1;
		} else {
			quest5 = false;
			quest5image.sprite = quest5_0;
		}

		if (quest1 && quest2 && quest3 && quest4 && quest5) {
			home.interactable = true;
		} else {
			home.interactable = false;
		}
	}
}
