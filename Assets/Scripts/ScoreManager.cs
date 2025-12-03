using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("UI")]
    public Text scoreText;       // Ekrandaki canlı skor
    public Text highScoreText;   // GameOverPanel'deki "Best: X"

    [Header("Sesler")]
    public AudioClip point;      // Puan alınca çalınacak ses

    private AudioSource audioSource;

    private int score = 0;
    private int highScore = 0;

    private const string HighScoreKey = "HighScore";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Kaydedilmiş high score'u oku
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        // Başlangıç skorunu ve yazıları güncelle
        score = 0;
        UpdateScoreText();
        UpdateHighScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("AddScore çağrıldı, yeni skor = " + score);

        // Skor yazısını güncelle
        UpdateScoreText();

        // Puan sesi
        if (audioSource != null && point != null)
        {
            audioSource.PlayOneShot(point);
        }

        // High score kırıldı mı?
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            PlayerPrefs.Save();
            Debug.Log("Yeni high score: " + highScore);
        }

        // High score yazısını da güncelle
        UpdateHighScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    private void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "Best: " + highScore.ToString();
        }
    }
}
