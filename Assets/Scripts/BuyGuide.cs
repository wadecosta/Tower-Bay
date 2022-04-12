using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGuide : MonoBehaviour
{
    public bool t1Clicked;
    public bool t2Clicked;
    public bool t3Clicked;


    // Start is called before the first frame update
    void Start()
    {
	    t1Clicked = false;
    	    t2Clicked = false;
            t3Clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
	    /*
	    if(gameObject.tag == "T1")
	    {
		    t1Clicked = true;
		    Debug.Log(t1Clicked);
	    }
	    */
        
    }

    void t1()
    {
	    t1Clicked = true;
	    Debug.Log("T1 Clicked");
    }


}
