using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
	
    float og_x; 
    Rigidbody2D rb;
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
        og_x = rb.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(og_x);
        if (rb.position.x >= og_x + 2.5){
        	speed = -2;
        }
        if (rb.position.x <= og_x - 2.5){
        	speed = 2;
        }
        rb.velocity = Vector2.right * speed;
    }
}
