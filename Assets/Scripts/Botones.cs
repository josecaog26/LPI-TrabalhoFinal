using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnBoton_VolverInicio()
    {
        SceneManager.LoadScene("Intro");

    }
     public void OnButton_Salir()
    {
    Application.Quit();
    }
}
