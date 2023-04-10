using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    // Component references
    private Animator anim; // get reference to the player's animator
    private PlayerController playerController; // reference to the PlayerController scipt attached to the player
    private PlayerStats playerStats; // reference to the PlayerStats scipt attached to the player

    void Start()
    {
        // assign the player's animator
        anim = GameObject.FindGameObjectWithTag("PlayerBody").GetComponent<Animator>();

        // assign the PlayerController script
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        // assign the PlayerStats script
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    void Update()
    {
        anim.SetFloat("Horizontal", playerController.movement.x); // assign the animator parameter "Horizontal" to the horizontal input
        anim.SetFloat("Vertical", playerController.movement.y); // assign the animator parameter "Vertical" to the vertical input
        
        anim.SetFloat("CurrentSpeed", playerController.movement.sqrMagnitude); // see if the player is moving or stopped
        
        anim.SetBool("IsDead", playerStats.isDead); // assign the animator parameter "IsDead" to true
    }
}
