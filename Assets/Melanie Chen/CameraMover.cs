using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal * moveSpeed * Time.deltaTime, 0, 0);
    }
}
