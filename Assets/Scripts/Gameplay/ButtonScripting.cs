using UnityEngine;
using System.Collections;

public class ButtonScripting : MonoBehaviour {

	public GameObject pauseObject;
	public UIButton pauseButton;

	private bool paused = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Pause()
	{
		if(!paused){
			pauseObject.SetActive(true);
			pauseButton.normalSprite = "play_btn";
			Time.timeScale = 0f;
			paused = true;
		}else
		{
			Resume();
		}

	}

	public void Resume()
	{		
		pauseObject.SetActive(false);
		pauseButton.normalSprite = "pause_btn";
		Time.timeScale = 1f;
		paused = false;
	}

	public void Restart()
	{
		Time.timeScale = 1f;
		Application.LoadLevel("NIVEL_TESTE");
	}

	public void GoMainMenu()
	{
		Time.timeScale = 1f;
		Application.LoadLevel("menu_summerman");
	}
}
