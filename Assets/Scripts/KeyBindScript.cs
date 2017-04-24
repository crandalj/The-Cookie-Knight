using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class KeyBindScript : MonoBehaviour {

	private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

	public Text left, right, jump;

	private GameObject currentKey;
	private Color32 normal = new Color32(255,255,255,255);
	private Color32 selected = new Color32(255,185,81,255);

	// Use this for initialization
	void Start () {
		keys.Add ("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "LeftArrow")));
		keys.Add ("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "RightArrow")));
		keys.Add ("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "UpArrow")));

		left.text = keys ["Left"].ToString ();
		right.text = keys ["Right"].ToString ();
		jump.text = keys ["Jump"].ToString ();
	}
	

	void OnGUI () 
	{
		if (currentKey != null) 
		{
			Event press = Event.current;
			if (press.isKey) 
			{
				keys [currentKey.name] = press.keyCode;
				currentKey.transform.GetChild(0).GetComponent<Text> ().text = press.keyCode.ToString ();
				currentKey.GetComponent<Image> ().color = normal;
				currentKey = null;
			}
		}
	}

	public void ChangeKey(GameObject clicked)
	{
		if (currentKey != null) {
			currentKey.GetComponent<Image> ().color = normal;
		}
		currentKey = clicked;
		currentKey.GetComponent<Image> ().color = selected;
	}

	public void SaveButton()
	{
		foreach (var key in keys) 
		{
			PlayerPrefs.SetString(key.Key,  key.Value.ToString());
		}

		PlayerPrefs.Save();
	}
}
