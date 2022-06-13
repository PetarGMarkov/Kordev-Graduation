using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float VelX = 3f;
    public float VelY = 0f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (VelX, VelY);
        Destroy (gameObject, 1f);
    }
}
