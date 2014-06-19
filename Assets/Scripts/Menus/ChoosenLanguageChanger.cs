using UnityEngine;
using System.Collections;

public class ChoosenLanguageChanger : MonoBehaviour {

	public GameController controller;

	public Sprite bandeira_PT;
	public Sprite bandeira_EN;
	public Sprite bandeira_ES;
	public Sprite bandeira_FR;
	public Sprite bandeira_DE;

	private string currentLanguage;
	private SpriteRenderer ren;
	// Use this for initialization
	void Start () {
		ren = GetComponent<SpriteRenderer>();
		currentLanguage= controller.language;
		ChangeFlag();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentLanguage != controller.language) currentLanguage = controller.language; ChangeFlag();
	}


	void ChangeFlag()
	{
		switch(currentLanguage)
		{
		case "PT":
			ren.sprite = bandeira_PT;
			break;

		case "EN":
			ren.sprite = bandeira_EN;
			break;

		case "ES":
			ren.sprite = bandeira_ES;
			break;

		case "FR":
			ren.sprite = bandeira_FR;
			break;

		case "DE":
			ren.sprite = bandeira_DE;
			break;
		}
	}
}
