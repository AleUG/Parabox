using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticMovement : MonoBehaviour
{
    public float speed;
    public bool isMovingRight = true;
    public bool isMoving = true;
    private bool canMove = true;

    public float cooldownTime = 2.0f; // Tiempo de cooldown en segundos
    private float cooldownTimer;

    public Image coolDownCamuflaje; // Imagen de la barra de cooldown

    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private AudioSource audioSource;
    public AudioClip openAudio;
    public AudioClip closeAudio;

    /// CheckSuelo

    public AudioClip sonidoAterrizaje;
    public LayerMask groundLayer;
    private bool prevGrounded;
    private Collider2D col;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        bool grounded = col.IsTouchingLayers(groundLayer);

        // Si el player estaba en el aire y ahora está en el suelo, reproducir el sonido de aterrizaje
        if (!prevGrounded && grounded)
        {
            audioSource.PlayOneShot(sonidoAterrizaje);
        }

        prevGrounded = grounded;

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
                audioSource.PlayOneShot(closeAudio);
            }
            else if (!isMoving)
            {
                isMoving = true; // Reanudar el movimiento sin cooldown
                audioSource.PlayOneShot(openAudio);
            }
        }

        if (isMoving)
        {
            animator.SetBool("hide", false);
        }
        else if (!isMoving)
        {
            animator.SetBool("hide", true);
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

        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
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
