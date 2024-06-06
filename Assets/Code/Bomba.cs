using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public GameObject prefabExplosion;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Explotar();
        Destroy(gameObject);
    }

    private void Explotar()
    {
        GameObject explosion = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        Destroy(explosion, 0.30f);

        // Aplicar fuerza explosiva a objetos cercanos
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5f);
        foreach (Collider2D col in colliders)
        {
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direccion = rb.transform.position - transform.position;
                rb.AddForce(direccion.normalized * 100f, ForceMode2D.Impulse);
            }
        }
    }
}
