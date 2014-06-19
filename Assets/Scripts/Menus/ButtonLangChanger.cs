using UnityEngine;
using System.Collections;

public class ButtonLangChanger : MonoBehaviour {

	public GameController controller;
	public string frase_pt;
	public string frase_en;
	public string frase_es;
	public string frase_fr;
	public string frase_de;

	public string OnOff="";

	public string lan;
	private TextMesh text;

	void Awake() {
		lan = controller.language;
		text = gameObject.GetComponent<TextMesh>();
		CheckLanguage();
	}
	void Update()
	{
		if(controller.language != lan) lan = controller.language; CheckLanguage();
	}

	public void CheckLanguage()
	{
		switch(lan)
		{
		case "PT":
			text.text = frase_pt + " " + OnOff;
			break;
		case "EN":
			text.text = frase_en + " " + OnOff;
			break;
		case "ES":
			text.text = frase_es  + " " + OnOff;
			break;
		case "FR":
			text.text = frase_fr  + " " + OnOff;
			break;
		case "DE":
			text.text = frase_de  + " " + OnOff;
			break;
		}
	}
}
