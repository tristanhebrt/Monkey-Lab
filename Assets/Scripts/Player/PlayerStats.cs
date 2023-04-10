using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Variables
    public int playerMaxHealth = 10; // player's maximum health
    public int playerDamage = 5; // player attack power
    private int playerHealth; // player's current health
    public bool isDead;

    // Component references
    private PlayerAnim playerAnim;

    void Start()
    {
        isDead = false; // player is alive

        // assign the PlayerAnim script
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnim>();

        playerHealth = playerMaxHealth; // initialise the player's health
    }

    public void TakeDamage(int enemyDamage)
    {
        playerHealth -= enemyDamage; // damage the player
    }

    public void CheckHealth()
    {
        if (playerHealth <= 0) // if the player health is 0 or under
        {
            PlayerDeath(); // deal with it
        }
    }

    private void PlayerDeath()
    {
        isDead = true;

        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart the scene
    }
}
