using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    public float playerSpeed = 4f; // player speed
    public Vector2 movement; // store the player movement

    // Component references
    private Rigidbody2D rb; // get reference to the player's rigidbody
    private PlayerStats playerStats; // reference to the PlayerStats scipt attached to the player
    private PlayerActions playerActions; // reference to the PlayerStats scipt attached to the player

    void Start()
    {
        // assign the PlayerStats script
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        // assign the PlayerActions script
        playerActions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerActions>();

        // assign player's rigidbody2d
        rb = GetComponentInChildren<Rigidbody2D>(); 
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // stop all rotation on player
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.isDead == true) // if the player is dead
        {
            movement = Vector2.zero; // set movement to zero in case the player was moving
            return; // end the method
        }

        if (Input.GetKeyDown(KeyCode.Space)) // if space is pressed
        {
            // jump
        }

        if (Input.GetKeyDown(KeyCode.F)) // if F is pressed
        {
            // attack
            playerActions.Attack();
        }

        movement.x = Input.GetAxisRaw("Horizontal"); // get the keyboard horizontal input (A D)
        movement.y = Input.GetAxisRaw("Vertical"); // get the keyboard vertical input (W S)

        movement = Vector2.ClampMagnitude(movement, 1f); // make the movement speed is consistent
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime); // move the player
    }
}
