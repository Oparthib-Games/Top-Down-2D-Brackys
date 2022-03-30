using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitFX_GO = Instantiate(hitFX, transform.position, Quaternion.identity);

        Destroy(hitFX_GO.gameObject, 3f);
        Destroy(gameObject);
    }
}
