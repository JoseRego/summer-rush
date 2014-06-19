using UnityEngine;
using System.Collections;

public class InteractButton : MonoBehaviour {

	public GameObject currentMenu;
	public GameObject nextMenu;

	void OnTouchDown()
	{
		NextMenu();
	}

	void OnMouseDown()
	{
		NextMenu();
	}

	public virtual void NextMenu()
	{
		Debug.Log("D. David II, O Carocho");
		currentMenu.SetActive(false);
		nextMenu.SetActive(true);
	}

	void ActivateAll(Transform transf,bool activate)
	{
		transf.gameObject.SetActive(activate);
		if(transf.childCount > 0 )
			foreach(Transform child in transf)
				ActivateAll(child.transform,activate);
	}
}
