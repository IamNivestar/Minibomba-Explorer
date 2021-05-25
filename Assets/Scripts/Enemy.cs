using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour {

    public float speed;

    bool chao = false;

    Rigidbody2D rb;

    Transform GroundCheck;

    private Animator anim;

    public float jumpForce;

    bool facingRight = false;

    AudioSource audioS;

    public LayerMask whatIsGround;
    // Use this for initialization
    void Start() {
        
        rb = gameObject.GetComponent<Rigidbody2D>();
        GroundCheck = gameObject.transform.Find("EnemyGroundCheck");
        anim = gameObject.GetComponent<Animator>();
        audioS = gameObject.GetComponent<AudioSource>();
     
    }

    // Update is called once per frame
    void Update()
    {
        chao = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, whatIsGround);
        

        if (!chao)
        {
            speed *= -1;
        }
    }

    private void FixedUpdate()
    {
        if (config.pause)
            return;
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (speed > 0 && !facingRight)
        {
            Flip();
        }
        else if (speed < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }
            rb.AddForce(new Vector2(0, -50 * rb.velocity.y));
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            audioS.Play();
            speed = 0;
            anim.SetTrigger("die");
            transform.Rotate(new Vector3(0, 0, -180));
            Destroy(gameObject, 3);

        }
      
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speed = 0;
            anim.SetTrigger("die");
            other.gameObject.GetComponent<PlayerLife>().PerdeVida();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            speed *= -1;
        }
        
    }
}
