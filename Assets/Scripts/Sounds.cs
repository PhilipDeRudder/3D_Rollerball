using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource coinhit;
    public AudioSource levelUp;
    public AudioSource gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            coinhit.Play();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            levelUp.Play();
        }
        if (collision.gameObject.tag == "deadzone")
        {
            gameOver.Play();
        }

       
    }
}
