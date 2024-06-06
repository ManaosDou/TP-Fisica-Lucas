using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoS1 : MonoBehaviour
{
    public GameObject prefabDisparo;
    public float potencia;
    public float angulo;
    public ForceMode2D modo;

    void Start()
    {
        Disparar(8, 25, ForceMode2D.Impulse);  
        Disparar(11, 45, ForceMode2D.Impulse);  
        Disparar(13, 45, ForceMode2D.Impulse);  
    }

    private void Disparar (float potencia, float angulo, ForceMode2D modo)
    {
        GameObject disparo = Instantiate(prefabDisparo, transform.position, Quaternion.identity);
        var rb = disparo.GetComponent<Rigidbody2D>();

        Vector3 direccion = Quaternion.AngleAxis(angulo, Vector3.forward) * Vector3.right;
        rb.AddForce(direccion * potencia, modo);
    }
}
