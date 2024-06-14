using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Flecha;
    public float intervaloMinDisparo;
    public float intervaloMaxDisparo;
    public float potencia;
    public float angulo;
    public ForceMode2D modo;

    private void Start()
    {
        StartCoroutine(Disparar());
    }

    private IEnumerator Disparar()
    {
        while (true)
        {
            float intervaloDisparo = Random.Range(intervaloMinDisparo, intervaloMaxDisparo);
            yield return new WaitForSeconds(intervaloDisparo);

            // Creo un nuevo misil (un GameObject) basandome en el prefab que me pasaron
            GameObject flecha = Instantiate(Flecha);

            // Muevo el nuevo misil a la misma posicion donde esta este canion
            flecha.transform.position = transform.position;

            // Obtengo el rigidbody del misil (si no hay un rigidbody, tira excepcion)
            var rbMisil = flecha.GetComponent<Rigidbody2D>();

            // Lo lanzo
            AddForceAtAngle(potencia, angulo, rbMisil, modo);
        }
    }

    private void AddForceAtAngle(float potencia, float angulo, Rigidbody2D rb, ForceMode2D modo)
    {
        Vector3 direccion = Quaternion.AngleAxis(angulo, Vector3.forward) * Vector3.right;
        rb.AddForce(direccion * potencia, modo);
    }
}