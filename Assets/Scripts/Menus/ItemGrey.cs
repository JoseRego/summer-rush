using UnityEngine;
using System.Collections;

public class ItemGrey : MonoBehaviour {

	public Color original;
	public Color greyScale;
	public float r=45f;
	public float g=45f;
	public float b=45f;
	public float a=0.3f;

	public bool naoTem;

	// Use this for initialization
	void Start () {
		//naoTem=true;
		greyScale = new Color(r,g,b,a);
		original = gameObject.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		if(naoTem)
		{
			renderer.material.color = greyScale;
		}else
		{
			renderer.material.color = original;
		}
	}
}
