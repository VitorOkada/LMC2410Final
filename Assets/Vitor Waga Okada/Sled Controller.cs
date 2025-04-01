using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEditor.UI;
using UnityEngine;

[SerializeField] 
public class NewBehaviourScript : MonoBehaviour

{
    [SerializeField] float speed;
    private float Move;
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
    }
}
