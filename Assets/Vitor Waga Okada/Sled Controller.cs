using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEditor.UI;
using UnityEngine;

[SerializeField] 
public class NewBehaviourScript : MonoBehaviour

{
    [SerializeField] float speed;
    [SerializeField] float jump;
    private float Move;
    bool grounded;
    private Rigidbody2D sled;
    // Start is called before the first frame update
    void Start()
    {
        sled = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        sled.velocity = new Vector2(Move * speed, sled.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            Debug.Log("JUMP PRESSED");
            sled.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) {
            Vector3 normal = other.GetContact(0).normal;
            if (normal == Vector3.up) {
                grounded = true;
            }
        }  
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) {
            grounded = false;
        }
    }
}
