﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkey : MonoBehaviour
{
    float og_y; 
    Rigidbody2D rb;
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
        og_y = rb.position.y;
    }

    // Update is called once per frame
    void Update()
    {
    	rb = GetComponent<Rigidbody2D>();
        if (rb.position.y >= og_y + 2.5){
        	speed = -2;
        }
        if (rb.position.y <= og_y - 2.5){
        	speed = 2;
        }
        rb.velocity = Vector2.up * speed;
    }
}
