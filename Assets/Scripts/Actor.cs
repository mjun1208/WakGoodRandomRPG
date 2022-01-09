using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DG.Tweening;
using UnityEngine;

namespace WRR
{
    public class Actor : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public Vector3 CameraRotationEuler { get; private set; } = Vector3.zero;
        
        private bool _isMoveInput = false;
        private bool _isRunInput = false;
        private Vector3 _inputDir;
        private Vector3 _dir;
        
        void Update()
        {            
            CameraRotation();
            KeyInput();
            Move();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        private void KeyInput()
        {
            _inputDir = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                _inputDir += Vector3.forward;
            }

            if (Input.GetKey(KeyCode.S))
            {
                _inputDir += Vector3.back;
            }

            if (Input.GetKey(KeyCode.A))
            {
                _inputDir += Vector3.left;
            }

            if (Input.GetKey(KeyCode.D))
            {
                _inputDir += Vector3.right;
            }
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _isRunInput = true;
            }
            else
            {
                _isRunInput = false;
            }
        }
        
        private void CameraRotation()
        {
            float mouse_x = Input.GetAxis("Mouse X");
            float mouse_y = Input.GetAxis("Mouse Y");

            CameraRotationEuler += new Vector3(-mouse_y * 0.2f, mouse_x, 0);

            CameraRotationEuler = CameraRotationClamp(CameraRotationEuler);
        }

        private Vector3 CameraRotationClamp(Vector3 rotation)
        {
            rotation.x = Mathf.Clamp(CameraRotationEuler.x, -80f, 60f);
            
            return rotation;
        }

        private void Move()
        {
            _animator.SetBool("isMove", _inputDir != Vector3.zero);
            _animator.SetFloat("MoveSpeed", _isRunInput ? 1f : 0f);
            
            if (_inputDir == Vector3.zero)
            {
                return;
            }

            _dir = _inputDir;

            float angle = Mathf.Atan2(_dir.x, _dir.z) * Mathf.Rad2Deg;
            angle += CameraRotationEuler.y;

            _dir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

            this.transform.Translate(Vector3.forward * Time.deltaTime * (_isRunInput ? 10f : 5f));
            this.transform.DOLookAt(this.transform.position + _dir, 0.1f);
        }
    }
}