using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {

	private float musicvol;
	private float soundvol;
	private AudioSource aud;

	// Use this for initialization
	void Start () {
		soundvol = PlayerPrefs.GetFloat ("Sound", 0.5f);
		musicvol = PlayerPrefs.GetFloat ("Music", 0.5f);
		aud = GetComponent<AudioSource> ();
		aud.volume = musicvol;
		PlayerController.player.aud.volume = soundvol;
	}
}
