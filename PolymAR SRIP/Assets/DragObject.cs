using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Rigidbody rb;
    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 offset;
    private float zCoord;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        zCoord = mainCamera.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            rb.MovePosition(GetMouseWorldPos() + offset);
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}
