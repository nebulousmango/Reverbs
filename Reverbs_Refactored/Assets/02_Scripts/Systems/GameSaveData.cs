using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSaveData", menuName = "Reverbs/SaveData", order = 1)]  
public class GameSaveData : ScriptableObject
{
    public Vector3 presentPlayerPosition, futurePlayerPosition;
}
