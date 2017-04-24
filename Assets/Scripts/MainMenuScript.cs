using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

	public GameObject Main;
	public GameObject Controls;
	public GameObject Sound;

	public Slider SoundSlider;
	public Slider MusicSlider;

	private AudioSource audioSource;

	void Start()
	{
		audioSource = gameObject.GetComponent<AudioSource> ();
		Main.SetActive (true);
		Controls.SetActive (false);
		Sound.SetActive (false);

		SoundSlider.value = PlayerPrefs.GetFloat ("Sound", 0.5f);
		MusicSlider.value = PlayerPrefs.GetFloat ("Music", 0.5f);

		float musicvol = MusicSlider.value;

		audioSource.volume = musicvol;
		audioSource.Play ();
	}

	public void SaveSound()
	{
		PlayerPrefs.SetFloat ("Sound", SoundSlider.value);
		PlayerPrefs.SetFloat ("Music", MusicSlider.value);

		PlayerPrefs.Save ();
	}

	public void Play()
	{
		SceneManager.LoadScene ("Game");
	}

	public void ControlMenu()
	{
		Controls.SetActive (true);
		Main.SetActive (false);
	}

	public void SoundMenu()
	{
		Sound.SetActive (true);
		Main.SetActive (false);
	}

	public void MainMenu()
	{
		Main.SetActive (true);
		Controls.SetActive (false);
		Sound.SetActive(false);
	}

	public void BackFromControls()
	{
		Main.SetActive (true);
		Controls.SetActive (false);
	}

	public void BackFromSound()
	{
		Main.SetActive (true);
		Sound.SetActive (false);
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
