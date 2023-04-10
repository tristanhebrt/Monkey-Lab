using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    // Animator
    public Animator anim; // get reference to the enemy's animator

    // Enemy movement
    private EnemyAI enemyAI; // get reference to the EnemyAI script
    private Vector2 movement = Vector2.zero;

    void Start()
    {
        enemyAI = GetComponent<EnemyAI>(); // get reference to the EnemyAI script
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAI.directionToPlayer != null && enemyAI.directionToPlayer != Vector2.zero)
        {
            movement = enemyAI.directionToPlayer; // get directionToPlayer from EnemyAI
        }

        anim.SetFloat("Horizontal", movement.x); // assign the animator parameter "Horizontal" to the horizontal input
        anim.SetFloat("Vertical", movement.y); // assign the animator parameter "Vertical" to the vertical input

        // check if the enemy is moving or not, and set the "CurrentSpeed" parameter accordingly
        if (enemyAI.inRange) // if the player is in range
        {
            anim.SetBool("IsMoving", true); // set the "IsMoving" parameter to true

        }
        else
        {
            anim.SetBool("IsMoving", false); // set the "IsMoving" parameter to false
        }
    }
}
