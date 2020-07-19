﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public bool isDead;
    public MeshRenderer mesh;
    public float velocity;
    public GameManager gm;
    public BoxCollider collider;

    public GameObject[] obstacles;


    public int maxSpawnedObstacles;

    public Vector3 center;
    public Vector3 size;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacles();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckCameraPosition();
        /*if(isDead)
        {
            // TODO, back in pool, need other code to respawn terrain
            this.transform.position = gm.b_spawner.transform.position;
            isDead = false;
        }*/
    }

    void Move()
    {
        //this.transform.localPosition = Vector3.MoveTowards(transform.position, gm.b_goal.transform.position, velocity * Time.deltaTime);
    }

    void SpawnObstacles()
    {
        for(int i = 0; i < maxSpawnedObstacles; i++)
        {
            int index = Random.Range (0, obstacles.Length);
            GameObject newobj = Instantiate(obstacles[index], transform.position, Quaternion.identity);
            Vector3 pos = new Vector3(Random.Range(1, 500), 0, Random.Range(1, 500));
            newobj.transform.parent = transform;
            newobj.transform.position = pos; 
        }
    }

    void CheckCameraPosition()
    {
        float colliderSize = collider.bounds.size.z;
        //print("size: " + collider.bounds.size.z);
        if ((this.transform.position.z + colliderSize) < gm.camera.transform.position.z)
        {
            isDead = true;
        }
    }

}
