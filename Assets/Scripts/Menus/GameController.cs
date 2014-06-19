using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GameController : MonoBehaviour {

	//public static GameController control;
	public float timeLimit = 2.0f;


	public GameObject menuLanguage;
	public GameObject menu;

	public string language;
	public bool SFX;
	public bool Music;

	public string currentSelectedItem;

	//music
	public AudioSource main_theme;


	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
		Debug.Log(Application.persistentDataPath);
		if(File.Exists(Application.persistentDataPath + "/Settings.dat"))
		{
			Debug.Log("#HasFile");
			//loads file and goes to main menu
			Load ();
			Invoke("ShowMainMenu",timeLimit);

		}
		else
		{
			Debug.Log("Nao tem ficheiro");
			SFX = true;
			Music = true;
			//loads Language Selection screen
			Invoke ("ShowLanguageMenu",timeLimit);
		}
	}
	void Update()
	{
		//verifies music
		if(main_theme.isPlaying && !Music)
		{
			main_theme.Pause();
		}else if(!main_theme.isPlaying && Music)
		{
			main_theme.Play();
		}
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/Settings.dat");

		SettingsData data = new SettingsData();

		data.language = language;
		data.SFX = SFX;
		data.Music = Music;

		bf.Serialize(file,data);
		file.Close();

	}

	public void Load()
	{

			Debug.Log("doasjdoajsodj");
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/Settings.dat",FileMode.Open);
			
			SettingsData data = (SettingsData)bf.Deserialize(file);
			file.Close();
			
			language = data.language;
			SFX = data.SFX;
			Music = data.Music;

	}

	void ShowLanguageMenu()
	{
		menuLanguage.SetActive(true);
	}
	
	void ShowMainMenu()
	{
		menu.SetActive(true);
	}
}


[Serializable]
class SettingsData//container de dados
{
	public string language;
	public bool SFX;
	public bool Music;
}