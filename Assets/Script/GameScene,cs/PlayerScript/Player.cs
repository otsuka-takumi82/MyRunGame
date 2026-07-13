using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField, Header("プレイヤーコライダー")]
    private CircleCollider2D _playerCollider;
    [SerializeField, Header("プレイヤートランスフォーム")]
    private Transform _transform;
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
    [SerializeField, Header("プレイヤーダメージ")]
    public int _playerDamage;
    [SerializeField, Header("腕ダメージ")]
    public int _armDamage;
    [SerializeField, Header("大砲ダメージ")]
    public int _canonDamage;
    [SerializeField, Header("しゃがみタメ")]
    public float _maxSnike;
    [SerializeField, Header("最大HP")]
    public float _maxHP = 100;
    [SerializeField,Header("王萎え")]
    private float _uMaxScore = 100;
    [SerializeField, Header("人ダメージ")]
    private float _damagePeople = 10;
    [SerializeField, Header("鳥ダメージ")]
    private float _damageBird = 3;
    [SerializeField, Header("盗賊回復")]
    private float _helthThief = 5;
    [SerializeField, Header("発射範囲")]
    private GameObject _crossScale;
    



    [SerializeField, Header("無敵時間")]
    public float _superTime;
    [SerializeField, Header("点滅時間")]
    public float _flashTime;
    [SerializeField]
    private Vector2 _lineForWall = Vector2.right ;
    [SerializeField] LayerMask _wallLayer = 0;

    List<ItemBase> _itemList = new List<ItemBase>();
    private Animator _anim;


    private Vector2 _inputDirection;

    private Rigidbody2D _rigid;
    private bool _bJump;
    private bool _bStep;
    private bool _bStepCool;
    private bool _hiJump = false;
    public bool _isInvincible = false;
    private bool _isPlayerRen;
    private bool _bsnike = false;
    public bool _onFloor = false;
    private bool _isAttackButton;
    private bool _isMax = true;
    private bool _isSAttack = false;
    public bool _isBigSword;
    public bool _isBA = true;
    public bool _isCanon = false;
    private bool _isBuck;
    private bool m_canon = false;
    private bool _isKnockBacking;
    public bool _isCrossDirection;
    private bool _isCrossShooting;
    public bool _isSceneChanging = false;
    public bool _isDialog;
    private float _knockBackTimer = 1f;
    public float _invincibleTimer;
    public float _snikeTimer;
    private float _stepTimer;
    public float _canonTimer1;
    public float _canonTimer2;
    public float _hp;
    float _angle = 0;
    public int _boltNum = 0;
    public SpriteRenderer _spriteRenderer;
    private Color _defaultColor;
    private CameraFollow _cameraFollow;
    private GameObject _spawner;
    public UIManager _uiManager;
    private GameObject _allStage;
    private GameManager _gameManager;
    private ActionEnemy _actionEnemy;
    private RedyDialog _redyDialog;
    public float _uScore = 0;
    private PlayerAttack _arm;
    private BigSword _bigSword;
    private Canon _canon;
    private CrossBow _crossBow;
    private NpcManager _npcManager;
    private UnderSpawner _underSpawner;
    public SpriteRenderer[] _renderers;
    public int _exprotionScale = 0;
    public float _coolTime;
    public float _coolMaxTime;
    public bool _isCave = true;



    private void Awake()
    {
        _renderers = GetComponentsInChildren<SpriteRenderer>();
        _actionEnemy = FindFirstObjectByType<ActionEnemy>();
        _gameManager = FindFirstObjectByType<GameManager>();
        _redyDialog = FindFirstObjectByType<RedyDialog>();
        _arm = FindFirstObjectByType<PlayerAttack>();
        _bigSword = FindFirstObjectByType<BigSword>();
        _canon = FindFirstObjectByType<Canon>();
        _crossBow = FindFirstObjectByType<CrossBow>();
        _npcManager = FindFirstObjectByType<NpcManager>();
        _uiManager = FindFirstObjectByType<UIManager>();
        _underSpawner = FindFirstObjectByType<UnderSpawner>();
        _anim = GetComponent<Animator>();
        if (_gameManager._boxStage < 10)
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
        Time.timeScale = 1f;
        _hp = _gameManager._boxScore;
        _moveSpeed = _gameManager._boxSpeed;
        _uScore = _gameManager._boxUScore;
        _boltNum = _gameManager._boxBolt;
        //Debug.Log(_uScore);
        _bJump = false;
        _bStep = false;
        _bStepCool = false;
        _isCave = true;
        _uiManager.ScoreManage(_hp);
        _uiManager.HPManage(_hp, _maxHP);
        
        if (_gameManager._boxStage >= 10)
        {
            _uiManager.BoltText(_boltNum);
            _uiManager.UScoreManage(_uScore);

        }
        
        if(_gameManager._boxStage >= 1 &&_gameManager._boxStage < 10)
        {
            _redyDialog.Dialog(_gameManager._boxStage - 1);
        }

        _isDialog = true;

    }

    // Update is called once per frame
    void Update()
    {

        _anim.SetBool("Jump", !_onFloor);
        _anim.SetBool("BigSword", _bigSword._isBigAttacking);
        
        if (_gameManager._isCanon)
        {
            _anim.SetBool("Canon1", _canonTimer1 >= 0.1 && _canonTimer1 <= 6 && !_bigSword._isBigAttacking);
            _anim.SetBool("Canon2", _canonTimer1 >= 6 && _canonTimer1 <= 20 && !_bigSword._isBigAttacking);
            _anim.SetBool("Canon3", _canonTimer1 >= 20 && !_bigSword._isBigAttacking);
        }
        
        //_anim.SetBool("Canon3", _canonTimer1 >= 20);

        Debug.Log(_bigSword._isBigAttacking);

        DebugKey();

        _uiManager.SpeedText(_moveSpeed);

        _uiManager.SniceManage(_snikeTimer, _maxSnike);

        if(_gameManager._boxStage > 10 && _gameManager._isCanon)
            //
        {
            if (_gameManager._boxStage > 10 && m_canon)
            {
                _uiManager.CanonImage(0, _canonTimer1, 2);
                _uiManager.CanonImage(1, _canonTimer1 - 2, 6 - 2);
                _uiManager.CanonImage(2, _canonTimer1 - 6, 20 - 6);
            }
            else if (_gameManager._boxStage > 10 && !m_canon)
            {
                _uiManager.CanonImage(0, 0, 2);
                _uiManager.CanonImage(1, 0, 6);
                _uiManager.CanonImage(2, 0, 10);
            }
        }

        if(_gameManager._boxStage == 13)
        {
            if (_gameManager._caveOnOff)
            {
                if (_uScore >= 60 && _isCave)
                {
                    _underSpawner._isCave = true;
                    Debug.Log("a");
                    _isCave = false;
                }

                if (_underSpawner._isCave)
                {
                    _underSpawner.Cave();
                    _underSpawner._isCave = false;
                }
            }
            
        }
       
        

        if (_gameManager._boxStage > 10)
        {
            _uiManager.KeyNum();
            _uiManager.KeyNum1();
            _uiManager.KeyNum2();
            if(_gameManager._isBigSword)
            {
                _uiManager.BigSwordImage(_coolTime, _coolMaxTime);
            }
            
        }

        if(_gameManager._boxStage > 10 && _gameManager._isCrossBow)
        {
            _uiManager.CrossBowImage();
        }

        if (_gameManager._boxStage > 10)
        {
            _uiManager.UScoreGage(_uScore, _uMaxScore);
        }

        if (_gameManager._boxStage >= 1 && _gameManager._boxStage < 10)
        {
            RedyColDia(_gameManager._boxStage - 1);
        }
        
        

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

        if (_moveSpeed >= _maxSpeed)
        {
            _moveSpeed = _maxSpeed;
            if (_isMax)
            {
                _moveSpeed = _maxSpeed;
                _playerDamage += 1;
                _isMax = false;
            }


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

        if (_isAttackButton || _arm._isAttacking)
        {
            _arm.Attack();
           
        }

        if(_bigSword._isBigAttacking)
        {
            if (_isAttackButton == true) return;
            _bigSword.BigSwordAttack();
            _isBA = true;

        }
        else if (!_bigSword._isBigAttacking)
        {
            _coolTime += Time.deltaTime;
            if (_isBA)
            {
                _bigSword._bigSword.SetActive(false);
                _coolTime = 0;
                _isBA = false;
            }
            
        }

        

        if(m_canon)
        {
            _canonTimer1 += Time.deltaTime;
        }
        if(_isCanon)
        {
            _canonTimer2 += Time.deltaTime;
        }
        
        if(_canonTimer2 < 0.1 && _canonTimer2 > 0 && _exprotionScale == 3)
        {
            //_rigid.linearVelocity = new Vector2(0, 0);
            Time.timeScale = 0.1f;
        }
        else
        {
            if (_isBuck && _exprotionScale == 3)
            {
                Time.timeScale = 1;
                _isKnockBacking = true;
                _rigid.AddForce(Vector2.left * 60, ForceMode2D.Impulse);
                _canonTimer2 = 0;
                _isBuck = false;
                _isCanon = false;
            }
            else if(_isBuck && _exprotionScale == 2)
            {
                _isKnockBacking = true;
                _rigid.AddForce(Vector2.left * 20, ForceMode2D.Impulse);
                _canonTimer2 = 0;
                _isBuck = false;
                _isCanon = false;
            }
            else if (_isBuck && _exprotionScale == 1)
            {
                _isKnockBacking = true;
                _rigid.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
                _canonTimer2 = 0;
                _isBuck = false;
                _isCanon = false;
            }
            else if(_isBuck && _exprotionScale == 0)
            {
                Time.timeScale = 1;
                _isBuck = false;
                _isCanon = false;
            }
        }

        if(_isKnockBacking)
        {
            _knockBackTimer -= Time.deltaTime;
            if( _knockBackTimer <= 0 )
            {
                _knockBackTimer = 0.5f;
                _isKnockBacking = false;
            }
        }

        if(_isSAttack)
        {
            SAttack();
        }

        if(_isCrossDirection)
        {
            _crossBow.BoltDir();
            _crossBow.ReLoad();
            if (_isCrossShooting)
            {
                if(_boltNum > 0)
                {
                    _crossBow.SpawnBolt();
                } 
            }
        }


        //else
        //{
        //    _arm.NonAttack();
        //    Debug.Log("a");
        //}
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
            _isPlayerRen = true;
            gameObject.layer = LayerMask.NameToLayer("Invisible");
            if (_invincibleTimer >= _superTime || _invincibleTimer == 0)
            {
                
                
                _invincibleTimer = 0;
                _isInvincible = false;

            }
            

        }
        else
        {
            if(_isPlayerRen)
            {
                gameObject.layer = LayerMask.NameToLayer("Player");
                DefaultColor();
                _isPlayerRen = false;
            }
            
            
        }
        if (_hp <= 0f)
        {
            
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
            Destroy(_allStage);

        }

    }


    public void DebugKey()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _moveSpeed *= 2f;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            _hp = 0f;
        }
    }

    private void FixedUpdate()
    {
        if (_bStep) return;
        if (_isKnockBacking) return;
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

        if (collision.CompareTag("CameraStart"))
        {
            //_cameraFollow.enabled = true;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Rest"))
        {
            _isSceneChanging = true;
            _gameManager._boxScore = _hp;
            _gameManager._boxSpeed = _moveSpeed;
            _gameManager._boxUScore = _uScore;
            _gameManager._boxBolt = _boltNum;
            
            //Destroy(collision.gameObject);
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

        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Enemy")
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
                _uiManager.HPManage(_hp, _maxHP);
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

            


        }
        

        if (collision.gameObject.tag == "Thief")
        {
            GetHp(_helthThief);
        }

        if (collision.gameObject.tag == "People" || collision.gameObject.tag == "Thief" || collision.gameObject.tag == "Bird") //|| collision.gameObject.tag == "UEnemy")
        {

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Piero")
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
            foreach (var renderers in _renderers)
            {
                renderers.color = new Color(1, 1, 1, 0);
            }
            yield return (new WaitForSecondsRealtime(_flashTime));
            foreach (var renderers in _renderers)
            {
                renderers.color = new Color(1, 1, 1);
            }

            _spriteRenderer.color = new Color(color.r, color.g, color.b);

        }
        //Debug.Log("a");
        _spriteRenderer.color = color;
        _isInvincible = false;
        //Debug.Log("b");
    }

    

    public void DefaultColor()
    {
        Color color = _spriteRenderer.color;
        _spriteRenderer.color = new Color(color.r, color.g, color.b);
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
        _rigid.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
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

        if (_onFloor)
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
        

        else 
        {
            if (context.canceled)
            {
                _bsnike = false;

                _snikeTimer = 0;

            }

            if (context.performed)
            {
                _rigid.AddForce(Vector2.down * _jumpSpeed, ForceMode2D.Impulse);
            }
            
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

    public void OnArm(InputAction.CallbackContext context)
    {
        if(!_isCrossDirection)
        {
            if (context.started)
            {
                if (_bigSword._isBigAttacking == true) return;
                _isAttackButton = true;



            }
            if (context.canceled)
            {
                if (_bigSword._isBigAttacking == true) return;
                _isAttackButton = false;

            }

            if (context.performed && _bStep)
            {
                if (_bigSword._isBigAttacking == true) return;
                _isSAttack = true;
                _rigid.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
                _rigid.AddForce(Vector2.right * _stepSpeed, ForceMode2D.Impulse);

            }
            else
            {

            }
        }
        else
        {
            if (context.started)
            {
                
                _isCrossShooting = true;
                _crossScale.SetActive(false);

            }
            if (context.canceled)
            {
                _isCrossShooting = false;
                _crossScale.SetActive(true);

            }

            if (_crossBow._isShot == true)
            {
                if (context.performed)
                {
                    _crossScale.SetActive(false);
                    _isCrossShooting = true;
                }
            }
            
        }
        
       
    }

    public void OnBigSword(InputAction.CallbackContext context)
    {
        if (!_gameManager._isBigSword) return;
        if (BigTimer())
        {
            if (context.performed)
            {
                if (_isAttackButton == true) return;
                _bigSword._isBigAttacking = true;


            }
        }
        
        
    }

    public bool BigTimer()
    {
        return _coolTime >= _coolMaxTime;

    }

    public void OnCanon(InputAction.CallbackContext context)
    {
        if(_gameManager._boxStage > 10 && _gameManager._isCanon)
        {
            if (context.started)
            {
                
                m_canon = true;


            }
            if (_isSceneChanging) return;
            if (context.canceled)
            {
                _exprotionScale = 0;
                m_canon = false;
                
                if (_canonTimer1 >= 20)
                {
                    _moveSpeed = 5;
                    _playerDamage = 1;
                    _isCanon = true;
                    _isBuck = true;
                    _canon.Exprotion(2);
                    _exprotionScale = 3;
                    _canonDamage = 2;
                    _canonTimer1 = 0;
                }
                else if (_canonTimer1 >= 6)
                {
                    _isBuck = true;
                    _canon.Exprotion(1);
                    _exprotionScale = 2;
                    _canonDamage = 1;
                    _canonTimer1 = 0;
                }
                else if (_canonTimer1 >= 2)
                {
                    _isBuck = true;
                    _canon.Exprotion(0);
                    _exprotionScale = 1;
                    _canonDamage = 1;
                    _canonTimer1 = 0;
                }
                _canonTimer1 = 0;
            }
        }
        
    }

    public void OnCrossBow(InputAction.CallbackContext context)
    {
        if (!_gameManager._isCrossBow) return;
        if(context.performed)
        {
            if (!_isCrossDirection)
            {
                _isCrossDirection = true;
                _crossScale.SetActive(true);
            }
            else
            {
                _crossScale.SetActive(false);
                _isCrossDirection = false;
                _crossBow.BoltReset();
            }
            
        }
    }

    public void GetBolt()
    {
        _boltNum++;
        _uiManager.BoltText( _boltNum );
    }
    public void NockBack()
    {
        _isKnockBacking = true;
        _rigid.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
    }
    public void UseBolt()
    {
        _boltNum--;
        _uiManager.BoltText(_boltNum);
    }

    public void StartInvisible()
    {
        StartCoroutine(Invisible());
    }

   public void RedyColDia(int num)
    {
        Vector2 start = transform.position;
        Debug.DrawLine(start, start + _lineForWall);
        RaycastHit2D hit = Physics2D.Linecast(start,start + _lineForWall,_wallLayer);
        if(hit.collider)
        {
            if(_isDialog)
            _redyDialog.DiaCollisionlog(num);
            _isDialog = false;
        }

    }

    public void GetItem(ItemBase item)
    {
        _itemList.Add(item);
    }

    public void GetHp(float health)
    {
        _hp += health;
        _uiManager.HPManage(_hp, _maxHP);
        _uiManager.ScoreManage(_hp);
    }

    public void SAttack()
    {
        
        if (_angle > -360)
        {
            _arm._collider.enabled = true;
            gameObject.layer = LayerMask.NameToLayer("EnemyInvisible");
            _angle -= 1000 * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 0, _angle);
            _isSAttack = true;
            
            if(_angle <= -300 && _angle >= -330)
            {
                
                    Time.timeScale = 0.5f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
        else
        {
            if (_isSAttack)
            {
                _arm._collider.enabled = false;
                gameObject.layer = LayerMask.NameToLayer("Player");
                _angle = 0;
                _rigid.AddForce(Vector2.down * _jumpSpeed, ForceMode2D.Impulse);
                _isSAttack = false;
            }
                
        }

    }

}
