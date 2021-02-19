using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	float xOffset = 0.0f;
        for (int i = 0; i < hearts.Length; i++){
        	Vector3 temp = hearts[i].transform.position;
        	temp.y = transform.position.y + 4.31f; 
        	temp.x = transform.position.x + 5.5f + xOffset; 
        	hearts[i].transform.position = temp;
        	xOffset = xOffset + 0.7f;
        }
    }
}
