using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaScript : MonoBehaviour
{
  
    
    public float velX;
    float velY = 0;

    Rigidbody2D rb;

   
    // Start is called before the first frame update
    void Start()
    {
        

        rb = GetComponent<Rigidbody2D>();
            
    }
    public void SentidoBalaIZquierda(bool sentido)
    {
        if (sentido)
        {
            velX = -Mathf.Abs(velX);

        }
        else
        {
            velX = Mathf.Abs(velX);
        }

    } 

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 2.5f);
    }
}
