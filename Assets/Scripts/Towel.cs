using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towel : EnemyController
{
    //Origin, Direction, Range for Raycasting.
    public Transform rayOriginPoint;
    private Vector2 rayDir = new Vector2(-1,0);
    public float range;

    //Rigidbody2d
    Rigidbody2D rb;

    //enemies
    public GameObject TowelHead;
    public GameObject CamBij;

    //Spawn points
    public Transform WhereToSpawnCamBij, whereToSpawnBarBij;
    private Vector2 spawnPointBed, spawnPointBar;

    //GameObjects that it should hit
    GameObject bar, bed;

    //control variables
    private bool facingRight;
     
    private void Start()
    {
        bar = GameObject.Find("minibar");
        bed = GameObject.Find("bed");

        rb = GetComponent<Rigidbody2D>();

        spawnPointBed = new Vector2(WhereToSpawnCamBij.position.x, WhereToSpawnCamBij.position.y);
        spawnPointBar = new Vector2(whereToSpawnBarBij.position.x,whereToSpawnBarBij.position.y);
    }

    private void Update()
    {
        RaycastHit2D hitObject = Physics2D.Raycast(rayOriginPoint.position,rayDir,range);
        Debug.DrawRay(rayOriginPoint.position,rayDir*range);

        if(hitObject == true) {
            if(hitObject.collider.name == bed.name) {
                // Debug.Log(hitObject.collider.name);
                // rayDir *= -1;
                // facingRight = true;
                // Flip();
                
                Debug.Log(randomizer());
                

                if(randomizer())
                {
                    rayDir *= -1;
                    facingRight = true;
                    Flip();
                } else 
                {
                    Destroy(TowelHead);
                    Instantiate(CamBij, spawnPointBed,Quaternion.identity);
                }
                // Destroy(TowelHead);
                // Instantiate(CamBij, spawnPointBed,Quaternion.identity);
            }
            if(hitObject.collider.name == bar.name) {
                // Debug.Log(hitObject.collider.name);
                // rayDir *= -1;
                // facingRight = false;
                // Flip();
                
                Debug.Log(randomizer());

                if(randomizer())
                {
                    rayDir *= -1;
                    facingRight = false;
                    Flip();
                } else
                {
                    Destroy(TowelHead);
                    Instantiate(CamBij, spawnPointBar,Quaternion.identity);
                }

                // Destroy(TowelHead);
                // Instantiate(CamBij, spawnPointBar,Quaternion.identity);
            }
        }
    }

    protected override void Move()
    {
        // rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        base.Move();
        if(facingRight == false) {
            rb.velocity = new Vector2(-1, rb.velocity.y);
        }
        else {
            rb.velocity = new Vector2(1,rb.velocity.y);
        }
    }

    private bool randomizer()
    {
        var randomNo = Random.Range(1,3);
        if(randomNo == 1)
        {
            return true;
        } else 
        {
            return false;
        }
    }
}