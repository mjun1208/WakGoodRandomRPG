using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyActor : MonoBehaviour
{
    public void SetPosition(Vector3 position, float rotation)
    {
        this.transform.position = position;
        
        float rotationVelocity = 0f;
        rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref rotationVelocity, 0f);
        this.transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
    }
}
