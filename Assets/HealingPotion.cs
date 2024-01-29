using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    public GameObject HealingParticle;
    public AudioSource HealingSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Instantiate(HealingParticle, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
            HealingSound.Play();
        }
    }
}
