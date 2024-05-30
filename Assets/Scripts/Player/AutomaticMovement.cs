using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticMovement : MonoBehaviour
{
    public float speed;
    private bool isMovingRight = true;
    public bool isMoving = true;
    private bool canMove = true;

    public float cooldownTime = 2.0f; // Tiempo de cooldown en segundos
    private float cooldownTimer;

    public Image coolDownCamuflaje; // Imagen de la barra de cooldown

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Actualizar el timer del cooldown
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Alternar el movimiento si se presiona la tecla Espacio y el cooldown ha expirado
        if (Input.GetKeyDown(KeyCode.Space) && canMove)
        {
            if (isMoving && cooldownTimer <= 0)
            {
                isMoving = false;
                cooldownTimer = cooldownTime; // Reiniciar el cooldown solo al detenerse
            }
            else if (!isMoving)
            {
                isMoving = true; // Reanudar el movimiento sin cooldown
            }
        }

        // Actualizar la barra de cooldown
        UpdateCooldownImage();
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            if (isMoving)
            {
                if (isMovingRight)
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    public void ChangeDirection()
    {
        isMovingRight = !isMovingRight;
    }

    private void UpdateCooldownImage()
    {
        // Actualizar la cantidad de relleno de la imagen en función del tiempo de cooldown restante
        coolDownCamuflaje.fillAmount = 1 - (cooldownTimer / cooldownTime);
    }

    public void StopMoving(bool state)
    {
        isMoving = state;
        canMove = state;
    }
}
