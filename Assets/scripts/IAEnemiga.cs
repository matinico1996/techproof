using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemiga : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform personaje;
    [SerializeField] private float waitTime;
    [SerializeField] private Transform [] waypoints;
    private Rigidbody2D fisica;
    private bool jugadorEnRango = false;
    [SerializeField] private bool isWaiting;
    private int currentWaypoint;

    void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (jugadorEnRango)
        {
            transform.position = (Vector2.MoveTowards(transform.position,personaje.position,speed * Time.deltaTime));
        }


        if (currentWaypoint >= 0 && currentWaypoint < waypoints.Length)
        {
            if (transform.position != waypoints[currentWaypoint].position)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

                if (!isWaiting)
                {
                    Debug.Log("Corrutina iniciada");
                    StartCoroutine(Wait());
                }
            }
        }





    }

    IEnumerator Wait()
    {
        
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWaypoint++;

        if(currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;

        }
        isWaiting = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador detectado.");
            jugadorEnRango = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador salió del campo de visión.");
            jugadorEnRango = false;
        }
  
    }




}
