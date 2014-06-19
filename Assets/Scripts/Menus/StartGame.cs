using UnityEngine;
using System.Collections;

public class StartGame : InteractButton {


	public override void NextMenu()
	{
		Application.LoadLevel("NIVEL_TESTE");
	}

}
