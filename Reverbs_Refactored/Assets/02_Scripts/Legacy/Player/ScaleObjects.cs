using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObjects : MonoBehaviour
{
    [SerializeField] float f_Scale;
    GameObject[] go_SceneObjects;

    void ScaleObject()
    {
            go_SceneObjects = GameObject.FindGameObjectsWithTag("Object");
            foreach (GameObject obj in go_SceneObjects)
            {
                obj.transform.localScale = new Vector3(f_Scale, f_Scale, f_Scale);
            }
    }
}
