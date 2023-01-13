using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragDrop : MonoBehaviour
{
    public string nom;
    [Header("----------------------------------DEV----------------------------------------")]
    public LayerMask layerGround; 
    public LayerMask layerJar; 
    Vector3 offset;
    Plane plane = new Plane(Vector3.up, 0);
    public bool takeObject;
    private bool Grounded;
    public bool Done;
    public float ScrollSensitivity = 20f;
    private void OnMouseDown()
    {
        if(!takeObject)
            GameManager.instance.SwitchObject(this);
        if (Input.GetMouseButton(0))
        {
            takeObject = !takeObject;
            Done = false;
        }
        if (takeObject)
            offset = transform.position - MouseWorldPosition();
    }
    private void OnMouseDrag()
    {
        if (takeObject)
            transform.position = MouseWorldPosition() + offset;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
    private void Update()
    {
        if (takeObject && !Done)
        {
            var mouseScreenPos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mouseScreenPos);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit, float.MaxValue, layerGround))
            {
                Debug.DrawRay(Hit.point, transform.TransformDirection(Vector3.up), Color.red, 10f);
                transform.position = Hit.point;
                Grounded = true;
            }
            else
                Grounded = false;
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                transform.Rotate(Vector3.up * ScrollSensitivity * Input.GetAxis("Mouse ScrollWheel"));
            }
            
        }
        if(Grounded && !Done)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
            }
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            Done = true;
        }
    }
}
