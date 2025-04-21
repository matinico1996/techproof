using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] GameObject bolitadefuego;

    bool mirandoDerecha = true;

    void Update() 
    {
        float movimiento = Input.GetAxisRaw("Horizontal");
        if (movimiento > 0)
            mirandoDerecha = true;
        else if (movimiento < 0)
            mirandoDerecha = false;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("¡Disparo activado!");

            Vector3 spawnPosition = transform.position; 

            GameObject nuevaBolita = Instantiate(bolitadefuego, spawnPosition, Quaternion.identity);

            nuevaBolita.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f); 

            Debug.Log("Bolita de fuego instanciada en: " + nuevaBolita.transform.position); 
        }
    }
}