using UnityEngine;
using System.Collections;

public class AudioSwitch : MonoBehaviour	 {

	public GameController controller;
	public ButtonLangChanger langChanger;

	void Start()
	{
	}

	void Update()
	{
		if(controller.Music && langChanger.OnOff == "OFF")
			ChangeText();
		else if(!controller.Music && langChanger.OnOff == "ON")
			ChangeText();
		else if(langChanger.OnOff =="")
			ChangeText();
	}

	void OnMouseDown()
	{
		controller.Music = !controller.Music;
		controller.Save();
	}

	void ChangeText()
	{
		if(controller.Music)
			langChanger.OnOff = "ON";
		else
			langChanger.OnOff = "OFF";

		Debug.Log("motherfuckn");

		langChanger.CheckLanguage();
	}
}