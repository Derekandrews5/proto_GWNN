﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyHealth : MonoBehaviour {
    public int startingHealth = 15;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float hitAmount;


 
    bool isDead;                                // Whether the enemy is dead.
                       


    void Awake() {
      
        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    void Update() {
     
        if (isDead) {
            gameObject.SetActive(false);
        }
    }


    public void TakeDamage(int amount, Vector3 hitPoint) {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;

     

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;
        Debug.Log(currentHealth);
     

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0) {
            // ... the enemy is dead.
            Death();
        }
    }


    void Death() {
        // The enemy is dead.
        isDead = true;
    }
    private void OnCollisionEnter(Collision collision) {
        hitAmount = collision.relativeVelocity.magnitude;
        
        TakeDamage((int)hitAmount, new Vector3(0,0,0));
      


        
    }

}