using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField, Header("ジャンプ速度")]
    private float _jumpSpeed;
    [SerializeField, Header("移動速度")]
    private float _moveSpeed;
    [SerializeField, Header("リトライボタン")]
    private GameObject _retry;
    [SerializeField, Header("HP")]
    private Image _hp;
    [SerializeField, Header("衝突相手")]
    private GameObject _colitionEnemy;
    [SerializeField, Header("無敵時間")]
    private float _superTime;
    [SerializeField, Header("点滅時間")]
    private float _flashTime;



    private Vector2 _inputDirection;
    private Rigidbody2D _rigid;
    private bool _bJump;
    private bool _isInvincible = false;
    private float _invincibleTimer;
    private SpriteRenderer _spriteRenderer;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _bJump = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if( _isInvincible  == true)
        {
            _invincibleTimer += Time.deltaTime;
            
            gameObject.layer = LayerMask.NameToLayer("Invisible");
            if (_invincibleTimer  >=  _superTime)
            {
                gameObject.layer = LayerMask.NameToLayer("Player");
                _isInvincible = false;
            }
            
        }
        if (_hp.fillAmount <= 0f)
        {
            Destroy(gameObject);
        }
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

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "People")
        {
            
            _hp.fillAmount -= 0.25f;
            _isInvincible = true;
            _invincibleTimer = 0f;
            StartCoroutine(Invisible());



        }

        if(collision.gameObject.tag == "People")
        {
            Destroy(collision.gameObject);
        }

        IEnumerator Invisible()
        {

            Color color = _spriteRenderer.color;

            for(var i = 0;i < _superTime; i++)
            {
                yield return (new WaitForSeconds(_flashTime));
                _spriteRenderer.color = new Color(color.r, color.g, color.b,0.0f);
                yield return (new WaitForSeconds(_flashTime));
                _spriteRenderer.color = new Color(color.r, color.g, color.b);
            }
            _spriteRenderer.color = color;
        }
        
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed || _bJump) return;
        _rigid.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        _bJump = true;


    }

    

    }
