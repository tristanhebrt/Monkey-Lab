using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private CircleCollider2D attackRange;
    private bool inAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        attackRange = GetComponentInChildren<CircleCollider2D>(); // FIX THIS
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // if enemy is in the player's attack range
    private void OnTriggerEnter2D(Collider2D collision) // when the enemy collider is triggered
    {
        if (collision.gameObject.tag == "Enemy") // if it was triggered by the enemy
        {
            inAttackRange = true; // the enemy is in range
        }
    }

    // if enemy exits the player's attack range
    private void OnTriggerExit2D(Collider2D collision) // when the trigger exits
    {
        if (collision.gameObject.tag == "Enemy") // if the trigger is the enemy
        {
            inAttackRange = false; // the enemy is not in range
        }
    }

    public void Attack()
    {
        if (inAttackRange)
        {

        }
    }
}
