using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private float horizontalInput;
    private Rigidbody2D rb;
    private float jumpAmount = 15;
    public bool grounded = false;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        coll.offset = new UnityEngine.Vector2(-2, 4.8f);
        coll.size = new UnityEngine.Vector2(2.02475f, 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
    }

    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            anim.SetTrigger("Jump");
            rb.AddForce(UnityEngine.Vector2.up * jumpAmount, ForceMode2D.Impulse);
            anim.SetBool("Grounded", false);
        }
        else {
            anim.SetBool("Grounded", true);
        }
    }


    void Move() {
        horizontalInput = Input.GetAxis("Horizontal");
        float speed = (Input.GetAxisRaw("Horizontal") != 0) ? 8 : 0;
        if (horizontalInput > 0)
        {
            transform.rotation = UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0, 0, 0));
            transform.Translate(UnityEngine.Vector3.right * Time.deltaTime * horizontalInput * speed);
        }
        else if(horizontalInput < 0)
        {
            transform.rotation = UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0, 180, 0));
            transform.Translate(UnityEngine.Vector3.left * Time.deltaTime * horizontalInput * speed);

        }
        anim.SetFloat("Speed", speed);
    }


    private bool IsGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, UnityEngine.Vector2.down, .1f, jumpableGround);    
    }

}