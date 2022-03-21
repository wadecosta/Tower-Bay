using System.Collections.Generic;
using UnityEngine;

public class EnemyDemo : MonoBehaviour
{
    // todo #1 set up properties
    public int health = 3;
    public float speed = 3f;
    public int coins = 3;
    public int size;

    public List<Transform> waypointList;

    private int targetWaypointIndex;

    //   health, speed, coin worth
    //   waypoints
    //   delegate event for outside code to subscribe and be notified of enemy death
    public delegate void EnemyDied(EnemyDemo deadEnemy);

    public event EnemyDied OnEnemyDied;

    // NOTE! This code should work for any speed value (large or small)

    //-----------------------------------------------------------------------------
    void Start()
    {
        // todo #2
        //   Place our enemy at the starting waypoint
	transform.position = waypointList[0].position;
	targetWaypointIndex = 1;

	size = waypointList.Count;

    }

    //-----------------------------------------------------------------------------
    void Update()
    {
	// Click on enemy
	
	if(Input.GetMouseButtonDown(0))
	{
		RaycastHit hit;
        	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);        

        	if(Physics.Raycast(ray, out hit, 100.0f))  
        	{  
                	if(hit.transform != null)
                	{
				health--;	
                	}
        	}  
	}


	if(health == 0)
	{
		Score.score++;
		Destroy(this.gameObject);
	}

	
        // todo #3 Move towards the next waypoint
	Vector3 targetPosition = waypointList[targetWaypointIndex].position;
	Vector3 movementDir = (targetPosition - transform.position).normalized;

	Vector3 newPosition = transform.position;
	newPosition += movementDir * speed * Time.deltaTime;

	transform.position = newPosition;

	float cosAngle = Vector3.Dot(targetPosition.normalized, this.transform.position.normalized);
	if((cosAngle >= 0.999999) && (targetWaypointIndex < size-1))
	{
		targetWaypointIndex++;
	}
	Debug.Log(cosAngle);
	
	/*
	if((Vector3.Distance(transform.position, targetPosition) < .2f) && (targetWaypointIndex < size-1))
	{
		//targetWaypointIndex++;
		//target = waypointList[targetWaypointIndex];
		//Test
	}
	*/


        // todo #4 Check if destination reaches or passed and change target
	
	bool enemyDied = false;
	if(enemyDied)
	{
		OnEnemyDied?.Invoke(this);
	}
    }

    //-----------------------------------------------------------------------------
    private void TargetNextWaypoint()
    {
    }
}
