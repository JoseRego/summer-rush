using UnityEngine;
using System.Collections;

public class ItemColeccionavel : MonoBehaviour {

	public float durationTime = 16.0f;


	private float counter = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if(counter >= durationTime)
		{
			GameObject.Destroy(gameObject);
		}
	}
}
