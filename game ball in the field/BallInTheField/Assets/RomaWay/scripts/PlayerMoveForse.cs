using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class PlayerMoveForse : MonoBehaviour
{
    public ControlType controlType;
    public enum ControlType { PC, Android }
    public float _speed = 100.0f;
    private Rigidbody _rb;
    bool game_mode_acceleration = false;
    public Joystick _joystick;
    private UnityEngine.Vector3 move; 
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (game_mode_acceleration)
        {
           
            UnityEngine.Vector3 acceleration = new UnityEngine.Vector3(Input.acceleration.x, 0, Input.acceleration.y);
            _rb.AddForce(acceleration * _speed);
        }
        else
        {
            if (controlType == ControlType.PC)
            {
                move = new UnityEngine.Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            }
            else if (controlType == ControlType.Android)
            {
                move = new UnityEngine.Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized;
            }
            _rb.AddForce(move * _speed * Time.fixedDeltaTime);
        }
    }

    public void change_game_mode_acceleration(bool a)
    {
        game_mode_acceleration = a;
    }
    public void change_ControlType()
    {
        if (controlType == ControlType.PC)
        {
            controlType = ControlType.Android;
        }
        else if (controlType == ControlType.Android)
        {
            controlType = ControlType.PC;
        }
    }

}
