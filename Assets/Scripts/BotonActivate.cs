using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonActivate : MonoBehaviour
{
    private Collider2D col;
    private PortalSystems portalSystem;
    // Start is called before the first frame update
    void Awake()
    {
        portalSystem = FindAnyObjectByType<PortalSystems>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (portalSystem.isMini)
        {
            col.enabled = false;
        }
        else
        {
            col.enabled = true;
        }
    }
}
