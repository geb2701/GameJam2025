using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [Range(0, 0.3f)][SerializeField] private float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask[] quePuedeSaltar;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool puedeSaltar;
    private bool salto = false;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;

        if (Input.GetButtonDown("Jump"))
        {
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        var mover = movimientoHorizontal * Time.fixedDeltaTime;

        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.linearVelocity.y);
        rb2D.linearVelocity = Vector3.SmoothDamp(rb2D.linearVelocity, velocidadObjetivo, ref velocidad, suavizadoDeMovimiento);

        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        if (puedeSaltar && salto)
        {
            Debug.Log("Salto");
            puedeSaltar = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
        salto = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        puedeSaltar = false;
        foreach (LayerMask layerMask in quePuedeSaltar)
        {
            if (Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, layerMask))
            {
                puedeSaltar = true;
                break;
            }
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
