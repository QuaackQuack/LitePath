// https://www.youtube.com/watch?v=ErajgMCsTH8 

using UnityEngine;

public class FallingSpikes : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;
    public float distance;
    bool isFalling = false;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

    }

    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (isFalling == false) 
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,distance);

            Debug.DrawRay(transform.position,Vector2.down * distance,Color.red);

            if (hit.collider != null) 
            {
                if (hit.transform.tag == "Player") 
                {
                    audioManager.PlaySFX(audioManager.Spike);
                    rb.gravityScale = 5;
                    isFalling = true;
                }
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
           Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ground")
        {
           Destroy(gameObject);
        }
    } 
}
