using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalInvert : MonoBehaviour
{
    private GravitySystem player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GravitySystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.ChangeGravity();
        }
    }


}
