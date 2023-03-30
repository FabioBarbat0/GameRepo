using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    private float startYPosition;
    private float endYPosition;
    private bool floated = false;

    // Start is called before the first frame update
    void Start()
    {
        startYPosition = transform.position.y;
        endYPosition = transform.position.y + 1;
    }

    // Update is called once per frame
    void Update()
    {
        floatingObject();
    }

    private void floatingObject() {
        if (!floated) {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, endYPosition), 2 * Time.deltaTime);
        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, startYPosition), 2 * Time.deltaTime);
        }

        if (transform.position.y == endYPosition)
        {
            floated = true;
        }
        else if (transform.position.y == startYPosition)
        {
            floated = false;
        }
    }


}
