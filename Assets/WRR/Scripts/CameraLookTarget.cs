using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using UnityEngine;

namespace WRR
{
    public class CameraLookTarget : MonoBehaviour
    {
        [SerializeField] private Actor _targetActor;
        
        private void Update()
        {
            this.transform.rotation = Quaternion.Euler(_targetActor.CameraRotationEuler);
            this.transform.position = _targetActor.transform.position + new Vector3(0f, 1.5f, 0f);
        }
    }
}