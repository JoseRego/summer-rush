using UnityEngine;
using System.Collections;

public class PlayerHealthBarScript : MonoBehaviour
{
	
//	public GUIStyle progress_empty;// ???
	public GUIStyle progress_full;// ???

	public LevelController control;
	[Range(0,0.1f)]
	public float incremento;
	//current progress
	[Range(0,1)]
	public float barDisplay;

	public Texture2D emptyTex;
	public Texture2D fullTex;



	void OnGUI()
	{
//		//draw the background:
//		GUI.BeginGroup(new Rect(transform.position.x, transform.position.y, 250, 50), emptyTex, progress_empty);
//		
//		GUI.Box(new Rect(10, 50, 250, 50), fullTex, progress_full);
//		
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(transform.position.x, transform.position.y, 250 * barDisplay, 50));
			GUI.Box(new Rect(transform.position.x,transform.position.y, 250, 50), fullTex, progress_full);
		GUI.EndGroup();
//		GUI.EndGroup();

	}


	void Awake()
	{
	}


	void Update()
	{
		if(control.exposicao_solar > barDisplay)
		{
			//barra aumenta
			barDisplay += incremento;
		}

		else if(control.exposicao_solar < barDisplay)
		{
			//barra diminui
			barDisplay -= incremento;
		}
	}
	
}