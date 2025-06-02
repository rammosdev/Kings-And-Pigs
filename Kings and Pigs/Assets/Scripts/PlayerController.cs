using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anima;
    [Header("Atributos")]
    [SerializeField]private float speed;
    private float health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimentação();
    }

    public void Movimentação()
    {
        var move = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocityY);

        //Ajustando a escala dele para ele olhar para onde vai
        if (move != 0)
        {
            //Se o movimento for positivo, a escala vai ser 1
            //Se o movimento for negativo, a escala vai ser -1
            transform.localScale = new Vector3(Mathf.Sign(move), 1f, 1f);
            anima.SetBool("Running", true);

        } else
        {
            anima.SetBool("Running", false);
        }
    }
}
