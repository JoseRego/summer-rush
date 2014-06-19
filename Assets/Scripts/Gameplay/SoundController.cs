using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {


	public AudioSource walking_sound;
	public AudioSource ball_eating_sound;
	public AudioSource main_theme;
	public AudioSource ghost_eating;
	public AudioSource siren;
	public AudioSource pacman_dies;
	public AudioSource collectableEating;

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
		if(player!=null){
			if(player.GetComponent<PacmanController>().walking && !this.walking_sound.isPlaying)
				this.walking_sound.Play();
			else if(!player.GetComponent<PacmanController>().walking)
				this.walking_sound.Stop();
		}
	}



}
