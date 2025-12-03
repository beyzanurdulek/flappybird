using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ScoreZone Trigger: " + other.name);

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(1);
        }
        else
        {
            Debug.LogWarning("ScoreZone: ScoreManager.Instance NULL!");
        }
    }
}
