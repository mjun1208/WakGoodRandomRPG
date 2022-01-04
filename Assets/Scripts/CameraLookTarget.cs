using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using UnityEngine;

public class CameraLookTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    private void Update()
    {
        this.transform.position = _target.transform.position + new Vector3(0f, 1.5f, 0f);
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouse_x = Input.GetAxis("Mouse X");
        float mouse_y = Input.GetAxis("Mouse Y");
        
        this.transform.rotation *= Quaternion.AngleAxis(mouse_x, Vector3.up);
        this.transform.rotation *= Quaternion.AngleAxis(-mouse_y * 0.2f, Vector3.right);
    }
}
