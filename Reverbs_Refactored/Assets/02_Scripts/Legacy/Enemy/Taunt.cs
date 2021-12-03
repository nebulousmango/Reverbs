using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taunt : MonoBehaviour
{
    FollowPlayer followPlayer;
    bool b_PlayerNearby; // b_EnemyTriggered;

    void Start()
    {
        followPlayer = GetComponentInParent<FollowPlayer>();
        followPlayer.enabled = false;
    }

    private void Update()
    {
        TriggerEnemy();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInChildren<PlayerController>() == true)
        {
            Debug.Log("Press E to taunt");
            b_PlayerNearby = true;
            //b_EnemyTriggered = true;
        }
    }

    void TriggerEnemy()
    {
        if (Input.GetKeyDown(KeyCode.E) && b_PlayerNearby == true /*b_EnemyTriggered == true*/ )
        {
            followPlayer.enabled = true;
        }
    }
}
