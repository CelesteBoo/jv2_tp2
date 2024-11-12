using System;
using UnityEngine;

public class Tower : MonoBehaviour, Hurtable
{
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private int minHealth = 800;
    [SerializeField] private int maxHealth = 1200;
    [SerializeField] private Teams team;
    private bool isDead = false;
    private int health;

    public bool IsDead => isDead;
    public Teams CurrentTeam => team;

    void Awake()
    {
        System.Random rnd = new System.Random();
        health = rnd.Next(minHealth, maxHealth);
    }

    public bool hurt(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
        return isDead;
    }
}