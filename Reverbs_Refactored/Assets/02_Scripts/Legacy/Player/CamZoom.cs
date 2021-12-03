using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamZoom : MonoBehaviour
{
    public float zoomedInSize;
    public float zoomedOutSize;
    public float waterZoomSize;
    public float zoomTime;

    /*
    public float f_CameraSize;
    public float f_CameraLimit;
    public float f_CameraReset;
    public float f_increment;
    public float f_TimeLerp;
    public float f_TimeLerpValue;
     
    public bool b_ZoomIn = false;
    public bool b_ZoomOut = false;
    public bool b_ResetZoomIn = false;
    public bool b_ResetZoomOut = false;

    private void Update()
    {
        f_CameraSize = Camera.main.orthographicSize;
        f_TimeLerpValue = f_TimeLerp * Time.deltaTime;

        if(b_ZoomIn)
        {
            ZoomIn();
        }
        if (b_ZoomOut)
        {
            ZoomOut();
        }
        if (b_ResetZoomIn)
        {
            ResetZoomIn();
        }
        if (b_ResetZoomOut)
        {
            ResetZoomOut();
        }
    }

    void ZoomOut()
    {
        if (Camera.main.orthographicSize < f_CameraLimit)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + f_increment, f_TimeLerp * Time.deltaTime);
        }
        else if (Camera.main.orthographicSize > f_CameraLimit) b_ZoomOut = false;
    }

    void ZoomIn()
    {
        if (Camera.main.orthographicSize > 2f)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + -f_increment, f_TimeLerp * Time.deltaTime);
        }
        else if (Camera.main.orthographicSize < 2f) b_ZoomIn = false;
    }

    void ResetZoomIn()
    {
        if (Camera.main.orthographicSize < f_CameraReset)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + f_increment, f_TimeLerp * Time.deltaTime);
        }
        else if (Camera.main.orthographicSize > f_CameraReset) b_ResetZoomIn = false;
    }

    void ResetZoomOut()
    {
        if (Camera.main.orthographicSize > f_CameraReset)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + -f_increment, f_TimeLerp * Time.deltaTime);
        }
        else if (Camera.main.orthographicSize < f_CameraReset) b_ResetZoomOut = false;
    }

    IEnumerator SwitchZoom()
    {
        b_ZoomIn = true;
        yield return new WaitForSeconds(1);
        b_ResetZoomIn = true;

    }

    IEnumerator WaterZoom()
    {
        b_ZoomOut = true;
        yield return new WaitForSeconds(2);
        b_ResetZoomOut = true;

    }
    */

    public void StartSwitchZoom(GameObject __zoomFrom, GameObject __zoomTo)
    {
        //StartCoroutine(SwitchZoom());

        Sequence __switchZoomSequence = DOTween.Sequence();

        __switchZoomSequence.Append(Camera.main.DOOrthoSize(zoomedInSize, zoomTime).SetEase(Ease.InOutExpo).OnComplete(()=> {
            __zoomFrom.SetActive(false);            
            __zoomTo.SetActive(true);
            FindObjectOfType<PlayerCamera>().SetTransform();
        }));
        __switchZoomSequence.Append(Camera.main.DOOrthoSize(zoomedOutSize, zoomTime).SetEase(Ease.InOutExpo));

        __switchZoomSequence.Play();

    }

    public void StartWaterZoom()
    {
        //StartCoroutine(WaterZoom());

        Sequence __waterZoomSequence = DOTween.Sequence();

        __waterZoomSequence.Append(Camera.main.DOOrthoSize(waterZoomSize, zoomTime).SetEase(Ease.InOutExpo));
        __waterZoomSequence.Append(Camera.main.DOOrthoSize(waterZoomSize, zoomTime).SetEase(Ease.InOutExpo));
        __waterZoomSequence.Append(Camera.main.DOOrthoSize(zoomedOutSize, zoomTime).SetEase(Ease.InOutExpo));

        __waterZoomSequence.Play();
    }
}
