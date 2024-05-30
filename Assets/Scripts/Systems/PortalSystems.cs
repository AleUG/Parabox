using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSystems : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public bool isMini;

    public void ChangeGravity()
    {
        rb.gravityScale -= rb.gravityScale * 2;
        player.transform.Rotate(0, 0, 180);

        // Cambiar la dirección en el eje X para voltear el jugador horizontalmente
        Vector3 newDirection = player.transform.localScale;
        newDirection.x *= -1;
        player.transform.localScale = newDirection;
    }

    public void ChangeScaleMini()
    {
        SetPlayerScale(new Vector3(0.5f, 0.5f, 0.5f));
    }

    public void ChangeScaleBig()
    {
        SetPlayerScale(new Vector3(1f, 1f, 1f));
    }

    private void SetPlayerScale(Vector3 scale)
    {
        // Cambiar la escala del jugador
        player.transform.localScale = new Vector3(
            Mathf.Abs(scale.x) * (player.transform.localScale.x < 0 ? -1 : 1),
            scale.y,
            scale.z);
    }
}
