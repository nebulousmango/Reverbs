using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chaser : MonoBehaviour
{
    public bool isTriggered;

    [Range(0,5)]
    public float chaseSpeed;

    public ZoneListener2D triggerZone;

    private Vector3 distanceToChasee;

    private Vector3 leftFacingScale;
    private Vector3 rightFacingScale;
    private float yLock;

    private void Start()
    {
        leftFacingScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        rightFacingScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        yLock = transform.position.y;
        
    }


    private void Update()
    {
        if (isTriggered == false)
            return;

        Chase();
    }


    public void Chase()
    {
        LookAtChasee();
        distanceToChasee = triggerZone.inZone.transform.position - transform.position;
        transform.position += distanceToChasee * chaseSpeed * Time.deltaTime;
        //transform.DOMoveY(yLock, Time.deltaTime);
    }

    public void LookAtChasee()
    {
        if (triggerZone.inZone.transform.position.x < transform.position.x)
        {
            transform.localScale = leftFacingScale;
        }
        else
        {
            transform.localScale = rightFacingScale;
        }
    }


    public void SetTriggered(bool __value)
    {
        isTriggered = __value;     
    }


}
