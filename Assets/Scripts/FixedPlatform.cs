using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPlatform : MonoBehaviour
{
    public GameObject padre;
    public GameObject jugador;

    // Start is called before the first frame update
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plataform"))
        {

            transform.SetParent(padre.transform);
        }
        
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Plataform"))
        {
            jugador.transform.position = transform.position;
            transform.SetParent(jugador.transform); 
            
        }
       
    }

}
