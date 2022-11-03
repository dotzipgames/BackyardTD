using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float moveSpeed;

    private Transform[] waypoints;
    private int waypointIndex;

    void Start()
    {
        waypointIndex = 0;
        transform.position = waypoints[waypointIndex].position;
        //moveSpeed = Random.Range(1f, 3f);
        moveSpeed = 6f;
    }

    void Update()
    {
        Move();
    }

    public void Waypoints(Transform[] wps)
    {
        waypoints = wps;
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].position)
        {
            waypointIndex++;
        }

        if (waypointIndex == waypoints.Length)
        {
            Enemy spawnedEnemy = GameObject.Find("Enemy").GetComponent<Enemy>();
            spawnedEnemy.spawnedEnemy -= 1;
            Destroy(enemy);
        }
    }
}