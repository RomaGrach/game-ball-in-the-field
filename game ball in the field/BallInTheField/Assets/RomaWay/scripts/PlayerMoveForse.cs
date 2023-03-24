using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class PlayerMoveForse : MonoBehaviour
{
    public float _speed = 100.0f;
    private Rigidbody _rb;
    bool game_mode_acceleration = false;
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
            float v = Input.GetAxis("Vertical") * _speed * Time.fixedDeltaTime;
            float h = Input.GetAxis("Horizontal") * _speed * Time.fixedDeltaTime;
            _rb.AddForce(new UnityEngine.Vector3(h, 0, v));
        }
    }

    public void change_game_mode_acceleration(bool a)
    {
        game_mode_acceleration = a;
    }
}
