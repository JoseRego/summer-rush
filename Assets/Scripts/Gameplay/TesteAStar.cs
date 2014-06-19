using UnityEngine;
using System.Collections;
using Pathfinding;

public class TesteAStar : MonoBehaviour {

	public Transform targetTransform;
	public Vector3 target;
	public Path path;
	public float speed = 100;
	public float nextWaypointDistance = 0.2f;
	public int currentWaypoint = 0;


	private CharacterController controller;
	private Seeker seeker;
	// Use this for initialization
	void Start () {
		if(targetTransform!=null)
			target = targetTransform.position;

		controller = GetComponent<CharacterController>();
		//Get a reference to the seeker component we added earlier
		seeker = GetComponent<Seeker>();
		seeker.StartPath(transform.position,target,OnPathComplete);
	}

	public void OnPathComplete(Path p)
	{
		Debug.Log("PATHFINDING BITCH!");
		if(!p.error)
		{
			path = p;
//			foreach(Vector3 vector in p.vectorPath)
//			{
//				Debug.Log(vector);
//			}
			currentWaypoint=1;
		}
	}
	// Update is called once per frame
	void Update () {
		if(path == null){
			return;
		}

		if(currentWaypoint >= path.vectorPath.Count)
		{
			Debug.Log("End of path reached");
			return;
		}

		//Direction to the next waypoint
		Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;


		//dir *= speed * Time.deltaTime;
		Debug.Log ("dir with speed :"+dir);
		transform.position = Vector3.Lerp(transform.position, transform.position+dir,speed*Time.deltaTime);
		//controller.SimpleMove(dir);
		//
		if(Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
		{
			currentWaypoint++;
			return;
		}
	}
}
