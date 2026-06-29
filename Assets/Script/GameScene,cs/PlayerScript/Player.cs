using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField, Header("プレイヤーコライダー")]
    private CircleCollider2D _playerCollider;
    [SerializeField, Header("プレイヤートランスフォーム")]
    private Transform _transform ;
    [SerializeField, Header("ジャンプ速度")]
    private float _jumpSpeed;
    [SerializeField]
    private float _jumpPiler;
    [SerializeField, Header("ステップ速度")]
    private float _stepSpeed;
    [SerializeField, Header("ステップクールタイム")]
    private float _stepCoolTime;
    [SerializeField, Header("移動速度")]
    public float _moveSpeed;
    [SerializeField, Header("移動速度倍率")]
    private float _speedpiler;
    [SerializeField]
    private float _maxSpeed;
    [SerializeField, Header("しゃがみタメ")]
    public float _maxSnike;
    [SerializeField, Header("最大HP")]
    public float _maxHP = 100;
    [SerializeField, Header("人ダメージ")]
    private float _damagePeople = 10;
    [SerializeField, Header("鳥ダメージ")]
    private float _damageBird = 3;
    [SerializeField, Header("盗賊回復")]
    private float _helthThief = 5;
    
    [SerializeField, Header("無敵時間")]
    public float _superTime;
    [SerializeField, Header("点滅時間")]
    public float _flashTime;
    





    private Vector2 _inputDirection;
    private Rigidbody2D _rigid;
    private bool _bJump;
    private bool _bStep;
    private bool _bStepCool;
    private bool _hiJump = false;
    public bool _isInvincible = false;
    private bool _bsnike = false;
    private bool _onFloor = false;
    public float _invincibleTimer;
    public float _snikeTimer;
    private float _stepTimer;
    public float _hp;
    public SpriteRenderer _spriteRenderer;
    private Color _defaultColor;
    private CameraFollow _cameraFollow;
    private GameObject _spawner;
    public UIManager _uiManager;
    private GameObject _allStage;
    private GameManager _gameManager;
    private ActionEnemy _actionEnemy;
    public float _uScore = 0;


    private void Awake()
    {
        _actionEnemy = FindFirstObjectByType<ActionEnemy>();
        _gameManager = FindFirstObjectByType<GameManager>();
        _uiManager = FindFirstObjectByType<UIManager>();
        if(_gameManager._boxStage < 10)
        {
            _spawner = FindFirstObjectByType<Spawner>().gameObject;
        }
        _allStage = GameObject.Find("AllStage");
        _cameraFollow = FindFirstObjectByType<CameraFollow>();
        _playerCollider = GetComponent<CircleCollider2D>();
        _rigid = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor = _spriteRenderer.color;
        //_uiManager.ScoreManage();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _hp = _gameManager._boxScore;
        _moveSpeed = _gameManager._boxSpeed;
        _bJump = false;
        _bStep = false;
        _bStepCool = false;
        _uiManager.ScoreManage(_hp);
        _uiManager.HPManage(_hp, _maxHP);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_hp);

        DebugKey();
        
        _uiManager.SpeedText(_moveSpeed);

        _uiManager.SniceManage(_snikeTimer,_maxSnike);

        if (_bsnike && !_bJump)
        {

            _transform.localScale = new Vector2(3, 1.5f);
            _playerCollider.radius = 0.25f;

        }
        else
        {
            _transform.localScale = new Vector2(3, 3);
            _playerCollider.radius = 0.5f;
        }

        if (_hp > 100)
        {
            _uiManager.ScoreColor(Color.yellow);
        }
        else if (_hp <= 30)
        {
            _uiManager.ScoreColor(Color.red);
        }
        else
        {
            _uiManager.ScoreColor(Color.black);
        }

        if (_moveSpeed > _maxSpeed)
        {
            _moveSpeed = _maxSpeed;
        }


        if (_bStepCool)
        {
            _stepTimer += Time.deltaTime;
        }

        if (_stepTimer >= _stepCoolTime)
        {
            _bStepCool = false;
            _stepTimer = 0;
        }

        if (_stepTimer > 0.5f && _stepTimer < _stepCoolTime)
        {
            _bStep = false;
        }

        if (_bsnike && _onFloor)
        {
            _snikeTimer += Time.deltaTime;
            
        }

        if (_snikeTimer >= _maxSnike)
        {
            _hiJump = true;
            
        }
        else
        {
            _hiJump = false;
        }

        //if (_hiJump)
        //{
        //    _spriteRenderer.color = new Color(50, 0, 0);
        //}
        //else if (!_hiJump)
        //{
        //    _spriteRenderer.color = new Color(_defaultColor.r, _defaultColor.g, _defaultColor.b);
        //}

        if (_isInvincible == true)
        {
            _invincibleTimer += Time.deltaTime;

            gameObject.layer = LayerMask.NameToLayer("Invisible");
            if (_invincibleTimer >= _superTime)
            {
                gameObject.layer = LayerMask.NameToLayer("Player");
                //_isInvincible = false;
            }

        }
        if (_hp <= 0f)
        {
            Destroy(gameObject);
            Destroy(_allStage);
            
        }

    }

    public void DebugKey()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            _moveSpeed *= 3f;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            _hp = 0f;
        }
    }

