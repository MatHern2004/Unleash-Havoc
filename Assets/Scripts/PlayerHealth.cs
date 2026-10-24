using System;
using Unity.VisualScripting;
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
    // Next Scene
    private int secondLevel = 1;
    // To get the name of the scene
    private String scene;

    // Update is called once per frame
    void Update()
    {
        // If the player health is less than one
        if (health < 1)
        {
            scene = SceneManager.GetActiveScene().name;
            // Update scene depending on the one the player is loaded into
            switch (scene)
            {
                case "Level1":
                SceneManager.LoadScene(firstLevel);
                break;
                case "Level2":
                SceneManager.LoadScene(secondLevel);
                break;
                default:
                Debug.Log("Error no scene available");
                break;
            }
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
        }
          // If the enemyType is basic and the invincibilityTime is less than the current time, allow for damage by 1
        else if (enemyType == "Big" && Time.time > invincibleUntil)
        {
            // Remove one health point from the player
            health -= 2;
            // Give them some invinsibility time
            invincibleUntil = invincibilityTime + Time.time;
        }
    }
}
