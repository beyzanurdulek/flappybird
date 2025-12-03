using UnityEngine;

public class PipeMover : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
