using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _gravityScale = 9.8f;

    private float _currentAttraction = 0;
    private CharacterController _characterController;


    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move(JoystickHandler.Direction);
    }

    private void Move(Vector2 direction)
    {
        GravityHandling();
        var moveDirection = new Vector3(direction.x,_currentAttraction,direction.y) * _speed;
        _characterController.Move(moveDirection*Time.deltaTime);
        if (direction != Vector2.zero)
        {
            Rotate(moveDirection);
        }
    }

    private void Rotate(Vector3 direction)
    {
        if(Vector3.Angle(direction,Vector3.forward)>0)
        {
            var newDirection = Vector3.RotateTowards(transform.forward, direction, _rotationSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    private void GravityHandling()
    {
        if(!_characterController.isGrounded)
        {
            _currentAttraction -= _gravityScale * Time.deltaTime;
        }
        else
        {
            _currentAttraction = 0;
        }
    }
}
