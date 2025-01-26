using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public Animator animator;
    public AudioManager audioManager;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [Range(0, 0.7f)][SerializeField] private float suavizadoDeMovimiento;
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask[] quePuedeSaltar;
    [SerializeField] private Transform[] controladoresSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool puedeSaltar;
    private bool salto = false;

    [Header("Paredes")]
    [SerializeField] private LayerMask pared;
    [SerializeField] private Transform detector;

    private bool detectorLeft = false;

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
            Debug.Log("<color=#dfb>¡Saltaste!</color>");
        }
    }

    private void FixedUpdate()
    {
        var mover = movimientoHorizontal * Time.fixedDeltaTime;
        if (Physics2D.OverlapBox(detector.position, dimensionesCaja, 0f, pared))
        {
            animator.SetBool("Jump", false);
            if (detectorLeft && mover < 0)
            {
                mover = 0;
            }
            else if (!detectorLeft && mover > 0)
            {
                mover = 0;
            }
        }

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
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
            animator.SetBool("Jump", true);

            if (audioManager != null)
            {

                if (Random.Range(0, 1) == 0)
                {
                    audioManager.PlaySFX(audioManager.Salto_1_D);
                }
                else
                {
                    audioManager.PlaySFX(audioManager.Salto_1_I);
                }
            }
        }

        if (rb2D.linearVelocity.y == 0)
        {
            animator.SetBool("Jump", false);
        }

        puedeSaltar = false;
        salto = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (LayerMask layerMask in quePuedeSaltar)
        {
            if (ControladorPuedeSaltarEnLayer(layerMask))
            {
                puedeSaltar = true;
                break;
            }
        }
    }
    private bool ControladorPuedeSaltarEnLayer(LayerMask layerMask)
    {
        foreach (Transform controladorSuelo in controladoresSuelo)
        {
            if (Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, layerMask))
            {
                return true;
            }
        }
        return false;
    }

    private void Girar()
    {
        detectorLeft = !detectorLeft;
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
