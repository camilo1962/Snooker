using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Jugar(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

}

   