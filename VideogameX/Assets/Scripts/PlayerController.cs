using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator anim;
    private float horizontalInput;
    public Rigidbody2D rb;
    public float jumpAmount = 50;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            anim.SetBool("Grounded", false);
        }



        float speed = (Input.GetAxisRaw("Horizontal") != 0) ? 3: 0;
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);        
        anim.SetFloat("Speed", speed);

        if (Input.GetKeyDown(KeyCode.S)) {
            if (anim.GetBool("Grounded")) {
                anim.SetBool("Grounded", false);
            }
            else {
                anim.SetBool("Grounded", true);
            }
        }
    }
}
