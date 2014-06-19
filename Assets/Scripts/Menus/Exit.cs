using UnityEngine;
using System.Collections;

public class Exit : InteractButton {

	void OnMouseDown()
	{
		Debug.Log("bye");
		Application.Quit();
	}
}
