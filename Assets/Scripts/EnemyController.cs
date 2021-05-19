using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public float attackRadius = 1f;
    public float speed = 10f;
    PlayerScript player;


    public float timeBetweenAttacks = 1f;
    bool alreadyAttacked = false;
    public int attackDemage = 5;

    public AudioManager audioManager;
    public string attackSound;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance <= lookRadius) {
            if (distance > attackRadius){
                MoveTowardsPlayer();
                transform.LookAt(player.transform);
            } else {
                Attack();
            }
                
        }
    }

    private void MoveTowardsPlayer() {
        Vector3 playerDirection = player.transform.position - transform.position;
        transform.position += playerDirection * speed * Time.deltaTime;
    }

    private void Attack() {
        if(!alreadyAttacked) {
            alreadyAttacked = true;
            player.TakeDamage(attackDemage);
            audioManager.Play(attackSound);
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack() {
        alreadyAttacked = false;
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
