using System.Collections.Generic;
using UnityEngine;

public class EnemyDemo : MonoBehaviour
{
    // todo #1 set up properties
    private int health = 3;
    public float speed = 3f;
    public int coins = 3;
    public int size;

    private int count;
    private int total;
    private bool passed;
    private bool finished;

    public float timer;
    public GameObject enemy;


    private Animator animator;

    public List<Transform> waypointList;

    private int targetWaypointIndex;

    public HealthBar healthBar;

    //Audio
    [SerializeField]
    public AudioSource deathSound;

    //public GameObject NI;

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

	count = 0;
	total = 0;
	//timer = 0;
	passed = false;
	finished = false;

	animator = GetComponent<Animator>();

	//Heath Bar
	healthBar.SetMaxHealth(3);

	//Death Sound
	deathSound = GetComponent<AudioSource>();

    }

    //-----------------------------------------------------------------------------
    void Update()
    {
	deathSound = GetComponent<AudioSource>();
	
	/*
	timer += Time.deltaTime;
	
	if(timer > 3)
        {
                    //var rot = Quaternion.Euler(Vector3(0, -90, 0));

                    NI = Instantiate(enemy, new Vector3(18, 9, 0), Quaternion.Euler(0, -90, 90));
                    timer = 0;
        }
	*/


	//Walking or Running Animation
	if((speed > 0 ) && (speed < 5))
	{
		animator.SetBool("isRunning", false);
		animator.SetBool("isWalking", true);

	}
	else if(speed >= 5)
	{
		animator.SetBool("isWalking", false);
		animator.SetBool("isRunning", true);
	}
	else
	{
		animator.SetBool("isWalking", false);
		animator.SetBool("isRunning", false);
	}

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
				healthBar.SetHealth(health);
                	}
        	}  
	}


	if(health == 0)
	{
		Score.score++;

		//Play Death Sound
		deathSound.Play();

		Destroy(this.gameObject);
	}

	
        // todo #3 Move towards the next waypoint
	Vector3 targetPosition = waypointList[targetWaypointIndex].position;
	Vector3 movementDir = (targetPosition - transform.position).normalized;

	Vector3 newPosition = transform.position;
	newPosition += movementDir * speed * Time.deltaTime;

	transform.position = newPosition;

	
	float cosAngle = Vector3.Dot(targetPosition.normalized, this.transform.position.normalized);


	if((cosAngle > 0.9999) && (targetWaypointIndex <= size-1))
	{
		passed = true;
	}

	
	if((passed) && (targetWaypointIndex <= size-1))
	{
		this.transform.position = targetPosition;

		count++;
		total++;
		if(targetWaypointIndex != size-1)
		{
			targetWaypointIndex++;
		}


                if((count == 3) && (finished == false))
                {
                        transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
                        count = 0;
                }

		passed = false;

	}


	if(this.transform.position == waypointList[waypointList.Count - 1].position)
	{
		speed = 0;
		Debug.Log("Finished");
		animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
		finished = true;

	}
	

	

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
