using UnityEngine;
using System.Collections;

public class SFXSwitch : MonoBehaviour {

	public GameController controller;
	public ButtonLangChanger langChanger;
	

	void Update()
	{
		if(controller.SFX && langChanger.OnOff == "OFF")
			ChangeText();
		else if(!controller.SFX && langChanger.OnOff == "ON")
			ChangeText();
		else if(langChanger.OnOff =="")
			ChangeText();
	}
	
	void OnMouseDown()
	{
		controller.SFX = !controller.SFX;
		controller.Save();
	}
	
	void ChangeText()
	{
		if(controller.SFX)
			langChanger.OnOff = "ON";
		else
			langChanger.OnOff = "OFF";

		langChanger.CheckLanguage();
	}
}
