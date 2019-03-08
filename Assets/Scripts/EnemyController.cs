using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    //transform for each of the enemies
    protected Vector2 startPosition;
    protected int damageValue, healthLevel;
    public int moveSpeed;
    protected int randNum;
    Rigidbody2D rigidBody;
    protected bool directionRight;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        
        randNum = Random.Range(1,3);
        // randNum = 1;

        if(randNum == 1) {
            Debug.Log("Moves Left at the start");
        } if(randNum == 2) {
            Debug.Log("Moves Right at the start");
            Flip();
        }
    }
    private void FixedUpdate()
    {
        Move(); 
    }

    protected virtual void Move()
    {
        Debug.Log(randNum);
        if(randNum == 1) {
            rigidBody.velocity = new Vector2(-moveSpeed, rigidBody.velocity.y);
        }
        if(randNum == 2) {
            rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
        }
    }

    protected void Flip() {
        Vector3 hookriScale = transform.localScale;
        hookriScale.x *= -1;
        transform.localScale = hookriScale;
    }

    protected void Die(GameObject enemy)
    {
        Destroy(enemy);
    }
}