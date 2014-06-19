using UnityEngine;
using System.Collections;

public class ItemMenu : InteractButton {

	public ItemController controller;

	public override void NextMenu ()
	{
		base.NextMenu();
		controller.EnableItems();

	}
}
