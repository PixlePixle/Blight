using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private Vector3 camOffset;
    Controls controls;
    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();
        getCameraTransform();
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
        //Some unworking mouse code
        Vector3 mousePos = controls.Movement.Mouse.ReadValue<Vector2>();
        mousePos.z = Mathf.Sqrt(Mathf.Pow(camOffset.y, 2) + Mathf.Pow(camOffset.z , 2));
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.LookAt(new Vector3(mousePos.x, transform.position.y, mousePos.z));
        Debug.Log(transform.position);
    }
}
