using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueController : MonoBehaviour
{
    public Animator anim;
    public bool righSideChecked = false;

    // Start is called before the first frame update
    void Start()
    {

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
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(10, transform.position.y), 2 * Time.deltaTime);
        }else if(righSideChecked) {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-10, transform.position.y), 2 * Time.deltaTime);
        }

        if (transform.position.x == 10) {
            righSideChecked = true;
        }
        else if (transform.position.x == -10){
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
