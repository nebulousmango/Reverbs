using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    //int i_PlayerCount;

    /*
    private void Update()
    {
        if (i_PlayerCount == 1)
        {
            Debug.Log("Play cutscene: monster making tunnels while chasing prey.");
            gameObject.SetActive(false);
        }
    }
    */

    void OnTriggerEnter2D(Collider2D other)
    {
        //i_PlayerCount++;
        Debug.Log("Play cutscene: monster making tunnels while chasing prey.");
        gameObject.SetActive(false);
    }
}
