using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb;
    private float move;
    public float speed = 5f;
    private bool right = true;
    public float jumpHeight = 5f;
    public bool isGrounded = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        if (move < 0f && right == true){
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
            right = false;
        }
        else if (move > 0f && right == false){
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            right = true;
        }
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && isGrounded == true){
            Jump();
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(move, 0f, 0f) * Time.fixedDeltaTime * speed;
    }

    void Jump(){
        rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
    }
    
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Ground"){
            isGrounded = true;
        }
    }
}
