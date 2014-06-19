using UnityEngine;
using System.Collections;

public class GestorGaleira : MonoBehaviour {
	
	public GameController controller;

	private string currentSelectedItem;
	private GameObject[] imagens;
	private GameObject[] labels;
	// Use this for initialization
	void Start () {
		imagens = GameObject.FindGameObjectsWithTag("imagem_item");
		labels = GameObject.FindGameObjectsWithTag("label_item");

		currentSelectedItem = controller.currentSelectedItem;

		ChangeLabel();
		ChangeImage();

	}
	
	// Update is called once per frame
	void Update () {
		if(currentSelectedItem != controller.currentSelectedItem){
			currentSelectedItem = controller.currentSelectedItem;
			ChangeLabel();
			ChangeImage();
		}
	}

	void ChangeLabel()
	{
		foreach(GameObject label in labels)
		{
			if(label.name == "label_"+currentSelectedItem)
			{
				label.SetActive(true);
			}else{
				label.SetActive(false);
			}
		}
	}
	void ChangeImage()
	{
		foreach(GameObject image in imagens)
		{
			if(image.name == "imagem_"+currentSelectedItem)
			{
				image.SetActive(true);
			}
			else{
				image.SetActive(false);
			}
		}

	}

}
