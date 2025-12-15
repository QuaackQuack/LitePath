// https//www youtube com/watch?v=yyg0yV2roPk 
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 8f;
    [SerializeField] AudioSource ladderClimbSFX;

    private AudioSource ropesAudio;
    private bool wasClimbing;

    private float vertical;
    private bool isLadder;
    private bool isClimbing;

    void Awake()
    {
        Debug.Log(gameObject.name);
        Debug.Log(gameObject.tag);
    }

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, vertical * speed);

            if (ropesAudio == null)
            {
                ropesAudio = ladderClimbSFX;
                ropesAudio.loop = true;
                ropesAudio.Play();
            }
            else if (!ropesAudio.isPlaying)
            {
                ropesAudio.Play();
            }
        }
        else
        {
            rb.gravityScale = 4f;
            ropesAudio?.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}