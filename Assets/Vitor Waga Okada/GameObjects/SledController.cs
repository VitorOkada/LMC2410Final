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
    AudioSource jumpSoundEffectSource;
    [SerializeField] AudioClip jumpSoundEffectClip;
    [SerializeField] TMPro.TextMeshProUGUI coinAmount;



    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        if (SledSkinController.currentSkin == 0 || SledSkinController.currentSkin == 1) {
            if (Input.GetKeyDown(KeyCode.A)) {
                sled.GetComponent<SpriteRenderer>().flipX = true;
            }

            if (Input.GetKeyDown(KeyCode.D)) {
                sled.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        if(SledSkinController.currentSkin == 2) {
            if (Input.GetKeyDown(KeyCode.A)) {
                sled.GetComponent<SpriteRenderer>().flipX = false;
            }

            if (Input.GetKeyDown(KeyCode.D)) {
                sled.GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        sled.velocity = new Vector2(Move * speed, sled.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            Debug.Log("JUMP PRESSED");
            jumpSoundEffectSource = GetComponent<AudioSource>();
            jumpSoundEffectSource.clip = jumpSoundEffectClip;
            jumpSoundEffectSource.Play();
            sled.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeathBarrier")) {
            print("Touched death!");
            transform.position = new Vector2((float) -12.5, (float) -3.0);
        }

        if (other.gameObject.CompareTag("Coin")) {
            Destroy(other.gameObject);
            MoneyGameController.Instance.updateMoneyGame();
        }

        if (other.gameObject.CompareTag("Finish")) {
            string current = SceneManager.GetActiveScene().name;
            if (current == "GameDemo") {
                SceneManager.LoadScene("Jake's Level");
            }

            if (current == "Jake's Level") {
                SceneManager.LoadScene("WinScene");
            }
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

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) {
            grounded = false;
        }
    }

}
