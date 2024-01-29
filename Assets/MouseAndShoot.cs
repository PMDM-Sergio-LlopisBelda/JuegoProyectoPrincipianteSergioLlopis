using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAndShoot : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource ShootSound;
    //float volume = 1f;

    Vector2 mousePos;
    bool facingRight = true;

    void Start()
    {
        
    }

    
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        // using mousePosition and player's transform (on orthographic camera view)
        var delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (delta.x >= 0 && !facingRight)
        { // mouse is on right side of player
            transform.localScale = new Vector3(1, 1, 1); // or activate look right some other way
            facingRight = true;
        }
        else if (delta.x < 0 && facingRight)
        { // mouse is on left side
            transform.localScale = new Vector3(1, -1, 1); // activate looking left
            facingRight = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void Shoot ()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        ShootSound.Play();

    }
}
