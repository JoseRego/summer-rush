using UnityEngine;
using System.Collections;

public class InterfaceScript : MonoBehaviour {

	// Use this for initialization
	public int score=0;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		GUI.color = Color.white;
		GUILayout.Label(" Score: "+ score.ToString());
	}
}
