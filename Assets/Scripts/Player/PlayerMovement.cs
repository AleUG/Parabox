using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public LayerMask groundLayer;

    public bool canJump, canMove;
    public bool grounded;

    private Rigidbody2D rb;
    private Animator animator;

    float horizontal;


    Vector3 posicionAnterior;
    Vector3 direccion;
    int sueloCount;
    Collider2D col;
    Vector2[] groundCheckPos;
    bool prevGround;

    // Start is called before the first frame update
    void Awake()
    {
        groundCheckPos = new Vector2[3];
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckSuelo();
        Jump();
        Movement();

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
    }

    private void Movement()
    {
        if (!canMove) return;

        /*if (!saltando && !grounded && !checkCayendo)
        {
            checkCayendo = true;
            StartCoroutine(CheckAterrizaje());
        }*/

        horizontal = Input.GetAxis("Horizontal") * speed;
        SonidosPaso();
    }

    private void Jump()
    {
        if (!canJump) return;

        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Aplica una fuerza instantánea hacia arriba
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // Activa la animación de salto
            animator.SetTrigger("Jump");
        }
    }

    public void HaySuelo(bool state)
    {
        grounded = state;
    }

    public void SonidosPaso()
    {

    }

    void CheckSuelo()
    {
        // obtener la direccion del objeto calculando la posición en el frame anterior y restandole la posicion actual
        direccion = (transform.position - posicionAnterior) / Time.deltaTime;
        posicionAnterior = transform.position;

        // esto es para saber si en el frame anterior estaba o no en el suelo
        prevGround = grounded;

        // acá viene la magia negra
        sueloCount = 0;
        Bounds bounds = col.bounds;

        // abajo Izquierda
        groundCheckPos[0] = new Vector2(bounds.center.x - bounds.extents.x, bounds.center.y - bounds.extents.y);

        // abajo Centro
        groundCheckPos[1] = new Vector2(bounds.center.x, bounds.center.y - bounds.extents.y);

        // abajo Derecha
        groundCheckPos[2] = new Vector2(bounds.center.x + bounds.extents.x, bounds.center.y - bounds.extents.y);

        for (int i = 0; i < 3; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(groundCheckPos[i], Vector2.down, 0.05f, groundLayer);
            if (hit.collider != null)
                sueloCount++;
        }

        // si alguno de los 3 raycast toca suelo, entonces hay piso
        grounded = sueloCount > 0;
    }
}

