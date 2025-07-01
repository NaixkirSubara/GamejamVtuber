using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Kecepatan gerakan pemain
    [SerializeField] private float jumpForce = 8f; // Kekuatan lompatan

    [SerializeField] private LayerMask groundLayer; // Layer yang dianggap sebagai tanah
    [SerializeField] private Transform groundCheck; // Objek untuk mengecek apakah pemain di tanah
    [SerializeField] private float groundCheckRadius = 0.2f;

    // public LayerMask terrainLayer;
    private Rigidbody rb;
    private bool isGrounded;
    public SpriteRenderer sr;
    public Animator anim;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

     void Update()
     {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space)  && isGrounded)
        {
            Jump();
            //Debug.LogError("loncat");
        }
     }

    void FixedUpdate()
    {
       
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D atau panah kiri/kanan
        float moveVertical = Input.GetAxis("Vertical");  
        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.linearVelocity = new Vector3(movement.x * moveSpeed, rb.linearVelocity.y, movement.z * moveSpeed);


        if (moveHorizontal != 0 && moveHorizontal < 0)
        {
            sr.flipX = true;
        }
        else if (moveHorizontal != 0 && moveHorizontal >0)
        {
            sr.flipX = false;
        }

         anim.SetFloat("horizontal", Mathf.Abs(moveHorizontal));
         anim.SetFloat("vertical", Mathf.Abs(moveVertical));
    } 
     void Jump()
    {
      
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }  

   
}
