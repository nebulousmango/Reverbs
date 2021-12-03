using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class TimeObject : MonoBehaviour
{
    public TimeZone currentTimeZone;

    private Vector3 localVector;

    private void OnEnable()
    {
        CalculateLocalVector();
    }

    public void ToPresent()
    {
        transform.position = TimeExchange.instance.presentWorld.position + localVector;
        currentTimeZone = TimeZone.Present;
        CalculateLocalVector();
    }

    public void ToFuture()
    {
        transform.position = TimeExchange.instance.futureWorld.position + localVector;
        currentTimeZone = TimeZone.Future;
        CalculateLocalVector();
    }

    public void ToLimbo()
    {
        transform.position = Vector3.zero;
    }


    public void CalculateLocalVector()
    {
        switch (currentTimeZone)
        {
            case TimeZone.Present:
                localVector = transform.position - TimeExchange.instance.presentWorld.position;
                break;

            case TimeZone.Future:
                localVector = transform.position - TimeExchange.instance.futureWorld.position;
                break;

            default:
                localVector = Vector3.zero;
                break;
        }
    }

    public enum TimeZone
    {
        Present,
        Future
    }

}
