using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField, Header("ジャンプ速度")]
    private float _jumpSpeed;
    [SerializeField, Header("移動速度")]
    private float _moveSpeed;
    [SerializeField, Header("  リトライボタン")]
    private GameObject _retry;



    private Vector2 _inputDirection;
    private Rigidbody2D _rigid;
    private bool _bJump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _bJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rigid.linearVelocity = new Vector2(_moveSpeed, _rigid.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            _bJump = false;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed || _bJump) return;
        _rigid.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        _bJump = true;


    }

    

    }
