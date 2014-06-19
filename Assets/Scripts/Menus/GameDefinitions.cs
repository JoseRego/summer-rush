using UnityEngine;
using System.Collections;

public class GameDefinitions : MonoBehaviour {

	public string currentLanguage;
	public bool SFX;
	public bool MUSIC;

	//music
	public AudioSource main_theme;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//verifies music
		if(main_theme.isPlaying && !MUSIC)
		{
			main_theme.Pause();
		}else if(!main_theme.isPlaying && MUSIC)
		{
			main_theme.Play();
		}


	}
}
