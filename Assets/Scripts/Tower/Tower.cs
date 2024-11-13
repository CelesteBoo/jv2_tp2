using System;
using UnityEngine;

public class Tower : MonoBehaviour, Hurtable, HidingSpot
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

    public void hurt(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }

    public bool isAlive()
    {
        return !isDead;
    }

    public Vector3 getPosition()
    {
        return gameObject.transform.position;
    }

    public Teams getTeam()
    {
        return team;
    }

    public float getDistanceFromPosition(Vector3 position)
    {
        Vector3 distance = gameObject.transform.position - position;
        return distance.magnitude;
    }

    public float getPositionX()
    {
        return gameObject.transform.position.x;
    }
}