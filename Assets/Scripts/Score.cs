using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    
    public Text scoreText;
    private int score;


    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }


    private void Start()
    {
        score = 0;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            score++;
            Destroy(other.gameObject);
           
        }
       
    }
    

}
