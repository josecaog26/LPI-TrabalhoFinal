using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlJugador : MonoBehaviour
{
    public int velocidad;
    public int fuerzaSalto;

    private Rigidbody2D fisica;

    private SpriteRenderer sprite;

    private Animator animacion;
    public Animator anim;

    public GameObject ObjectToCollect;


    public GameObject[] vida;
    public int cantidadVidas;

    

    [Header("Disparo")]

    public GameObject balaPrefab;
    public GameObject balaPrefabIzquierdo;
    public GameObject spawnBala;
    

    public float fireRate = 0.5f;
    float nextFire = 0.0f;

    private void Awake()
    {
        fisica = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animacion = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {

        cantidadVidas = vida.Length;

    }
    private void FixedUpdate()
    {

        float coordenadaX = Input.GetAxis("Horizontal");
        fisica.velocity = new Vector2(coordenadaX * velocidad * Time.deltaTime, fisica.velocity.y);

    }

    private bool TocandoSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0, -2.0f, 0), Vector2.down, 0.05f);
        return toca.collider != null;
    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) && TocandoSuelo())
        {
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);

        }

        if (fisica.velocity.x > 0)
        {

            sprite.flipX = false;

           spawnBala.transform.position = new Vector2(transform.position.x +1, transform.position.y);
           
        }
        else if (fisica.velocity.x < 0)
        {

            sprite.flipX = true;
            spawnBala.transform.position = new Vector2(transform.position.x -1, transform.position.y);
           
        }
        balaPrefab.GetComponent<BalaScript>().SentidoBalaIZquierda(sprite.flipX);

        AnimarJugador();

    }

    private void Disparar()
    {
        if (fisica.velocity.x < 0)
        {
            Instantiate(balaPrefab, spawnBala.transform.position, spawnBala.transform.rotation);
        }
        if (fisica.velocity.x > 0)
            Instantiate(balaPrefab, spawnBala.transform.position, spawnBala.transform.rotation );
       
        if (sprite.flipX)
        {
            Instantiate(balaPrefab, spawnBala.transform.position, spawnBala.transform.rotation);
        }
        else
        {
            Instantiate(balaPrefab, spawnBala.transform.position, spawnBala.transform.rotation);
        }

    }

    private void AnimarJugador()
    {
        animacion.SetBool("Salto", !TocandoSuelo());

        if (Mathf.Abs(fisica.velocity.x) > 0.001f)
        {
            animacion.SetBool("Corriendo", true);
               
        }
        else
        {
            animacion.SetBool("Corriendo", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire && TocandoSuelo() && fisica.velocity.x==0)
        {
            animacion.SetBool("DisparoQuieto", true);
        }
        else
        {
            animacion.SetBool("DisparoQuieto", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire && TocandoSuelo())
        {
            nextFire = Time.time + fireRate;
            animacion.SetBool("Disparo", true);
            Disparar();

        }
        else
        {
            animacion.SetBool("Disparo", false);
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            cantidadVidas--;
            animacion.Play("Daño");
            
            if (cantidadVidas == 0)
            {
                SceneManager.LoadScene("YouLost");
            }
            else if (cantidadVidas < 2)
            {

                vida[1].SetActive(false);

            }
            else if (cantidadVidas<3)
            {

                vida[2].SetActive(false);
            }
        }

        if (collision.gameObject.CompareTag("Caida"))
        {
            SceneManager.LoadScene("YouLost");
            Debug.Log("si");
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            SceneManager.LoadScene("YouLost");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Final") && ObjectToCollect.transform.childCount == 0)     
        {   

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        if (collision.gameObject.CompareTag("FinalFinal") && ObjectToCollect.transform.childCount == 0)
        {
            SceneManager.LoadScene("Fin");
        }

        if (collision.gameObject.CompareTag("Vida"))
        {

            if (cantidadVidas == 1)
            {
                cantidadVidas++;
                vida[1].SetActive(true);
                Destroy(collision.gameObject);

            }
            else if (cantidadVidas == 2)
            {
                cantidadVidas++;
                Destroy(collision.gameObject);
                vida[2].SetActive(true);
            }

        }
    }
}
