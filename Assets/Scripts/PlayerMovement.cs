using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float mouse_pos_offset = 90f;

    Vector2 movement;
    Vector2 mousePos;

    Rigidbody2D RB2D;
    Camera cam;
    public Joystick joystick_1;
    public Joystick joystick_2;

    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        movement.x = joystick_1.Horizontal;
        movement.y = joystick_1.Vertical;

        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x = joystick_2.Horizontal;
        mousePos.y = joystick_2.Vertical;
    }

    void FixedUpdate()
    {
        RB2D.MovePosition(RB2D.position + movement * moveSpeed * Time.fixedDeltaTime);
        
        Vector2 lookDir = mousePos - RB2D.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - mouse_pos_offset;

        RB2D.rotation = angle;
    }
}
