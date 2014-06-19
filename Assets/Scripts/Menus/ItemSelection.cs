using UnityEngine;
using System.Collections;

public class ItemSelection : InteractButton {

	public string item;
	public GameController controller;

	public override void NextMenu()
	{
		if(!GetComponent<ItemGrey>().naoTem){
			controller.currentSelectedItem = item;

			currentMenu.SetActive(false);
			nextMenu.SetActive(true);
		}
	}


}
