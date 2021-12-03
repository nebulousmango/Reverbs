using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject go_Water;
    [SerializeField] GameObject go_Enemy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInChildren<PlayerController>() == true)
        {
            go_Water.SetActive(false);
            go_Enemy.SetActive(false);
        }
    }
}
