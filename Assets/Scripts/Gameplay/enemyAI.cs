using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

public class enemyAI : MonoBehaviour
{

		public enum State
		{
				CHASE,
				SCATTER,
				FRIGHTENED,
				DEAD,
				COCANDOTOMATADA
		}
		;

		public List<GameObject> wayPoints;
		public float coolDown;

		public Transform waypoints;	

		public float moveSpeedFrightned = 1.0f;
		public float moveSpeedNormal = 2.0f;
		public float moveSpeedChase = 4.0f;

		public float maxDistanceWaypoints = 0.2f;
		public State currentState;
		public float sightDistance = 3.0f;
		public GameObject player;
		public GameObject gameController;
		private float counter = 0;
		private int currentWaypoint = -1;
		private int currentPatrolWaypoint = -1;
		private Seeker seeker;
		private Path path;

		public Vector3 origin_point;
		
		// Use this for initialization
		void Start ()
		{
				origin_point = transform.position;
				currentState = State.COCANDOTOMATADA;
				coolDown = gameController.GetComponent<LevelController> ().startingTime;
				seeker = GetComponent<Seeker> ();
				Vector2 gaitas = GetDegreedVector(Vector2.right,Mathf.PI/2);
		}
	
		// Update is called once per frame
		void Update ()
		{
			if((currentState == State.CHASE || currentState == State.SCATTER)
		     && gameController.GetComponent<LevelController>().inimigos_vulneraveis){
				currentState = State.FRIGHTENED;
				path = null;
			}
			
			switch (currentState) {
				case State.CHASE:
						Chase ();
						break;
				case State.SCATTER:
						Scatter ();
						break;
				case State.FRIGHTENED:
						Frightened ();
						break;
				case State.DEAD:
						Dead ();
						break;
				case State.COCANDOTOMATADA:
						WaitTime ();
						break;
				default:
						WaitTime ();
						break;
			}
		}

		void WaitTime ()
		{
				counter += Time.deltaTime;
				if (counter >= coolDown) {
						currentState = State.SCATTER;
						nextWayPoint();
						counter = 0;
				}
		}

		void Chase ()
		{
			if(path == null || (currentWaypoint >= path.vectorPath.Count))
			{	
				if (isPacmanInSight ()) {
						seeker.StartPath (transform.position, player.transform.position, OnChasePathComplete);
				}
				else
				{
					currentState = State.SCATTER;
				}
			}else{
				Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position).normalized;
				transform.position = Vector3.Lerp (transform.position, transform.position + dir, moveSpeedNormal * Time.deltaTime);
				if (Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]) <= maxDistanceWaypoints){
					if(isPacmanInSight())
						seeker.StartPath (transform.position, player.transform.position, OnChasePathComplete);
					else
						currentWaypoint++;
				}
			}
		}

		void OnChasePathComplete (Path p)
		{
			if (!p.error) {
				path = p;
				currentWaypoint = 1;
			}
		}
	
		void nextWayPoint ()
		{
			
				if ((currentPatrolWaypoint == wayPoints.Count - 1) || (currentPatrolWaypoint == -1))
						currentPatrolWaypoint = 0;
				else
						currentPatrolWaypoint++;
				seeker.StartPath (transform.position, wayPoints [currentPatrolWaypoint].transform.position, OnPathComplete);

		}

		void Scatter ()
		{
				if (path == null)
						return;
				if (currentWaypoint >= path.vectorPath.Count) {
//					Debug.Log ("Path ended");
						nextWayPoint ();
						return;
				}
				Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position).normalized;
				transform.position = Vector3.Lerp (transform.position, transform.position + dir, moveSpeedNormal * Time.deltaTime);
//				Debug.Log(currentWaypoint + " , " +path.vectorPath.Count);
				if (player != null) {
			
						//pacman in distance
						Debug.DrawLine (transform.position, player.transform.position);
						if (isPacmanInSight ()) {
								Debug.Log ("PACMAN in sight");
								currentState = State.CHASE;
						}
					
				
				}
				if (Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]) <= maxDistanceWaypoints)
						currentWaypoint++; 
		}
		
		bool isPacmanInSight ()
		{
				if (Vector3.Distance (transform.position, player.transform.position) <= sightDistance) {
						Vector2 dir = (player.transform.position - transform.position);
						gameObject.GetComponent<BoxCollider2D> ().enabled = false;
						RaycastHit2D hit = Physics2D.Raycast (transform.position, dir);
						gameObject.GetComponent<BoxCollider2D> ().enabled = true;
						Debug.DrawRay (transform.position, dir, Color.yellow);
						if (hit) {
								Debug.Log ("COLLIDER: " + hit.collider.gameObject.tag);
								//raycast hits something
								if (hit.collider.gameObject.tag == "Player") {
										//hits pacman
										return true;
								}
						}
				}
				return false;
		}
	
		void OnPathComplete (Path p)
		{

				if (!p.error) {
						path = p;
						currentWaypoint = 1;
				}
		}

		void Frightened ()
		{
			
			Debug.Log("Scared");
			if(!gameController.GetComponent<LevelController>().inimigos_vulneraveis)
				currentState = State.SCATTER;

			if(path == null || (currentWaypoint >= path.vectorPath.Count))
			{
				seeker.StartPath(transform.position, FindNextTarget(),OnPathComplete);
			}else{
				Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
				transform.position = Vector3.Lerp(transform.position, transform.position + dir, moveSpeedNormal/4*Time.deltaTime);
				if (Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]) <= maxDistanceWaypoints)
					currentWaypoint++; 	
			}
		}

		void Dead ()
		{

		}

		Vector2 FindNextTarget()
		{
			int randomTarget = Random.Range(0, waypoints.childCount-1);
			return waypoints.GetChild(randomTarget).transform.position;
		}

		Vector2 GetDegreedVector(Vector2 vector, float angle)
		{
			float newX = vector.x*Mathf.Cos(angle) - vector.y*Mathf.Sin(angle);
			float newY = vector.x*Mathf.Sin(angle) + vector.y*Mathf.Cos(angle);
			Debug.Log("new vector by an angle of: "+angle+" is ("+newX+" , "+newY+")");
		    return new Vector2(newX,newY);
		}
}
