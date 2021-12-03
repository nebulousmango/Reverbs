using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    [SerializeField] GameObject go_Player;
    [SerializeField] GameObject go_ObjectPrefab;
    Vector2 v2_playerPosition;

    private void Update()
    {
        InstantiateObject();
    }

    void InstantiateObject()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            v2_playerPosition = go_Player.transform.position;
            GameObject currentObject = Instantiate(go_ObjectPrefab);
            currentObject.transform.position = v2_playerPosition;
        }
    }
}
