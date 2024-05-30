using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMini : MonoBehaviour
{
    private PortalSystems player;
    private bool isCooldown = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PortalSystems>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCooldown)
        {
            isCooldown = true;

            if (player.isMini)
            {
                player.isMini = false;
                player.ChangeScaleBig();
            }
            else
            {
                player.isMini = true;
                player.ChangeScaleMini();
            }

            StartCoroutine(CooldownRoutine());
        }
    }

    private IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(1f); // Espera 1 segundo antes de permitir otro cambio
        isCooldown = false;
    }
}
