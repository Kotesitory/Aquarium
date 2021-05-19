using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed = 15f;
    private float gravity = 10.0f;
    private CharacterController controller;
    public Joystick joystick;

    private float startTime;
    private const float TIME_TO_END = 400; 
    public GameOverMenu gameOverMenu;

    public HealthBarScript healthBar;
    public int maxHealth = 100;
    public int currentHealth;

    public Score score;
    private int scorePoints = 0;

    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        this.controller = GetComponent<CharacterController>();
        GameOverMenu.gameOver = false;
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        startTime = Time.time;
        score.SetScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        float currentTime = Time.time;
        if (!GameOverMenu.gameOver && currentTime - startTime > TIME_TO_END) {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            AddScore(30);
        }
    }

    void PlayerMovement()
    {
        if(Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            MovePlayer();
        }
    }

    private void MovePlayer() {
        // Vector3 direction = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
        // Vector3 velocity = direction * this.speed;
        // velocity = Camera.main.transform.TransformDirection(velocity);
        // velocity.y -= gravity;
        // transform.position = velocity * Time.deltaTime;
        //transform.position = transform.position + (Camera.main.transform.forward * speed - gravity)* Time.deltaTime;

        Vector3 direction = Camera.main.transform.forward;
        Vector3 velocity = direction * this.speed;
        //velocity = Camera.main.transform.TransformDirection(velocity);
        transform.position += (velocity * Time.deltaTime);

        // float horizontal = this.joystick.Horizontal;
        // float vertical = this.joystick.Vertical;
        // Vector3 direction = new Vector3(horizontal, 0, vertical);
        // Vector3 velocity = direction * this.speed;
        // velocity = Camera.main.transform.TransformDirection(velocity);
        // velocity.y -= gravity;
        // transform.position += (velocity * Time.deltaTime);
    }

    public void TakeDamage(int demage) {
        currentHealth = Mathf.Clamp(currentHealth - demage, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0) {
            Die();
        }
    }

    public void Die() {
        transform.position = Vector3.zero;
        audioManager.Play("game_over");
        gameOverMenu.GameOver();
    }

    public void AddScore(int points) {
        scorePoints += points;
        score.SetScore(scorePoints);
    }

    public void Heal(int healAmmount) {
        currentHealth = Mathf.Clamp(currentHealth + healAmmount, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }
}