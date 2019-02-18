using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookriController : MonoBehaviour
{
    public Transform originPoint;
    private Vector2 dir = new Vector2(-1,0);
    public float range, speed;
    Rigidbody2D rb;
    GameObject bar;
    GameObject bed;
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
        Debug.DrawRay(originPoint.position,dir * range);
        RaycastHit2D hit = Physics2D.Raycast(originPoint.position,dir,range);
        if(hit == true) {
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
}
