using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypointFollower : MonoBehaviour
{
    private SpriteRenderer sprite;

    [SerializeField] private GameObject[] waypoints; //Array of waypoints
    private int currentWaypointIndex = 0; //Index of the current waypoint

    [SerializeField] private float speed = 5f; //Speed of the platform

    // Start is called before the first frame update
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = true; //Flip the sprite
    }

    // Update is called once per frame
    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f) //If the distance between the current waypoint and the platform is less than 0.1f
        {
            currentWaypointIndex++; //Increment the current waypoint index
            if(sprite.flipX == false)
            {
                sprite.flipX = true; //Flip the sprite
            }
            else
            {
                sprite.flipX = false; //Unflip the sprite
            }
            if(currentWaypointIndex >= waypoints.Length) //If the current waypoint index is greater than or equal to the length of the waypoints array
            {
                currentWaypointIndex = 0; //Set the current waypoint index to 0
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); //Move the platform towards the current waypoint
    }
}

