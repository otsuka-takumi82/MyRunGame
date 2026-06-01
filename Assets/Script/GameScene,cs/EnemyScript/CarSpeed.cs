using UnityEngine;

public class CarSpeed : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    private float _moveSpeed ;

    private Rigidbody2D _rigid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rigid.linearVelocity = new Vector2(_moveSpeed * -1, _rigid.linearVelocity.y);
    }
}
