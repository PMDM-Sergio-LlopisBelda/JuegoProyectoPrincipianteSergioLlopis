using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerWeapon;
    public GameObject DeathParticles;
    public int maxHealth = 100;
    public int currentHealth;

    public AudioSource HitSound;
    public AudioSource PlayerDeathSound;
    public AudioSource ReadyCooldown;
    public AudioSource HealingSound;

    public HealthBar healthBar;
    public HealCooldownBar HealCooldownBar;
    public Bullet Bullet;

    private float HealCooldown;
    public float startHealCooldown = 20f;
    private bool CooldownDone = true;

    public int strength = 0;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        HealCooldownBar.SetMaxCooldown(startHealCooldown);
        HealCooldown = startHealCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetMaxHealth(maxHealth);
        HealCooldownBar.SetMaxCooldown(startHealCooldown);
        HealCooldownBar.SetCooldown(HealCooldown);
        
        Bullet.AugmentStrength(strength);
        if (currentHealth <= 0)
        {
            Instantiate(DeathParticles, transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().GameOver();
            PlayerDeathSound.Play();
            PlayerWeapon.SetActive(false);
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        if (HealCooldown <= 0 && CooldownDone == true)
        {
            ReadyCooldown.Play();
            CooldownDone = false;
        }

        if (Input.GetButtonDown("Heal") && HealCooldown <= 0)
        {
            Healing(40);
            HealCooldown = startHealCooldown;
            CooldownDone = true;
            HealingSound.Play();
        }
        else
        {
            if(HealCooldown >= 0)
            {
                HealCooldown -= Time.deltaTime;
            }

        }

        if (startHealCooldown <= 9.9)
        {
            startHealCooldown = 10;
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Enemy")
        {
            TakeDamage(20);
        }
        if (col.gameObject.name == "BCube")
        {
            TakeDamage(20);
        }
        if (col.gameObject.tag == "HealingPotion")
        {
            Healing(40);
        }  
        if (col.gameObject.tag == "ExtraHeart")
        {
            maxHealth += 20;
        }
        if (col.gameObject.name == "LavaKiller")
        {
            currentHealth = 0;
        }
        if (col.gameObject.tag == "Dumbbell")
        {
            strength += 10;
        }
        if (col.gameObject.tag == "TimerHeart")
        {
            startHealCooldown -= 1.5f;
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HitSound.Play();
        healthBar.SetHealth(currentHealth);
    }
    public void Healing(int Heal)
    {
        currentHealth += Heal;

        healthBar.SetHealth(currentHealth);
    }
    
    

}
