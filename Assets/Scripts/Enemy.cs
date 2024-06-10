using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Enemy : MonoBehaviour
{
    private float time = 0.3f;

    private bool isStay = false;

    public HPSystem playerHP;
    public AutomaticMovement movement;
    public Animator animLight;

    private void Update()
    {
        if (isStay && movement.isMoving)
        {
            animLight.SetBool("alert", true);
            StartCoroutine(TimingDeath());
        }
        else
        {
            StopAllCoroutines();
            animLight.SetBool("alert", false);
        }
    }

    private IEnumerator TimingDeath()
    {
        yield return new WaitForSeconds(time);
        playerHP.hp--;
    }

    public void StayPlayer(bool state)
    {
        isStay = state;
    }
}
