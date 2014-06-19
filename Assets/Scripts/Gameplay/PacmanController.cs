using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PacmanController : MonoBehaviour {

	public enum Direction
	{
		right,
		left,
		up,
		down
	};
	public float moveSpeed = 2.0f;
	public bool walking = false;
	public bool canWalk = false;
	public bool isAlive = true;
	public Direction dir = Direction.right;
	public float verificarDistance = 0.1f;
	[HideInInspector]
	public string directionTouch="";
	public float player_lenght = 1.0f;

	private int direction=2;
	private Animator anim;
	private Direction wantedDir = Direction.right;

	
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		if(canWalk && isAlive && walking)
		{
			Vector2 newPos = new Vector2();
			switch(dir)
			{
			case Direction.down:
//				if(!VerificaCaminho(new Vector2(0,-verificarDistance)))
//				{
//					walking = false;
//					direction = 0;
//				}
//				else{
					direction = 4;
					walking = true;
					newPos = new Vector2(transform.position.x, transform.position.y-1);
					transform.position = Vector2.Lerp(transform.position,newPos,Time.deltaTime*moveSpeed);
//				}	
				break;
			case Direction.up:
//				if(!VerificaCaminho(new Vector2(0,verificarDistance)))
//				{
//					walking = false;
//					direction = 0;
//					
//				}
//				else
//				{
					direction = 3;
					walking = true;
					newPos = new Vector2(transform.position.x, transform.position.y+1);
					transform.position = Vector2.Lerp(transform.position,newPos,Time.deltaTime*moveSpeed);
//				}
				break;
			case Direction.right:
//				if(!VerificaCaminho(new Vector2(verificarDistance,0))){
//					Debug.Log("lol wut?");
//					walking = false;
//					direction = 0;
//				}
//				else{
					direction = 2;
					walking = true;
					newPos = new Vector2(transform.position.x+1, transform.position.y);
					transform.position = Vector2.Lerp(transform.position,newPos,Time.deltaTime*moveSpeed);
//				}
				break;
			case Direction.left:
//				if(!VerificaCaminho(new Vector2(-verificarDistance,0))){
//					walking = false;
//					direction = 0;
//				}
//				else{
					direction = 1;
					walking = true;
					newPos = new Vector2(transform.position.x-1, transform.position.y);
					transform.position = Vector2.Lerp(transform.position,newPos,Time.deltaTime*moveSpeed);
//				}
				break;
			}
		}
	}
	// Update is called once per frame
	void Update () {

	
		//checks if dies
		if(!isAlive)
		{
			canWalk = false;
			GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>().pacman_dies.Play();
			anim.SetBool("alive",false);
			Invoke("Dies",0.30f);
			Application.LoadLevelAsync("level1");
		}

		//updates animator values
		if(canWalk){
			anim.SetInteger("direction",direction);
			anim.SetBool("walking",walking);

			transform.rotation.Set(0,0,0,0);
			if(Input.GetKey(KeyCode.P))
			{
				if(Time.timeScale !=0)
					Time.timeScale =0;
				else if(Time.timeScale == 0)
					Time.timeScale = 1;
			}

			if(Input.GetKey(KeyCode.UpArrow) || directionTouch == "up")
			{
				walking= true;
				wantedDir = Direction.up;					
			}
			else if(Input.GetKey(KeyCode.DownArrow) || directionTouch == "down")
			{
				walking= true;
				wantedDir = Direction.down;
			}
			else if(Input.GetKey(KeyCode.LeftArrow) || directionTouch == "left")
			{
				walking= true;
				wantedDir = Direction.left;
			}
			else if(Input.GetKey(KeyCode.RightArrow) || directionTouch == "right")
			{
				walking= true;

				wantedDir = Direction.right;
			}

			avaliarSituacao();
		}
//		GameObject terreno = GameObject.FindGameObjectWithTag("Terreno");
//		Debug.Log(terreno.gameObject.collider.bounds.size.x );
//
//		if(Camera.main.WorldToScreenPoint(transform.position).x>=terreno.transform.position.x || Camera.main.WorldToScreenPoint(transform.position).x<=terreno.transform.position.x)
//		{
//			transform.position = new Vector3(transform.position.x*(-1),transform.position.y,transform.position.z);
//		}
	
	}
	void avaliarSituacao()
	{
		if(wantedDir == dir)
		{
			Debug.Log("verifica se vai contra parede");
			//ver se bate numa parede
			RaycastHit2D hit;
			switch(dir)
			{
			case Direction.right:
				GetComponent<BoxCollider2D>().enabled = false;
				hit = Physics2D.Raycast(transform.position,Vector2.right,0.4f);
				Debug.DrawRay(transform.position,Vector2.right);
				GetComponent<BoxCollider2D>().enabled = true;
				if(hit)
				{
					Debug.Log(hit.collider.tag);
					if(hit.collider.gameObject.tag == "Terreno")
					{
						Debug.Log("bate na parede");
						walking = false;
					}
				}
				break;

			case Direction.left:
				GetComponent<BoxCollider2D>().enabled = false;
				hit = Physics2D.Raycast(transform.position,Vector2.right*(-1),0.4f);
				Debug.DrawRay(transform.position,Vector2.right*(-1));
				GetComponent<BoxCollider2D>().enabled = true;
				if(hit)
				{
					Debug.Log(hit.collider.tag);
					if(hit.collider.gameObject.tag == "Terreno")
					{
						Debug.Log("bate na parede");
						walking = false;
					}
				}
				break;
			case Direction.down:
				GetComponent<BoxCollider2D>().enabled = false;
				hit = Physics2D.Raycast(transform.position,new Vector2(0,-0.4f),0.4f);
				Debug.DrawRay(transform.position,new Vector2(0,-0.4f));
				GetComponent<BoxCollider2D>().enabled = true;
				if(hit)
				{
					Debug.Log(hit.collider.tag);
					if(hit.collider.gameObject.tag == "Terreno")
					{
						Debug.Log("bate na parede");
						walking = false;
					}
				}
				break;
			case Direction.up:
				GetComponent<BoxCollider2D>().enabled = false;
				hit = Physics2D.Raycast(transform.position,Vector2.up,0.4f);
				Debug.DrawRay(transform.position,new Vector2(0,0.4f));
				GetComponent<BoxCollider2D>().enabled = true;
				if(hit)
				{
					Debug.Log(hit.collider.tag);
					if(hit.collider.gameObject.tag == "Terreno")
					{
						Debug.Log("bate na parede");
						walking = false;
					}
				}
				break;
			}
		}
		else
		{
			bool passa = true;
			switch(wantedDir)
			{
				case Direction.up:
//					if(verificaSePodeIr(transform.position, new  Vector2(0,1.0f)) 
//				   && verificaSePodeIr(GetCurrentPosition(), new  Vector2(0,1.0f)))
//					{
//						dir = Direction.up;
//					}
//					break;

					for(int i=0;i < (player_lenght*2)/0.1f;i++)
					{
						if(!verificaSePodeIr(GetCurrentPosition(player_lenght - (0.1f*i)),new Vector2(0,1.0f)))
					   	{
							passa = false;
						}

					}
					if(passa)
					dir = Direction.up;
				break;
				case Direction.down:

					for(int i=0;i < (player_lenght*2)/0.1f;i++)
					{
						if(!verificaSePodeIr(GetCurrentPosition(player_lenght - (0.1f*i)),new Vector2(0,-1.0f)))
						{
							passa = false;
						}
						
					}
				if(passa)
					dir = Direction.down;
					break;

				case Direction.left:

					for(int i=0;i < (player_lenght*2)/0.1f;i++)
					{
						if(!verificaSePodeIr(GetCurrentPosition(player_lenght - (0.1f*i)),new Vector2(-1.0f,0f)))
						{
							passa = false;
						}
						
					}
					if(passa)
						dir = Direction.left;
					break;

				case Direction.right:

					for(int i=0;i < (player_lenght*2)/0.1f;i++)
					{
						if(!verificaSePodeIr(GetCurrentPosition(player_lenght - (0.1f*i)),new Vector2(1.0f,0f)))
						{
							passa = false;
						}
					}
					if(passa)
						dir = Direction.right;
					break;
				default:
					break;
			}
		}
	}


	bool verificaSePodeIr(Vector2 currentPosition, Vector2 dir)
	{


		Debug.DrawRay(currentPosition,dir,Color.red);

		GetComponent<BoxCollider2D>().enabled = false;
		RaycastHit2D hit = Physics2D.Raycast(currentPosition,dir,verificarDistance);
		GetComponent<BoxCollider2D>().enabled = true;

		if(hit)
		{
			if(hit.collider.gameObject.tag == "Terreno")
				return false;
		}
		Debug.Log("pode ir");

		return true;
	}

	Vector2 GetCurrentPosition(float acrescimo)
	{

//		switch(dir)
//		{
//		case Direction.down:
//			return new Vector2(transform.position.x, transform.position.y + player_lenght);
//		case Direction.up:
//			return new Vector2(transform.position.x, transform.position.y - player_lenght);
//		case Direction.right:
//			return new Vector2(transform.position.x - player_lenght,transform.position.y);
//		case Direction.left:
//			return new Vector2(transform.position.x + player_lenght,transform.position.y);
//		}
		switch(dir)
		{
		case Direction.up:
			return new Vector2(transform.position.x, transform.position.y + acrescimo);
		case Direction.down:
			return new Vector2(transform.position.x, transform.position.y + acrescimo);
	   	case Direction.right:
			return new Vector2(transform.position.x+acrescimo,transform.position.y);
		case Direction.left:
			return new Vector2(transform.position.x+acrescimo,transform.position.y);
		}
		
		return transform.position;
	}

	void Dies()
	{
		GameObject.Destroy(gameObject);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		transform.position = new Vector3(transform.position.x*(-1),transform.position.y,transform.position.z);
	}
	bool VerificaCaminho(Vector2 direction)
	{
		GetComponent<BoxCollider2D>().enabled = false;
		RaycastHit2D hit = Physics2D.Raycast(transform.position,direction);
		GetComponent<BoxCollider2D>().enabled = true;

		if(hit)
		{
			Debug.Log(hit.collider.gameObject.tag);
//			if(hit.collider.gameObject.tag == "Terreno")
//				return false;
		}
		return true;
	}


}
