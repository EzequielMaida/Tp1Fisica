using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;
    public float shootInterval = 2f; // Intervalo entre disparos
    public float arrowForce = 20f;
    public Vector2[] shootDirections;

    private int currentShot = 0;

    void Start()
    {
        InvokeRepeating("Disparo", 1f, shootInterval);
    }

    void Disparo()
    {
        if (currentShot >= shootDirections.Length)
            return;

        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(shootDirections[currentShot] * arrowForce, ForceMode2D.Impulse);
        currentShot++;
    }
}