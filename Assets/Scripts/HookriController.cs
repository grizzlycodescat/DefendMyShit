using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookriController : MonoBehaviour
{
    public float moveSpeed = 3f;
    Transform barLeftWaypoint, bedRightWaypoint;
    Vector3 localScale;
    bool movingRight = true;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D> ();
        barLeftWaypoint = GameObject.Find("Bar_Left_Waypoint").GetComponent<Transform> ();
        bedRightWaypoint = GameObject.Find("Bed_Right_Waypoint").GetComponent<Transform> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= barLeftWaypoint.position.x) {
            movingRight = false;
        }
        if(transform.position.x <= bedRightWaypoint.position.x) {
            movingRight = true;
        }

        if(movingRight){
            moveRight();
        } else {
            moveLeft();
        }
    } 

    void moveRight() {
        movingRight = true;
        localScale.x = 1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
    }

    void moveLeft() {
        movingRight = false;
        localScale.x = -1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
    }
}
