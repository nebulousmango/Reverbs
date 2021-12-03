using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool isPickable;
    public bool picked;
    public KeyCode interactionKey;
    public GameObject highlight;

    [SerializeField]
    private Transform pickedObjectAnchor;


    private void Update()
    {
        if (picked == true && Input.GetKeyUp(interactionKey))
        {
            StopAllCoroutines();
            StartCoroutine(Drop());
        }

        if (isPickable == true && Input.GetKeyUp(interactionKey))
        {
            StopAllCoroutines();
            StartCoroutine(PickUp());
        } 
    }

    IEnumerator PickUp()
    {
        yield return new WaitForEndOfFrame();

        if (GetComponent<Rigidbody2D>())
        {
            GetComponent<Rigidbody2D>().simulated = false;
        }

        transform.parent = pickedObjectAnchor;
        transform.localPosition = Vector3.zero;
        picked = true;
        isPickable = false;
        highlight.SetActive(false);
    }


    IEnumerator Drop()
    {
        yield return new WaitForEndOfFrame();

        if (GetComponent<Rigidbody2D>())
        {
            GetComponent<Rigidbody2D>().simulated = true;
        }

        transform.parent = null;
        picked = false;
        isPickable = true;
        highlight.SetActive(true);
    }

    public void TogglePickable(bool __value)
    {
        isPickable = __value;
        highlight.SetActive(__value);
    }

    public void SetPickedObjectAnchor(Transform __value)
    {
        pickedObjectAnchor = __value;
    }

}
