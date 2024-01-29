using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemySMG : MonoBehaviour
{
    public GameObject ColParticle;
    private float speed = 10f;
    private int damage = 10;
    public Rigidbody2D rb;
    public GameObject Player;
    public AudioSource HitOnEnemy;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Health player = hitInfo.GetComponent<Health>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Instantiate(ColParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        Destroy(gameObject);
        Instantiate(ColParticle, transform.position, Quaternion.identity);
    }
}
