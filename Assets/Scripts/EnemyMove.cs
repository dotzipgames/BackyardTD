using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float dmg;
    [SerializeField] private float moveSpeed;
    private PlayerHealth player;

    private Transform[] waypoints;
    private int waypointIndex;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        waypointIndex = 0;
        transform.position = waypoints[waypointIndex].position;
        moveSpeed = Random.Range(1f, 3f);
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
            Enemy.enemies.Remove(gameObject);
            player.TakeDmg(dmg);
            Destroy(gameObject);
        }
    }
}