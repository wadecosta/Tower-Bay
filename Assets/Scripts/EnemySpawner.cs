using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float timer;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
	    timer = 0;
	    //Instantiate(enemy, new Vector3(18, 9, 0), Quaternion.Euler(0, -90, 90));
    }

    // Update is called once per frame
    void Update()
    {
	    timer += Time.deltaTime;
	    Debug.Log(timer);

	    if(timer > 3)
	    {
		    //var rot = Quaternion.Euler(Vector3(0, -90, 0));

		    Instantiate(enemy, new Vector3(18, 9, 0), Quaternion.Euler(0, -90, 90));
		    timer = 0;
	    }
        
    }
}
