using UnityEngine;
using System.Collections;

public class animation : MonoBehaviour {

	public float intervalo = 0.3f;
	public bool isSpecial = false;

	private bool isBigger = false;
	// Use this for initialization
	void Start () {
		InvokeRepeating("animationBall",1.0f,intervalo);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void animationBall()
	{
		if(!isSpecial){
			if(isBigger){
				gameObject.transform.localScale = new Vector3(2,2,0);
			}
			else{
				gameObject.transform.localScale = new Vector3(1.8f,1.8f,0);	
			}
			isBigger = !isBigger;
		}
		else if(isSpecial)
		{
			if(isBigger)
			{
				gameObject.GetComponent<SpriteRenderer>().color = Color.green;
			}else{
				gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
			}
			isBigger = !isBigger;

		}
	}
}
