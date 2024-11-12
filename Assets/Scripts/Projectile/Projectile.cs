using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int minDmg = 8;
    [SerializeField] private int maxDmg = 12;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float timeToLive = 9f;
    [SerializeField] private Teams team;
    private int damage;
    private Vector2 direction;
    private ObjectPool pool;
    private new Rigidbody2D rigidbody;
    private float maxTimeToLive;

    void Awake()
    {
        maxTimeToLive = timeToLive;
        rigidbody = GetComponent<Rigidbody2D>();
        if (team == Teams.TEAM1)
            pool = Finder.BlueSpellPool;
        else
            pool = Finder.GreenSpellPool;
        System.Random rnd = new System.Random();
        damage = rnd.Next(minDmg, maxDmg);
    }

    private void Update()
    {
        rigidbody.position += (direction * speed) * Time.deltaTime;
        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
            pool.Release(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.gameObject.GetComponent<Hurtable>();
        //trouver une autre façon d'éviter la collision avec le caster
        if (other != null && timeToLive < maxTimeToLive - 0.5f)
        {
            other.hurt(damage);
            pool.Release(gameObject);
        }
    }

    public void setDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}