using UnityEngine;
using System.Collections;

public class PacmanColliding : MonoBehaviour {
	public GameObject gameController;

	private InterfaceScript inter;
	private SoundController soundCtrl;
	private LevelController lvlCtrl;
	// Use this for initialization
	void Start () {
		inter = gameController.GetComponent<InterfaceScript>();
		soundCtrl = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
		lvlCtrl = gameController.GetComponent<LevelController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "bolas")
		{
			inter.score += 100;
			soundCtrl.ball_eating_sound.Play();
			if(other.gameObject.GetComponent<animation>().isSpecial){
				lvlCtrl.VulnarableEnemies();
			}
			GameObject.Destroy(other.gameObject);
		}
		if(other.gameObject.tag == "Collecionavel")
		{
			inter.score+= 1000;
			soundCtrl.collectableEating.Play();
			GameObject.Destroy(other.gameObject);
		}
		if(other.gameObject.tag == "Inimigo")
		{
			if(lvlCtrl.inimigos_vulneraveis){
				inter.score += 1000;
				soundCtrl.ghost_eating.Play();
//				GameObject.Destroy(other.gameObject);
				enemyAI ai = other.gameObject.GetComponent<enemyAI>();
				other.gameObject.transform.position = ai.origin_point;
				ai.currentState = enemyAI.State.COCANDOTOMATADA;
				Invoke("sirenPlaying",0.5f);
			}else
			{
				gameObject.GetComponent<PacmanController>().isAlive = false;
			}
		}
	}
	void sirenPlaying()
	{
		soundCtrl.siren.Play();
		Invoke("sirenStop",2.0f);
	}

	void sirenStop()
	{
		soundCtrl.siren.Stop();
	}

}
