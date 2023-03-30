using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueController : MonoBehaviour
{
    public Animator anim; //animation

    private bool righSideChecked = false; //check sides
    private float rightSideTarget;
    private float leftSideTarget;

    private bool alerted = false; //alert state

    public GameObject projectile; //projectile elements
    public Transform projectilePos;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        rightSideTarget = transform.position.x + 10;
        leftSideTarget = transform.position.x - 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (!alerted) {
            Move();
        }
        else {
            Shoot();
        }
    }

    void Move()
    {
        anim.SetBool("Alert", false);
        if (!righSideChecked) {

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
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") {
            alerted = true;
            if (collision.transform.position.x < transform.position.x) {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
            else if(collision.transform.position.x > transform.position.x) {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                Instantiate(projectile, projectile.transform.position, projectile.transform.rotation);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            alerted = false;
        }
    }

    private void Shoot() {
        anim.SetBool("Alert",true);

        timer += Time.deltaTime;
        if (timer > 1) {
            timer = 0;
            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        Instantiate(projectile, projectilePos.position, transform.rotation);
    }

}
