using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyWeapon;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance = 0;

    public Transform Player;
    public GameObject EnemyParticle;
    public int Health = 100;

    //public AudioSource EnemyDestroySound;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
       if(Vector2.Distance(transform.position, Player.position) > stoppingDistance)
       {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
       }
       else if(Vector2.Distance(transform.position, Player.position) < stoppingDistance && Vector2.Distance(transform.position, Player.position) > retreatDistance)
       {
            transform.position = this.transform.position;
       }
       else if(Vector2.Distance(transform.position, Player.position) < retreatDistance)
       {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, -speed * Time.deltaTime);
       }

    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(EnemyParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
        EnemyWeapon.SetActive(false);
        //EnemyDestroySound.Play();
    }

}