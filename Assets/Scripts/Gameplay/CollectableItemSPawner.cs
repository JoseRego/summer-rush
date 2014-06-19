using UnityEngine;
using System.Collections;

public class CollectableItemSPawner : MonoBehaviour {
	public float interval = 0;
	public GameObject collectable;
	[Range(0,1.0f)]
	public float respawnProbability = 0.7f;


	// Use this for initialization
	void Start () {
		InvokeRepeating("WillItSpawn",interval,interval);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void WillItSpawn()
	{
		Debug.Log("yolo");
		if(CheckProbability(respawnProbability))
		{
			Instantiate(collectable,transform.position,transform.rotation);
			GameObject.Destroy(gameObject);
		}
	}


	bool CheckProbability(float probability)
	{
		//por exemplo se quisermos testar uma probabilidade de igual a 40%,
		//caso o random dê superior a 0.40 considera-se falso.
		if(Random.value >= probability)
			return false;
		else
			return true;
	}
}
