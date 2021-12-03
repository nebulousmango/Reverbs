using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaypoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInChildren<PlayerController>() == true)
        {
            FindObjectOfType<CamZoom>().StartWaterZoom();
        }
    }
}
