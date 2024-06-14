using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 0.5f; // Velocidad de movimiento de las nubes

    void Update()
    {
        // Mueve las nubes de derecha a izquierda
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Opcional: Repetir las nubes para un flujo constante
        if (transform.position.x < -10) // Suponiendo que -10 es fuera de la pantalla
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z); // Reposiciona la nube al otro lado
        }
    }
}
