using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarruselControl : MonoBehaviour {

	[SerializeField]
	private float timeOfChange;

	[SerializeField]
	private Sprite [] slides;
	[SerializeField]
	private Image img_auxiliar;


	private float timeCount;
	private float timeAnim;

	private Image img;
	private Sprite currentSprite;
	private int index;
	private Color colorFade;
	private bool runFade;

	// Use this for initialization
	void Start () {
		img = this.GetComponent<Image>();
		index = Random.Range(0,slides.Length);
		img.sprite = slides[index];
		img_auxiliar.sprite = slides[index];

	}
	
	// Update is called once per frame
	void Update () {
 		timeCount += Time.deltaTime;
		if(timeCount>=timeOfChange){
			if(index+1 >= slides.Length){
				index = 0;
			}
			else{
				index++;
			}
			img.sprite = slides[index];
			runFade = true;
			timeCount = 0;
		}

		if(runFade){
			StartFadeOut();
		}
	}

	private void StartFadeOut(){
		colorFade = img_auxiliar.color;
		colorFade.a -= 0.4f*Time.deltaTime;
		img_auxiliar.color = colorFade;
		if(colorFade.a <= 0){
			runFade = false;
			img_auxiliar.sprite = slides[index];
			colorFade.a = 1;
			img_auxiliar.color = colorFade;

		}
	}
	
}
