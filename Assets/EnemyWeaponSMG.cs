using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponSMG : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource ShootSound;
    Vector2 mousePos;
    bool facingRight = true;
    public Transform Player;
    private float TimeBtwShots;
    public float startTimeBtwShots;
    public GameObject SmokeParticle;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        TimeBtwShots = startTimeBtwShots;
    }


    void Update()
    {
        if (Player.transform.position.x >= 0 && !facingRight)
        { // mouse is on right side of player
            transform.localScale = new Vector3(1, 1, 1); // or activate look right some other way
            facingRight = true;
        }
        else if (Player.transform.position.x < 0 && facingRight)
        { // mouse is on left side
            transform.localScale = new Vector3(1, -1, 1); // activate looking left
            facingRight = false;
        }
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, Player.position);
        if (hitInfo)
        {
            if (hitInfo.transform == Player) ;
            {
                if (Player == null)
                {
                    TimeBtwShots -= Time.deltaTime;
                }
                else if (Player != null)
                {

                    if (TimeBtwShots <= 0)
                    {
                        Shoot();
                        TimeBtwShots = startTimeBtwShots;
                    }
                    else
                    {
                        TimeBtwShots -= Time.deltaTime;
                    }

                }

            }

        }

    }

    void FixedUpdate()
    {
        float angle = Mathf.Atan2(Player.transform.position.y, Player.transform.position.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(SmokeParticle, transform.position, Quaternion.identity);
    }
}
