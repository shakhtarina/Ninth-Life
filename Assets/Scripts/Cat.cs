using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    //[SerializeField]
    //private int lives = 9;

    //public int Lives
    //{
        //get { return lives; }
        //set
       // {
            //if (value < 9) lives = value;
            //livesBar.Refresh();
        //}
    //}
//private LivesBar livesBar;

    [SerializeField]
    private float spead = 3.0f;

    [SerializeField]
    private float jump = 15.0f;

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private bool isGrounded = false;

    private void Awake()
    {
        //livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        checkGround();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButton("Jump")) Jump();
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, spead * Time.deltaTime);

        sprite.flipX = direction.x < 0.0f;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jump,ForceMode2D.Impulse);


    }

    private void checkGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,0.3F);
        isGrounded = colliders.Length > 1;
    }
}