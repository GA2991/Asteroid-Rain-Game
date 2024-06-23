using UnityEngine;
using System.Collections;


public class DetectCollisions : MonoBehaviour
{
    private Counter counterScript;
    private GManager gameManagerScript;
    public GameObject explosionEffect;
     // Asigna esto en el inspector con tu prefab de sistema de partículas

    void Start()
    {
        // Encuentra el script Counter una sola vez y guárdalo en la variable counterScript
        counterScript = FindObjectOfType<Counter>();
        gameManagerScript = FindObjectOfType<GManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Primero incrementa el contador antes de destruir los objetos
        int pointsToAdd = 0;
        if (other.gameObject.CompareTag("Player"))
        {
            // Inicia la coroutine para retrasar la secuencia de Game Over
            StartCoroutine(GameOverAfterDelay(2f));
        }
        else if (gameObject.CompareTag("Asteroid1"))
        {
            pointsToAdd = 3;
        }
        else if (gameObject.CompareTag("Asteroid2"))
        {
            pointsToAdd = 2;
        }
        else if (gameObject.CompareTag("Asteroid3"))
        {
            pointsToAdd = 1; 
        }

        // Usa la referencia almacenada para incrementar el contador
        if (counterScript != null)
        {
            counterScript.IncrementCount(pointsToAdd);
        }
        else
        {
            Debug.LogWarning("Counter script not found!");
        }

        // Crea la explosión de partículas en la posición del asteroide
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // Destruye el otro objeto primero
        Destroy(other.gameObject);
        
         // Luego destruye este objeto, pero después del retraso si es el jugador
         if (!other.gameObject.CompareTag("Player"))
         {
             Destroy(gameObject);
         }
    }

    IEnumerator GameOverAfterDelay(float delay)
    {
        // Espera el tiempo de retraso especificado
        yield return new WaitForSeconds(delay);

        gameManagerScript.GameOverSequence();

        // Ahora puedes destruir el objeto del jugador si es necesario
        Destroy(gameObject);
    }
}
