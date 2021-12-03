using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjection : MonoBehaviour
{
    public Transform fromWorldRoot;
    public Transform toWorldRoot;
    public Transform playerToProject;

    public Transform projection;

    private Vector3 localVector;


    private void Update()
    {
        //calculate future players position relative to future world
        localVector = playerToProject.position - fromWorldRoot.position;

        //apply calculated position to projection in the present world
        projection.position = toWorldRoot.position + localVector;
    }


}
