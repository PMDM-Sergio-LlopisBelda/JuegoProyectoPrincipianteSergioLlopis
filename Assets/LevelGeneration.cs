using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] objects;
    //public GameObject[] enemies;
    private bool EnemiesAreadySpawned = false;
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, objects.Length);
        Instantiate(objects[rand], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        /*Player = GameObject.FindGameObjectWithTag("Player").transform;
        float distancePlayer = Vector3.Distance(Player.transform.position, transform.position);

        if (EnemiesAreadySpawned == false && distancePlayer <= 16)
        {
            EnemiesAreadySpawned = true;
            int enemrand = Random.Range(0, enemies.Length);
            Instantiate(enemies[enemrand], transform.position, Quaternion.identity);
        }*/
    }
}
