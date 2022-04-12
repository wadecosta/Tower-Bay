using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyT1 : MonoBehaviour
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
	    Debug.Log("hello there");
    }

    void TaskOnClick()
    {
	    if((isClicked == false) && (Score.score > 0))
            {
                    Debug.Log("Found T1");
		    Instantiate(tower, new Vector3(15, 7, -1), Quaternion.Euler(0, -90, 90));
		    isClicked = true;
		    Score.score--;
            }

    }
}
