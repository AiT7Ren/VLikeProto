using System;
using UnityEngine;
using UnityEngine.UIElements;

//SimpleMove
public class ProtoMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotate;
    [SerializeField] private Transform _playerObj;
    private InputSystem_Actions _inputSystem;
    //MoveStuff
    private Vector2 _inputVector;
    private Vector3 _moveDirection;
    //RotateStuff
    private Quaternion _targetRotate;
    private float _angleRotate;
    private void Awake()
    {
        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody>();
        }
        _inputSystem = new InputSystem_Actions();
        _inputSystem.Enable();
    }
    
    private void Update()
    {
        _inputVector = _inputSystem.Player.Move.ReadValue<Vector2>();
        if(_inputVector!=Vector2.zero)Rotating();
    }

    private void Rotating()
    {
        _targetRotate = Quaternion.Euler(0,AngleRotate(), 0);
        _playerObj.transform.localRotation=Quaternion.RotateTowards(_playerObj.transform.localRotation, _targetRotate, _speedRotate*Time.deltaTime);
    }
    
    private float AngleRotate()
    {
        return Mathf.Atan2(_inputVector.x,_inputVector.y) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        _moveDirection.Set(_inputVector.x,0,_inputVector.y);
        
        _rb.linearVelocity = _moveDirection * _speed;
        
    }
}
