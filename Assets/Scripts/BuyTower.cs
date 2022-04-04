using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTower : MonoBehaviour
{
    [SerializeField]
    private GameObject button;

    private bool isClicked;

    [SerializeField]
    private GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
	    gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
	    isClicked = false;

        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void TaskOnClick()
    {
	    if(isClicked == false)
            {
                    Debug.Log("Found T1");
		    GameObject instance = Instantiate(tower, new Vector3(-80, 22, 0), Quaternion.Euler(0, -90, 90));
		    isClicked = true;
            }

    }
}
