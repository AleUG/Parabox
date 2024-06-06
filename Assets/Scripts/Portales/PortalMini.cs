using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMini : MonoBehaviour
{
    private PortalSystems player;
    private DragNDrop dragNDrop;
    private bool isCooldown = false;

    private Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PortalSystems>();
        dragNDrop = GetComponent<DragNDrop>();
        animator = GameObject.Find("PanelMini").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCooldown && dragNDrop.canEffect)
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

            animator.SetTrigger("enter");

            StartCoroutine(CooldownRoutine());
        }
    }

    private IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(1f); // Espera 1 segundo antes de permitir otro cambio
        isCooldown = false;
    }
}
