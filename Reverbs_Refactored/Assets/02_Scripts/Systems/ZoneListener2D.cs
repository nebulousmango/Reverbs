using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ZoneListener2D : MonoBehaviour
{
    public string listenTo;
    public UltEvent onZoneEnter;
    public UltEvent onZoneExit;
    public GameObject inZone;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains(listenTo))
        {
            inZone = collision.gameObject;
            onZoneEnter.Invoke();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains(listenTo))
        {
            inZone = null;
            onZoneExit.Invoke();
        }
    }
}
