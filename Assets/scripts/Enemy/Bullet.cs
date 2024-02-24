using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Palyer"))
        {
            Debug.Log("Hit Player");
            hitTransform.GetComponent<PlayerHealth>().TakeDamege(10);
        }
        Destroy(gameObject);
    }
}
