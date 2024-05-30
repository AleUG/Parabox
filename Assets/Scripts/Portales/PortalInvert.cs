using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalInvert : MonoBehaviour
{
    private PortalSystems player;
    private DragNDrop dragNDrop;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PortalSystems>();
        dragNDrop = GetComponent<DragNDrop>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dragNDrop.canEffect)
        {
            player.ChangeGravity();
        }
    }
}
