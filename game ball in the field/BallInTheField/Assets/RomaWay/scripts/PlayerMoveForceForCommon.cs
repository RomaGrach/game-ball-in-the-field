using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveForceForCommon : MonoBehaviour
{
    public ControlType controlType;
    public enum ControlType { PC, Android }
    public float _speed = 100.0f;
    private Rigidbody _rb;
    public Joystick _joystick;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float v = 0;
        float h = 0;
        if (controlType == ControlType.PC)
        {
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");
        }
        else if (controlType == ControlType.Android)
        {
            v = _joystick.Vertical;
            h = _joystick.Horizontal;
        }
        _rb.AddForce(new Vector3(h, 0, v).normalized * _speed * Time.fixedDeltaTime);
    }

    public void ChangeControlTypePhone(bool a)
    {
        if (a)
        {
            controlType = ControlType.Android;
        }
        else
        {
            controlType = ControlType.PC;
        }
    }
}
