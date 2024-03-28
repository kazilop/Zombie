using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Joystick joy;
    public float joyspeed;
    private Rigidbody rb;
    public float playerSpeed = 2.0f;
    private Vector3 move;
    public float speed = 10f;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void JoystickFun()
    {
        joyspeed = joy.speed;
        if (joy.speed > 0.0f)
        {
            Vector2 direction = joy.direction;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            move.z = direction.y;
            move.x = direction.x;

            rb.AddForce(move * speed * playerSpeed);


        }
    }
}
