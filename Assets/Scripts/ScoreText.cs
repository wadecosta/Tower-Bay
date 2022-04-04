using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public static TextMeshProUGUI score_text;

    // Start is called before the first frame update
    void Start()
    {
	    TextMeshProUGUI score_text = GetComponent<TextMeshProUGUI>();
	    score_text.SetText("Coins: 0");
    }

    // Update is called once per frame
    void Update()
    {
	    TextMeshProUGUI score_text = GetComponent<TextMeshProUGUI>();
            score_text.SetText("Coins: " + Score.score);
        
    }
}
