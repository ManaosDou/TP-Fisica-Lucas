using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoS2 : MonoBehaviour
{
    public GameObject prefabDisparo;
    public float potencia;
    public float angulo;
    public ForceMode2D modo;

    void Start()
    {
        StartCoroutine(TiempoEntreDisparo());
    }

    private IEnumerator TiempoEntreDisparo()
    {
        Disparar(12, 50, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1); 
        Disparar(7, 30, ForceMode2D.Impulse);
    }

    private void Disparar (float potencia, float angulo, ForceMode2D modo)
    {
        GameObject disparo = Instantiate(prefabDisparo, transform.position, Quaternion.identity);
        var rb = disparo.GetComponent<Rigidbody2D>();

        Vector3 direccion = Quaternion.AngleAxis(angulo, Vector3.forward) * Vector3.right;
        rb.AddForce(direccion * potencia, modo);
    }
}
