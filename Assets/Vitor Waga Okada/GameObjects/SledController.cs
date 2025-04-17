using System.Collections;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

[SerializeField] 
public class SledController : MonoBehaviour

{
    [SerializeField] float speed;
    [SerializeField] float jump;
    private float Move;
    bool grounded;

    [SerializeField] Rigidbody2D sled;
    public static SpriteRenderer sledSkin;
    [SerializeField] TMPro.TextMeshProUGUI coinAmount;


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
        print("Checking enter collision");
        if (other.gameObject.CompareTag("Ground")) {
            print("grounded!");
            Vector3 normal = other.GetContact(0).normal;
            if (normal == Vector3.up) {
                grounded = true;
            }
        }  

        if (other.gameObject.CompareTag("DeathBarrier")) {
            print("Touched death!");
            transform.position = new Vector2((float) -12.5, (float) -5.0);
        }

        if (other.gameObject.CompareTag("Coin")) {
            Destroy(other.gameObject);
            MoneyGameController.Instance.updateMoneyGame();
        }

        if (other.gameObject.CompareTag("Finish")) {
            SceneManager.LoadScene("WinScene");
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) {
            grounded = false;
        }
    }

}
