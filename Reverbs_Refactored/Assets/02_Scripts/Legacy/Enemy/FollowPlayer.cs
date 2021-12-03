using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] float f_EnemySpeed = 3;
    Transform tr_Player;

    void Start()
    {
        tr_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, tr_Player.position, f_EnemySpeed * Time.deltaTime);
    }
}
