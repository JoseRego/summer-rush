using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public float startingTime = 4.5f;
	public float vulnerable_time = 5.0f;
	public bool inimigos_vulneraveis = false;
	public GameObject player;
	public GameObject enemy_to_respawn;

	[Range(0,1)]
	public float exposicao_solar;

	public float aumento_exposicao_solar;
	public float intervalo_aumento_exposicao_solar;
	public UISlider NGUI_Slider;

	[Range(0,0.01f)]
	public float bar_delay;

	private float counter = 0f;
	private PacmanController playerController;
	private SoundController soundCtrl;



	// Use this for initialization
	void Start () {
		playerController =player.GetComponent<PacmanController>();
		soundCtrl = gameObject.transform.FindChild("SoundController").GetComponent<SoundController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!playerController.canWalk){
			counter += Time.deltaTime;
			if(counter >= startingTime)
			{
				playerController.canWalk = true;
				playerController.walking = true;
				soundCtrl.main_theme.Play();
			}
		}
		Debug.Log(NGUI_Slider.value);
		if(exposicao_solar > NGUI_Slider.value)
			NGUI_Slider.value += bar_delay;
		else if(exposicao_solar < NGUI_Slider.value)
			NGUI_Slider.value -= bar_delay;
	}

	public void RespawnEnemy()
	{
		Instantiate(enemy_to_respawn);
	}

	public void VulnarableEnemies()
	{
		CancelInvoke();
		inimigos_vulneraveis = true;
		soundCtrl.siren.Play();
		Invoke("InvulnarableEnemies",vulnerable_time);
	}
	void InvulnarableEnemies()
	{
		if(soundCtrl.siren.isPlaying)
			soundCtrl.siren.Stop();
		inimigos_vulneraveis = false;
	}
}
