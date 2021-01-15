//////
/// name: jeanri Bosch
/// date: 06/01/2021
/// description: attach this to kinematic platform to set a series of loacations to go between relative to the starting position
//////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMovingPlatformPt2 : MonoBehaviour
{
    [Tooltip("This is a collection of points relative to where the platform started that it will move between")]
    public Vector3[] waypoints = { Vector3.zero, new Vector3(0,4,0) };
    [Tooltip("How fast should teh platform move?")]
    public float speed = 1;
    private int currentWaypoint = 0;
    [Tooltip("This is how close is good enough before switching to the next point")]
    public float closeEnough = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //adjust waypoints to world positions from the local transform positions
        for(int i = 0; i < waypoints.Length; ++i)
        {
            waypoints[i] += transform.position;
        }
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        //get a vector from our currect location to the current waypoint
        Vector3 toWaypoint = waypoints[currentWaypoint] - transform.position;
        //check if we are at the currect waypoint(or close enough) if so start moving to next 
        if(toWaypoint.sqrMagnitude < closeEnough * closeEnough)
        {
            ++currentWaypoint;
            //make sure in array still loop back to start if past
            if(currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
            toWaypoint = waypoints[currentWaypoint] - transform.position;
        }
        //normalize toWaypoint so we can scale consistantly
        toWaypoint.Normalize();
        //move a little each frame to next point
        transform.position += toWaypoint * speed * Time.fixedDeltaTime;

    }
}
