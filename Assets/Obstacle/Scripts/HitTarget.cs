using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTarget : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Hitable hitable;
        if (collision.gameObject.TryGetComponent<Hitable>(out hitable))
        {
            hitable.Hit();
        }
    }
}
