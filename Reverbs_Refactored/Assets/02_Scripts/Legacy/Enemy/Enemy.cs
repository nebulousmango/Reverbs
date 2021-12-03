using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    FollowPlayer followPlayer;

    void Start()
    {
        followPlayer = GetComponent<FollowPlayer>();
        followPlayer.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInChildren<PlayerController>() == true)
        {
            followPlayer.enabled = true;
        }
    }
}
