using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInput : MonoBehaviour {

	public LayerMask touchInputMask;

	private List<GameObject> touchList = new List<GameObject>();
	private GameObject[] touchesOld;
	private RaycastHit hit;
	private Vector2 startPos;
	private Vector2 endPos;
	private bool moved = false;


	public string GetDirection(Vector2 dir)
	{
		if(dir.x > 0 && (dir.y < 0.3 && dir.y > -0.3))
		{
			return "right";
		}
		else if(dir.x < 0 && (dir.y < 0.3 && dir.y > -0.3))
		{
			return "left";
		}
		else if(dir.y < 0 && (dir.x < 0.3 && dir.x > -0.3))
		{
			return "down";
		}
		else if(dir.y > 0  && (dir.x < 0.3 && dir.x > -0.3))
		{
			return "up";
		}

		return "";
	}

	void Update () {
#if UNITY_EDITOR
		if(Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
		{
			if(Input.GetMouseButtonDown(0))
				startPos = Input.mousePosition;
			else if(Input.GetMouseButtonUp(0))
			{
				endPos = Input.mousePosition;
				Debug.Log("start pos: "+startPos+ " endPos: "+endPos+" : "+(endPos - startPos).normalized);
				Debug.Log("direction "+ GetDirection((endPos - startPos).normalized));
			}
			
		}
//		if(Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)){
//			touchesOld = new GameObject[touchList.Count];
//			touchList.CopyTo(touchesOld);
//			touchList.Clear();
//	
//			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
//			
//			if(Physics.Raycast(ray,out hit,touchInputMask)){
//				
//				GameObject recepient = hit.transform.gameObject;
//				
//				if(Input.GetMouseButtonDown(0) )
//				{
//					recepient.SendMessage("OnTouchDown",hit.point,SendMessageOptions.DontRequireReceiver);
//				}
//				
//				if(Input.GetMouseButtonUp(0))
//				{
//					recepient.SendMessage("OnTouchUp",hit.point,SendMessageOptions.DontRequireReceiver);
//				}
//				
//				if(Input.GetMouseButton(0))
//				{
//					recepient.SendMessage("OnTouchStay",hit.point,SendMessageOptions.DontRequireReceiver);
//				}
//			}
//			foreach(GameObject g in touchesOld)
//			{
//				if(!touchList.Contains(g))
//				{
//					g.SendMessage("OnTouchExit",hit.point,SendMessageOptions.DontRequireReceiver);
//				}
//			}
//		}
#endif
			if(Input.touchCount > 0){
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
					moved = false;
				}
				else if(touch.phase == TouchPhase.Moved)
				{
					moved = true;
				}
//				foreach(Touch touch in Input.touches)
//				{

//						Ray ray = camera.ScreenPointToRay(touch.position);
//						
//						if(Physics.Raycast(ray,out hit,touchInputMask)){
//
//							GameObject recepient = hit.transform.gameObject;
//				
//							if(touch.phase == TouchPhase.Began)
//							{
//								recepient.SendMessage("OnTouchDown",hit.point,SendMessageOptions.DontRequireReceiver);
//							}
//
//							if(touch.phase == TouchPhase.Ended)
//							{
//								recepient.SendMessage("OnTouchUp",hit.point,SendMessageOptions.DontRequireReceiver);
//							}
//
//							if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
//							{
//								recepient.SendMessage("OnTouchStay",hit.point,SendMessageOptions.DontRequireReceiver);
//							}
//
//							if(touch.phase == TouchPhase.Canceled)
//							{
//								recepient.SendMessage("OnTouchExit",hit.point,SendMessageOptions.DontRequireReceiver);
//							}
//					}
				}
//				foreach(GameObject g in touchesOld)
//				{
//					if(!touchList.Contains(g))
//					{
//						g.SendMessage("OnTouchExit",hit.point,SendMessageOptions.DontRequireReceiver);
//					}
//				}

			}
		}
	
