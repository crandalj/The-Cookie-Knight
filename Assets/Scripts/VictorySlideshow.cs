using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictorySlideshow : MonoBehaviour {

	public GameObject[] slides;
	public int currentSlide;

	public void Next (){
		slides [currentSlide].gameObject.SetActive (false);
		currentSlide++;

		if (currentSlide == slides.Length) {
			currentSlide = 0;
		}
		slides [currentSlide].SetActive (true);
	}

	public void Back(){
		slides [currentSlide].gameObject.SetActive (false);
		currentSlide -= 1;

		if (currentSlide == 0) {
			currentSlide = slides.Length -1;
		}
		slides [currentSlide].SetActive (true);
	}
}
