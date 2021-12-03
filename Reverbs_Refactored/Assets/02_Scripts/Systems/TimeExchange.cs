using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeExchange : MonoBehaviour
{
    public static TimeExchange instance;

    public Transform presentWorld, futureWorld;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }    
}

/*
 * TO DO
 * 
 * projection view - 1a //DONE
 * enemy chases player - 1b //DONE
 * pushing and pulling objects - 1c //DONE
 * timeobject_vines - 1d // DONE
 * player swinging - 1d
 * burrowing enemy - 1f
 * 
 */
