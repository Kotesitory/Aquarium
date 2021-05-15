using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed = 10.5f;
    private float gravity = 10.0f;
    private CharacterController controller;
    public Joystick joystick;

    private float startTime;
    private const float TIME_TO_END = 15; 
    public GameOverMenu gameOverMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        this.controller = GetComponent<CharacterController>();
        GameOverMenu.gameOver = false;
        Time.timeScale = 1f;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Debug.Log(GameOverMenu.gameOver);
        float currentTime = Time.time;
        if (!GameOverMenu.gameOver && currentTime - startTime > TIME_TO_END) {
            gameOverMenu.GameOver();
        }
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