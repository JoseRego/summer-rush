using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ItemController : MonoBehaviour {
	
	public GameObject[] listaItens;
	public string[] nomeItem;


	// Use this for initialization
	public void Start () {

		if(File.Exists(Application.persistentDataPath + "/Itens.dat"))
		{
			//se nao existir alteraçoes no anterior 
			Debug.Log("load");
			Load();
			//se existir alteraçoes salva outra x por cima
			if(nomeItem.Length!=listaItens.Length)
			{
				Debug.Log("entra");
				Delete();
				Save();
				Load ();
			}

			foreach(string nome in nomeItem)
			{
				Debug.Log(nome);
			}

		}else
		{
			Debug.Log("salva");
			Save();
		}
	}


	public void EnableItems()
	{
		foreach(string nome in nomeItem)
		{
			GameObject.Find(nome).GetComponent<ItemGrey>().naoTem = false;
			Debug.Log(nome+": "+GameObject.Find(nome).GetComponent<ItemGrey>().naoTem);
		}
	}
	public void Delete()
	{
		File.Delete(Application.persistentDataPath + "/Itens.dat");
	}

	public void Save()
	{
		nomeItem = new string[listaItens.Length];
		int counter = 0;
		for(int i=0;i<listaItens.Length;i++)
		{
			nomeItem[counter] = listaItens[i].name;
			counter++;
		}

		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/Itens.dat");
		
		ItensData data = new ItensData();

		data.lista = nomeItem;

		bf.Serialize(file,data);
		file.Close();
		
	}

	public void Load()
	{
		if(File.Exists(Application.persistentDataPath + "/Itens.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/Itens.dat",FileMode.Open);
			
			ItensData data = (ItensData)bf.Deserialize(file);
			file.Close();
			
			nomeItem = data.lista;

		}
	}
}

[Serializable]
class ItensData//container de dados
{
	public string[] lista;
}