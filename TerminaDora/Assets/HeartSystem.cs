using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public List<GameObject> hearts = new List<GameObject>();
    int life; 

    // Start is called before the first frame update
    void Start()
    {
        life = hearts.Count; 
    }

    // Update is called once per frame
    void Update()
    {
    	float xOffset = 0.0f;
        for (int i = 0; i < hearts.Count; i++){
        	Vector3 temp = hearts[i].transform.position;
        	temp.y = transform.position.y + 4.31f; 
        	temp.x = transform.position.x + 5.5f + xOffset; 
        	hearts[i].transform.position = temp;
        	xOffset = xOffset + 0.7f;
        }
    }

    void OnCollisionEnter2D(Collision2D c){
        if (c.gameObject.tag.Equals("enemy")){
            Destroy(c.gameObject);
            EnemyDamage();
        }
    }

    void EnemyDamage(){
        if (life > 0){
            GameObject h = hearts[life-1].gameObject; 
            hearts.RemoveAt(life-1);
            Destroy(h);
            life = life - 1; 
            //Destroy(hearts[life-1].gameObject);
        }
    }
}
