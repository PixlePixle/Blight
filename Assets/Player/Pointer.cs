using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private Vector3 camOffset;
    Controls controls;
    Plane plane;
    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();
        getCameraTransform();
        plane = new Plane(Vector3.down, transform.position.y);
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void getCameraTransform()
    {
        camOffset = Camera.main.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        // Makes player always follow the mouse
        Vector3 mousePos = controls.Movement.Mouse.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        if(plane.Raycast(ray, out float distance))
        {
            mousePos = ray.GetPoint(distance);
        }
        transform.LookAt(new Vector3(mousePos.x, transform.position.y, mousePos.z));
    }

    
}
