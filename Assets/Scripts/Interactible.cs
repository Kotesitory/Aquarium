using UnityEngine;

public class Interactible : MonoBehaviour
{
    public float radius = 3f;
    PlayerScript player;
    private bool hasInteracted = false;
    public AudioManager audioManager;
    public string sound;

    public virtual void Interact(PlayerScript player){
        audioManager.Play(sound);
    }

    void Start()
    {
        player = PlayerManager.instance.player;
        hasInteracted = false;
    }

    protected virtual void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance <= radius && !hasInteracted) {
            Interact(player);
            hasInteracted = true;    
        }
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
