using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoraMouse : MonoBehaviour
{
    float velocity = 5f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb.velocity = new Vector2(0, 0);
        float iy = Input.GetAxis("Vertical");
        float ix = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);    
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);    
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, velocity);    
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, -velocity);    
        }

    }
    
    #region quicksand code
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<quicksand>())
        {
            Debug.Log("hitting");
            velocity = 1f;
            Debug.Log(velocity);
        }
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<quicksand>())
        {
            Debug.Log("hitting");
            velocity = 5f;
            Debug.Log(velocity);
        }
    }
    
    #endregion

}
