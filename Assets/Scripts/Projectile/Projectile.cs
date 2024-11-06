using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int minDmg = 8;
    [SerializeField] private int maxDmg = 12;
    private int damage;

    void Awake()
    {
        System.Random rnd = new System.Random();
        damage = rnd.Next(minDmg, maxDmg);
    }

    private void Update()
    {
        //vole vers direction
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.gameObject.GetComponent<Hurtable>();
        if (other != null)
        {
            other.hurt(damage);
        }
    }
}