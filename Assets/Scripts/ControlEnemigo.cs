using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    public float velocidad;
    public Vector3 posicionFin;

    private Vector3 posicionInicio;
    private bool moviendoAFin;

    private SpriteRenderer sprite;


    public GameObject muerte;


    private void Awake()
    {
        posicionInicio = transform.position;
        moviendoAFin = true;

        sprite = GetComponentInChildren<SpriteRenderer>();

       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala"))
        {
            muerte.SetActive(true);
            Destroy(gameObject,0.2f);
            Destroy(collision.gameObject);
        }

        else
        {
            muerte.SetActive(false);
        }
    }

    void Update()
    {

    moverEnemigo();

    }
    private void moverEnemigo()
    {
        //Calcular la posicion de destino  la ? es
        Vector3 posicionDestino = (moviendoAFin) ? posicionFin : posicionInicio;

        //Mover al enemigo
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);

        //Cambio de direccion
        if (transform.position== posicionFin)
        {
            moviendoAFin = false;

            sprite.flipX = true;

        }
        //Cambio de direccion
        if (transform.position == posicionInicio)
        {
            moviendoAFin = true;

            sprite.flipX = false;

        }

    }
}
