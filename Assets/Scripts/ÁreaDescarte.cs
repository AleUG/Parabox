using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ÁreaDescarte : MonoBehaviour
{
    bool hayPortal;
    GameObject elPortal;

    private CreatePortal createPortal;
    private Animator UIDescarte;

    private void Start()
    {
        createPortal = FindAnyObjectByType<CreatePortal>();
        UIDescarte = GameObject.Find("MarcoUI").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Portal"))
        {
            hayPortal = true;
            elPortal = collision.gameObject;
            UIDescarte.Play("descarte");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Portal"))
        {
            hayPortal = false;
            elPortal = null;
            UIDescarte.Play("back");
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && hayPortal)
        {
            Destroy(elPortal);
            createPortal.RestarPortales();
        }
    }
}
