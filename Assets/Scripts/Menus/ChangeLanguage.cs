using UnityEngine;
using System.Collections;

public class ChangeLanguage : InteractButton {

	public GameController controller;
	public string lang;
	
	void OnMouseDown()
	{
		Debug.Log("Mudar Lingua");
		if(lang!=null)
		{
			//changes the language definition and saves it to file
			controller.language = lang;
			controller.Save ();
		}
		NextMenu();
	}
}
