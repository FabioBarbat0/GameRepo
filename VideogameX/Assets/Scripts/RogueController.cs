using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueController : MonoBehaviour
{
    public Animator anim;
    private bool righSideChecked = false;
    private float rightSideTarget;
    private float leftSideTarget;

    // Start is called before the first frame update
    void Start()
    {
        rightSideTarget = transform.position.x + 10;
        leftSideTarget = transform.position.x - 10;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        
        if(!righSideChecked) {

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(rightSideTarget, transform.position.y), 5 * Time.deltaTime);
        }else if(righSideChecked) {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(leftSideTarget, transform.position.y), 5 * Time.deltaTime);
        }

        if (transform.position.x == rightSideTarget) {
            righSideChecked = true;
        }
        else if (transform.position.x == leftSideTarget)
        {
            righSideChecked = false;
        }
        
        anim.SetFloat("Speed", 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") {

        }

    }

}
