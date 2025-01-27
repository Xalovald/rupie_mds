using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    [Range(1,20)]
    public float speed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        _movement = new Vector2(Horizontal, Vertical).normalized;

        _animator.SetFloat("Horizontal", Horizontal);
        _animator.SetFloat("Vertical", Vertical);
        _animator.SetFloat("Velocity", _movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = _movement * speed;
    }
}
