using UnityEngine;

public class MovimientoCaballo : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadBase = 5f;
    public float multiplicadorCorrer = 1.5f; 
    public float fuerzaSalto = 7f;

    [Header("Detección de Suelo")]
    public Transform controladorSuelo;
    public LayerMask queEsSuelo;
    public float radioSuelo = 0.2f;

    private Rigidbody2D rb;
    private bool enSuelo;
    private bool estaCorriendo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Detectar si está tocando el suelo
        enSuelo = Physics2D.OverlapCircle(controladorSuelo.position, radioSuelo, queEsSuelo);

        
        estaCorriendo = Input.GetKey(KeyCode.LeftShift);

        
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && enSuelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }
    }

    void FixedUpdate()
    {
       
        float velocidadActual = estaCorriendo ? velocidadBase * multiplicadorCorrer : velocidadBase;
        float movimientoH = Input.GetAxisRaw("Horizontal"); 

        
        rb.velocity = new Vector2(movimientoH * velocidadActual, rb.velocity.y);
    }


    private void OnDrawGizmos()
    {
        if (controladorSuelo != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(controladorSuelo.position, radioSuelo);
        }
    }
}