using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public GameObject Player;
    private int life;
    private bool dead;
    
    // Start is called before the first frame update
   private void Start()
    {
        life = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //if (dead == true)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "BCube")
        {
            TakeDamage(1);
        }
        if (col.gameObject.name == "Enemy")
        {
            TakeDamage(1);
        }
        if (col.gameObject.name == "HealingPotion")
        {
            life += 1;
            hearts[life].SetActive(true);
        }
    }
    public void TakeDamage(int d)
    {
        if (life >= 1)
        {
            life -= d;
            hearts[life].SetActive(false);
            if (life < 1)
            {
                FindObjectOfType<GameManager>().GameOver();
            }
        }
    }
    
}
