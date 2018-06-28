using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour {

	private int screen_width;
	void Start()
	{
		screen_width = Screen.width;
	}
	void Update()
	{
		if(Input.GetMouseButtonDown(0)){
			Vector3 click_position = Input.mousePosition;
			if(click_position.x >= screen_width/2)
			{
				SceneManager.LoadScene("Card_Test");
			}
			else
			{
				SceneManager.LoadScene("Marangas");
			}
				
		}
	}
}
