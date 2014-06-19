using UnityEngine;
using System.Collections;

public class ExposicaoSolar : MonoBehaviour {

	public GameObject gameController;


	private LevelController lvlController;
	// Use this for initialization
	void Start () {
		lvlController = gameObject.GetComponent<LevelController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
//
//	void OnGUI()
//	{
//		GUI.Label(new Rect(10, 80, 100, 20));
//	}
}
