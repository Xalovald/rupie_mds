using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _movement;

    [Range(1, 20)]
    public float speed = 9;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomX = Random.Range(-1, 1);
        float randomY = Random.Range(-1, 1);
        var movement = new Vector2(randomX, randomY);
        _rigidbody2D.linearVelocity = movement * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
