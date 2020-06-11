using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    //
    public GameObject[] waypoints;
    //referentie naar de welke waypoint in de array waar we naartoe gaan
    int current = 0;
    //rotate object speed
    float rotspeed;
    //snelheid naar volgend waypoint
    public float speed;
    //omdat de waypoint lege objecten zijn kan het deze waypoint center missen, daarom standaard redius zetten die het niet kan missen
    float WPradius = 1;
    //sleep time
    public float sleeptime;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checkent van de afstand tussen de waypoints en object
        if(Vector3.Distance(waypoints[current].transform.position, transform.position)< WPradius)
        {
            //random locaties
            //eventueel met boolean toe te voegen
            //current = Random.Range(0, waypoints.Length);
            current++;
            if(current >= waypoints.Length)
            {
                current = 0;
             

            }      
        }

      
        //bewegen van het objecten --> huidige postitie, target , snelheid
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

    }


}
