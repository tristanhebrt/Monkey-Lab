using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Variables
    public float moveSpeed = 1f; // enemy move speed
    public Vector2 directionToPlayer; // directional vector to the player
    
    public bool inRange; // is the player in the enemy's range
    public float awarenessDistance = 3; // how far the enemy sees
    public float playerDistance; // assign the player distance

    // Component references
    private GameObject player; // get reference to player
    private Rigidbody2D rb; // get reference to enemy's rigidbody
    private PlayerStats playerStats; // reference to the PlayerStats scipt attached to the player

    void Start()
    {
        // get player game object
        player = GameObject.FindGameObjectWithTag("PlayerBody");

        // assign the PlayerStats script
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        // get enemy's rigidbody2d
        rb = GetComponentInChildren<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // stop all rotation on enemy
    }

    void FixedUpdate()
    {
        playerDistance = Vector3.Distance(transform.position, player.transform.position); // get a vector from the enemy to the player
        
        Debug.DrawLine(transform.position, player.transform.position, Color.red); // visualise the vector
        Debug.Log("playerDistance: " + playerDistance); // get the distance

        // see if the player is in range or not
        if (playerDistance < awarenessDistance)
        {
            inRange = true;
        } 
        
        else
        {
            inRange = false;    
        }

        if (inRange) // if the player is in range
        {   
            if (playerStats.isDead == false) // if the player is alive
            {
                chase(); // call for chase function
            }
            else // if the player is dead
            {
                inRange = false; // player is no longer in range
            }
        }
    }

    // get directions to player and move enemy to those directions
    private void chase()
    {
        // get the direction to player vector
        directionToPlayer = (player.transform.position - transform.position).normalized;

        // move enemy position to player's position
        rb.MovePosition(rb.position + directionToPlayer * moveSpeed * Time.fixedDeltaTime);
    }
}