private void FixedUpdate()
    {
        if (_bStep) return;
        _rigid.linearVelocity = new Vector2(_moveSpeed, _rigid.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Stopper"))
        {
            _spawner.SetActive(false);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("CameraStop"))
        {
            _cameraFollow.enabled = false;
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("CameraStart"))
            {
            _cameraFollow.enabled = true;
            Destroy(collision.gameObject);
            }
        if(collision.CompareTag("Rest"))
        {
            _gameManager._boxScore = _hp;
            _gameManager._boxSpeed = _moveSpeed;
            SceneManager.LoadScene("RestScene");
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Clear"))
        {
            _gameManager._boxScore = _hp;
            SceneManager.LoadScene("ClearScene");
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //if (collision.gameObject)
        //{
        //    Debug.Log(collision.gameObject.name);
        //}

            if (collision.gameObject.tag == "Floor" ||collision.gameObject.tag == "Enemy")
        {
            
            _bJump = false;
            _bStep = false;
            _onFloor = true;

        }
        if (!_isInvincible)
        {
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "People")
            {

                _hp -= _damagePeople;
                _uiManager.HPManage(_hp,_maxHP);
                _uiManager.ScoreManage(_hp);
                _isInvincible = true;
                _invincibleTimer = 0f;
                StartCoroutine(Invisible());
            }


            if (collision.gameObject.tag == "Bird")
            {
                _hp -= _damageBird;
                _uiManager.HPManage(_hp, _maxHP);
                _uiManager.ScoreManage(_hp);
                _isInvincible = true;
                _invincibleTimer = 0f;
                StartCoroutine(Invisible());
            }

            //if(collision.gameObject.tag == "UEnemy")
            //{
            //        _isInvincible = true;
            //        _invincibleTimer = 0f;
            //        StartCoroutine(Invisible());
                
                
            //}

            
        }

        if (collision.gameObject.tag == "Thief")
        {
            _hp += _helthThief;
            _uiManager.HPManage(_hp, _maxHP);
            _uiManager.ScoreManage(_hp);
        }

        if(collision.gameObject.tag == "People" || collision.gameObject.tag == "Thief" || collision.gameObject.tag == "Bird") //|| collision.gameObject.tag == "UEnemy")
        {
            
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Piero")
        {
            _hp += 50;
            _uiManager.HPManage(_hp, _maxHP);
            _uiManager.ScoreManage(_hp);
        }


        
        
        
    }

    public IEnumerator Invisible()
    {
        Color color = _spriteRenderer.color;

        for (var i = 0; i < _superTime; i++)
        {
            yield return (new WaitForSecondsRealtime(_flashTime));

            _spriteRenderer.color = new Color(color.r, color.g, color.b, 0.0f);
            yield return (new WaitForSecondsRealtime(_flashTime));

            _spriteRenderer.color = new Color(color.r, color.g, color.b);

        }
        //Debug.Log("a");
        _spriteRenderer.color = color;
        _isInvincible = false;
        //Debug.Log("b");
    }

    public void OnJump(InputAction.CallbackContext context)
        
    {
        
        if (context.performed && !_bJump && !_hiJump)
        {

            _rigid.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            _bJump = true;
            
            _onFloor = false;
            _snikeTimer = 0;
        }

        if (context.performed && !_bJump && _hiJump)
        {
            _rigid.AddForce(Vector2.up * _jumpSpeed * _jumpPiler, ForceMode2D.Impulse);
            _bJump = true;
            _onFloor = false;
            _snikeTimer = 0;

        }


    }
    public void OnStep(InputAction.CallbackContext context)
    {
        if (!context.performed || _bStepCool == true) return;

        
        _rigid.AddForce(Vector2.right * _stepSpeed, ForceMode2D.Impulse);
        _bStep = true;
        _bStepCool = true;
        _moveSpeed *= _speedpiler;

    }

    //public static class GameManager
    //{
    //    public static float _score;
    //}

    public void Onsnike(InputAction.CallbackContext context)
    {
        

        if (context.started && _onFloor == true)
        {
            _bsnike = true;

        }

        if (context.canceled)
        {
            _bsnike = false;
            
            _snikeTimer = 0;
            
        }


       

    }

    public void OnScope(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _cameraFollow.SetScope(20, 0.3f);
            
        }

        if (context.canceled)
        {
            _cameraFollow.SetScope(10, 1f);
        }
    }

    public void StartInvisible()
    {
        StartCoroutine(Invisible());
    }



}
