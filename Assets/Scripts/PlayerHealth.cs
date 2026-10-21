using System;
using UnityEngine;
using UnityEngine.SceneManagement; // For using Unity functions

public class PlayerHealth : MonoBehaviour
{
    // Health of the player
    [SerializeField] private int health = 3;
    // Invincibility Frames
    [SerializeField] private float invincibilityTime = 3.0f;
    // Actual Invincibility Until
    private float invincibleUntil;
    // EnemyMovement script for its Type
    EnemyMovement enemyName;
    // Beginning Scene
    private int firstLevel = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            Debug.Log("Restart the Level, Player Died!");
            // Restart the Level
            SceneManager.LoadScene(firstLevel);
        }
    }

    public void TakeDamage(String enemyType)
    {
        // If the enemyType is basic and the invincibilityTime is less than the current time, allow for damage by 1
        if (enemyType == "Basic" && Time.time > invincibleUntil)
        {
            // Remove one health point from the player
            health -= 1;
            // Give them some invinsibility time
            invincibleUntil = invincibilityTime + Time.time;
            Debug.Log(invincibilityTime);
            Debug.Log(Time.time);
            // Log to check it works
            Debug.Log("Enemy hit Player and has invincibility frames");
        }
    }
}
