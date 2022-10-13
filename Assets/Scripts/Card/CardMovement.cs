using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMovement : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;
    [System.NonSerialized] public Vector3 mousePosition;

    void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        offset = transform.position - mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 12));
    }

    private void OnMouseDrag()
    {
        if (gameObject.tag.Equals("LandmarkSlot")) return;
        mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 12));

        transform.position = mousePosition + offset;
    }

}
