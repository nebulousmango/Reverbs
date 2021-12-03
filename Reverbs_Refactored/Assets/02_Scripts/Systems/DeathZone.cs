using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
   public void OnDeath()
    {
        GameManager.instance.LoadDefaultSaveData();
    }
}
