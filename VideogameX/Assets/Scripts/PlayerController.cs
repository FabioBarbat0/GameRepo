using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private float horizontalInput;
    private Rigidbody2D rb;
    private float jumpAmount = 50;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
        StopJump();

    }

    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            anim.SetBool("Grounded", false);
        }
    }


    void Move() {
        horizontalInput = Input.GetAxis("Horizontal");
        float speed = (Input.GetAxisRaw("Horizontal") != 0) ? 3 : 0;
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        anim.SetFloat("Speed", speed);
    }


    void StopJump() {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (anim.GetBool("Grounded"))
            {
                anim.SetBool("Grounded", false);
            }
            else
            {
                anim.SetBool("Grounded", true);
            }
        }
    }
}
