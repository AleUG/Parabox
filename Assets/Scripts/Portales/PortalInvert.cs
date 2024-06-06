using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalInvert : MonoBehaviour
{
    private PortalSystems player;
    private DragNDrop dragNDrop;

    private AudioSource audioSource;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PortalSystems>();
        dragNDrop = GetComponent<DragNDrop>();
        audioSource = GetComponent<AudioSource>();
        animator = GameObject.Find("PanelGravityInvert").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dragNDrop.canEffect)
        {
            player.ChangeGravity();
            audioSource.Play();
            animator.SetTrigger("enter");
        }
    }
}
