using System.Collections;
using System.Collections.Generic;
using System.Timers;
using DG.Tweening;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] private GameObject _lookTarget;
    
    private bool _isMoveInput = false;
    private Vector3 _inputDir;
    private Vector3 _dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();
        Move();
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
    }

    private void Move()
    {
        if (_inputDir == Vector3.zero)
        {
            return;
        }

        _dir = _inputDir;
        
        float angle = Mathf.Atan2(_dir.x, _dir.z) * Mathf.Rad2Deg;
        angle += _lookTarget.transform.eulerAngles.y;

        _dir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;

        this.transform.Translate(Vector3.forward * Time.deltaTime);
        this.transform.DOLookAt(this.transform.position + _dir, 0.1f);
    }
}
