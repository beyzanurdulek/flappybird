using UnityEngine;

public class BirdController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public float jumpForce = 5f;

    [Header("Sesler")]
    public AudioClip flap;   // zıplama sesi
    public AudioClip die;    // ölme sesi

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private bool isDead = false;


    void Awake()
    {
    
        rb = GetComponent<Rigidbody2D>();
         audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (isDead) return; // öldüyse artık kontrol etme

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            // Flap sesi
            audioSource.PlayOneShot(flap);

            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

void OnCollisionEnter2D(Collision2D collision)
{
    // Eğer zaten öldüyse tekrar tetiklenmesin
    if (isDead) return;

    // Pipe veya Ground çarpınca öl
    if (collision.collider.CompareTag("Pipe") || collision.collider.CompareTag("Ground"))
    {
        isDead = true;

        // Ölme sesi
        audioSource.PlayOneShot(die);

        Debug.Log("GAME OVER!");

        // Oyunu durdur
        Time.timeScale = 0f;

        // Game Over Paneli aç
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}


}
