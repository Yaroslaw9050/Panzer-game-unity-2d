using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankSetting : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    private Vector3 spawnPosition;
    private void Start()
    {
        currentHealth = maxHealth;
        spawnPosition = transform.position;
    }
    public void TakeDamaga(float value)
    {
        currentHealth -= value;
        if(currentHealth <= 0)
        {
            transform.position = spawnPosition;
            currentHealth = maxHealth;
        }
    }
    public void Repair(float value)
    {
        currentHealth += value;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
