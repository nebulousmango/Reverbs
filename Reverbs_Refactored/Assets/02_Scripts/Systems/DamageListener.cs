using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;

public class DamageListener : MonoBehaviour
{
    public UltEvent onDamage;
    public string damager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains(damager) || damager.Length == 0)
        {
            onDamage.Invoke();
        }
       
    }
}
