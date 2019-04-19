using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookControl : MonoBehaviour
{


    public float speed;

    private Rigidbody2D component;

    public Transform hookGrab;

    public Transform hoookConnector;

    LineRenderer lr;

    private Vector3 lastPosition;

    public int ropeLength = 1;

    void Start()
    {
        component = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        lastPosition = hookGrab.transform.position;
        lr.SetPosition(0, hookGrab.transform.position);
    }

    void Update()
    {
        lr.SetPosition(1, hoookConnector.position);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        
        


        var CurrentMousePosition = Input.mousePosition;
        var currentMouseWorldPosition = Camera.main.ScreenToWorldPoint(CurrentMousePosition);
        currentMouseWorldPosition.z = 0;
        var newPosition = Vector3.Lerp(transform.position, currentMouseWorldPosition, Time.deltaTime * speed);
        //transform.position = newPosition;
        component.MovePosition(newPosition);
        


        //Vector2 direction = newPosition - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotateSpeed);

    }
}
