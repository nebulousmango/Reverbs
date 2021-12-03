using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObjectPickerListener : MonoBehaviour
{
    private PickableObject _pickableObject;
    private ObjectPicker _objectPicker;

    private void Awake()
    {
        _pickableObject = transform.parent.GetComponent<PickableObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ObjectPicker>() != null)
        {
            _objectPicker = collision.GetComponent<ObjectPicker>();
            _pickableObject.TogglePickable(true);
            _pickableObject.SetPickedObjectAnchor(_objectPicker.pickedObjectAnchor);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ObjectPicker>() != null)
        {
            _pickableObject.TogglePickable(false);
            _pickableObject.SetPickedObjectAnchor(null);
        }
    }
}
