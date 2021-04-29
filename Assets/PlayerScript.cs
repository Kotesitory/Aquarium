using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10.5f;
    private float gravity = 10.0f;
    private CharacterController controller;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        this.controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if(Input.touchCount > 0)
        {
            // Vector3 direction = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            // Vector3 velocity = direction * this.speed;
            // velocity = Camera.main.transform.TransformDirection(velocity);
            // velocity.y -= gravity;
            // transform.position = velocity * Time.deltaTime;
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }
        // float horizontal = this.joystick.Horizontal;
        // float vertical = this.joystick.Vertical;
        // Vector3 direction = new Vector3(horizontal, 0, vertical);
        // Vector3 velocity = direction * this.speed;
        // velocity = Camera.main.transform.TransformDirection(velocity);
        // velocity.y -= gravity;
        // transform.position += (velocity * Time.deltaTime);
    }
}