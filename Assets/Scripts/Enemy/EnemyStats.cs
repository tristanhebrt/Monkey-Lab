using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyHealth = 10; // enemy health
    public int enemyDamage = 2; // enemy attack power

    private PlayerStats playerStats;

    void Start()
    {
        enemyHealth = 10; // initialise the enemy health
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>(); // find PlayerStats script on the player
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBody") // if it collided with the player
        {
            Attack(); // attack the player
        }
    }

    private void Attack()
    {
        playerStats.TakeDamage(enemyDamage); // damage the player with the enemy damage
        playerStats.CheckHealth(); // check if player is dead
    }
}
