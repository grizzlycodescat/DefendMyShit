using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HookriController : MonoBehaviour
{
    public Transform originPoint;
    private Vector2 dir = new Vector2(-1,0);
    public float range, speed;
    Rigidbody2D rb;
    GameObject bar,bed;

    public GameObject towelHead;

    // Start is called before the first frame update
    void Start()
    {
        bar = GameObject.Find("minibar");
        bed = GameObject.Find("bed");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Added debug line to view the ray being cast out, uncomment to see
        // Debug.DrawRay(originPoint.position,dir * range);
        RaycastHit2D hit = Physics2D.Raycast(originPoint.position,dir,range);

        if(hit == true) {
            Debug.Log(hit.collider.name);
            if(hit.collider.name == bed.name) {
                // Debug.Log(bed.name+ "," + hit.collider.name);
                Flip();
                speed *= -1;
                dir *= -1;
            }
            if(hit.collider.name == bar.name) {
                Flip();
                speed *= -1;
                dir *= -1;
            }
            if(hit.collider.name == "Dan") { 
                Debug.Log(hit.collider.name + " has been hit");
                //choice: Either attack him, or ignore him.
                attackDan();
            }
        }
    } 

    void FixedUpdate()
    {
        rb.velocity = new Vector2(-speed,rb.velocity.y);       
    }
    void Flip() {
        Vector3 hookriScale = transform.localScale;
        hookriScale.x *= -1;
        transform.localScale = hookriScale;
    }
    public void attackDan() {
        Debug.Log("dan Has Been Attacked");
        // Destroy(towelHead);
    }
}