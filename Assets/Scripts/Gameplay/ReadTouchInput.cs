using UnityEngine;
using System.Collections;

public class ReadTouchInput : MonoBehaviour {

	private PacmanController controller;

	private Vector2 startPos;
	private Vector2 endPos;
	private bool moved = false;
	private float intervalo = 0.3f;


	// Use this for initialization
	void Start () {
		controller = GetComponent<PacmanController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began)
			{
				startPos = touch.position;
			}
			else if(touch.phase == TouchPhase.Ended && moved)
			{
				endPos = touch.position;
				Vector2 dir = endPos - startPos;
				Debug.Log(GetDirection(dir.normalized));
				controller.directionTouch = GetDirection(dir.normalized);
				moved = false;
			}
			else if(touch.phase == TouchPhase.Moved)
			{
				moved = true;
			}
		}
	}

	
	public string GetDirection(Vector2 dir)
	{
		if(dir.x > 0 && (dir.y < intervalo && dir.y > -intervalo))
		{
			return "right";
		}
		else if(dir.x < 0 && (dir.y < intervalo && dir.y > -intervalo))
		{
			return "left";
		}
		else if(dir.y < 0 && (dir.x < intervalo && dir.x > -intervalo))
		{
			return "down";
		}
		else if(dir.y > 0  && (dir.x < intervalo && dir.x > -intervalo))
		{
			return "up";
		}
		
		return "";
	}
}
