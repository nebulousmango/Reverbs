using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public GameObject objectCollider;
    public GameObject destructionEffect;
    public SpriteRenderer objectBody;

    public Sprite normal, destroyed;

    public bool disappearOnDestroy;

    public void Destroyed()
    {
        destructionEffect.SetActive(true);
        objectCollider.SetActive(false);
        if (disappearOnDestroy)
        {
            objectBody.enabled = false;
        }
        else
        {
            objectBody.sprite = destroyed;
        }
        
    }

}
