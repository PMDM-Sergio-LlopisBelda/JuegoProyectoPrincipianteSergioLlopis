using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject ColParticle;
    public float speed = 20f;
    public int damage = 25;
    private int totaldamage;
    public Rigidbody2D rb;

    public AudioSource HitOnEnemy;
    public int Strength = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        totaldamage = damage + Strength;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(totaldamage);
            //Instantiate(ColParticle, transform.position, Quaternion.identity);
            //Destroy(gameObject);
        }
        Destroy(gameObject);
        Instantiate(ColParticle, transform.position, Quaternion.identity);

    }
    public void AugmentStrength(int ActualStrength)
    {
        Strength = ActualStrength;
    }

}
