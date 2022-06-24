using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorPowerUp : MonoBehaviour
{
    public Text textoObjetos;
    private int objetosInicales;
    private int objetosRecogidos;

    void Start()
    {

        objetosInicales = transform.childCount;
        textoObjetos.text = "Objects left: 0/" + objetosInicales;

    }

    // Update is called once per frame
    void Update()
    {

        objetosRecogidos = transform.childCount;

        textoObjetos.text = "Objects left "+ objetosRecogidos + "/" + objetosInicales;

        if (objetosInicales != objetosRecogidos)
        {
            objetosRecogidos++;
        }
       
    }

}
