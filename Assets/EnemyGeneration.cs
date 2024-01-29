using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject[] enemiesLayout;
    public Transform Player;
    public Transform EnemyGenerator;
    private bool EnemyGeneratorTriggered = false;


    private Transform enemies;

    private bool EnemiesDead;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(EnemiesDead);
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        EnemiesDead = GameManager.AllEnemiesDead;
        float distancePlayer = Vector3.Distance(Player.transform.position, transform.position);

        if (EnemiesDead == true && distancePlayer <= 20)
        {
            int rand = Random.Range(0, enemiesLayout.Length);
            Instantiate(enemiesLayout[rand], transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }
}
