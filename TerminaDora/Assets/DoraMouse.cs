using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoraMouse : MonoBehaviour
{
    float pspeed = 10f;
    float pspeed1 = 10f;
    float pspeed2 = 20f;
    float pspeed3 = 30f;
    float switcher = 0f;
    public GameObject bullet;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    float velocity = 5f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb.velocity = new Vector2(0, 0);
        float iy = Input.GetAxis("Vertical");
        float ix = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Fired");
            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody2D instBulletRB = instBullet.GetComponent<Rigidbody2D>();
            instBulletRB.AddForce(gameObject.transform.forward * pspeed);
            Physics2D.IgnoreCollision(instBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Destroy(instBullet, 5f);
        }
        if(Input.GetKeyDown(KeyCode.E)) //switch weapons
        {
            switch(switcher % 3)
            {
                Debug.Log("triggered switch weapon");
                case 0: 
                    bullet = bullet1;
                    pspeed = pspeed1;
                    switcher++;
                    break;
                case 1:
                    bullet = bullet2;
                    pspeed = pspeed2;
                    switcher++;
                    break;
                case 2:
                    bullet = bullet3;
                    pspeed = pspeed3;
                    switcher++;
                    break;
                default:
                //do nothing
                    Debug.Log("ERROR");
                    break;
            }
        }
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
