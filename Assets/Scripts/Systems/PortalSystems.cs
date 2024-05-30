using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSystems : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool isMini;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    public void ChangeGravity()
    {
        rb.gravityScale -= rb.gravityScale * 2;
    }

    public void ChangeScaleMini()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void ChangeScaleBig()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
