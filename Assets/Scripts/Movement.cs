using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //transform.position += movement * speed * Time.deltaTime;
        transform.Translate(moveHorizontal, 0, moveVertical);


    }
}

