using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using UnityEngine;

public class ActionEnemy : MonoBehaviour
{
    [SerializeField]
    public int _enemyHP;
    [SerializeField]
    public float _enemySpeed;
    [SerializeField]
    public float _enemyJump;
    [SerializeField]
    public float _uBuckSpeed;
   
    [SerializeField]
    public float _uSuperTime;
    [SerializeField]
    public float _uFlashTime;
    [SerializeField]
    public float _enemyDamege;
    [SerializeField]
    public float _uAddScore;
    [SerializeField]
    public Sprite[] _UEnemyArmored;
    [SerializeField]
    public GameObject _bolt;
    [SerializeField]
    private EnemyType _enemyType;
    [SerializeField]
    private float _boltLate;
    [SerializeField]
    public float _boltDistans;
    

    public GameObject _playerRenderer;
    private Rigidbody2D _rigid;
    private Collider2D _collider;
    private Player _player;
    private SpriteRenderer _uEnemyRenderer;
    private int _boltPile = 1;
    bool _isBolt = true;
    private bool _uIsInvincible;
    private float _uInvincibleTimer;
    private bool _isNock = true;
    public float _speedPile = -1;
    public enum EnemyType
    {
        Solder,
        Knight,
        HeviKnight,
        Archer
    }
    //private int _armoredIndex = 0;
    
    //private UIManager _uUIManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        _playerRenderer = GameObject.FindWithTag("Player");
        _rigid = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _uEnemyRenderer = GetComponent<SpriteRenderer>();
        _player = FindFirstObjectByType<Player>();
        //if (_enemyType == EnemyType.Archer)
        //{
        //    InvokeRepeating(nameof(SpawnBolt), 0.5f, _boltLate);
        //}
        //_uUIManager = FindFirstObjectByType<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (_enemyType == EnemyType.Archer)
        {
            float distans = transform.position.x - _player.transform.position.x;
            if (Mathf.Abs(distans) <= _boltDistans)
            {
                if (_isBolt)
                {
                    InvokeRepeating(nameof(SpawnBolt), 0.5f, _boltLate);
                    _isBolt = false;
                }
                if (distans >= 0)
                {
                    this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
                }
                else
                {
                    this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
                    _boltPile = -1;
                }
            }
        }
        else
        {
            if(_isNock)
            {
                _rigid.linearVelocity = new Vector2(_enemySpeed * _speedPile, _rigid.linearVelocity.y);
            }
            
        }

        if (_uIsInvincible == true)
        {
            _uInvincibleTimer += Time.deltaTime;

            gameObject.layer = LayerMask.NameToLayer("EnemyInvisible");
            if (_uInvincibleTimer >= _uSuperTime)
            {
                gameObject.layer = LayerMask.NameToLayer("UEnemy");
                _uIsInvincible = false;
                _isNock = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BigSword")
        {
            Destroy(gameObject,0.15f);
            _player._uScore += _uAddScore;
            _player._uiManager.UScoreManage(_player._uScore);
        }
        if (collision.gameObject.tag == "Arm")
        {
            Debug.Log(collision.gameObject.tag);
            _enemyHP -= _player._armDamage;
            if (_enemyHP >= 1)
            {
                if (_enemyHP < _UEnemyArmored.Length - 1 || _UEnemyArmored == null)
                {
                    _uEnemyRenderer.sprite = _UEnemyArmored[_enemyHP - 1];
                    _isNock = false;
                    _rigid.AddForce(Vector2.right * _uBuckSpeed, ForceMode2D.Impulse);
                    
                    StartUInvisible();

                }
                if(_enemyHP == 1)
                {
                    _enemyJump = 0;
                    //_enemySpeed *= 2;
                    //_speedPile *= -1;
                }

                
            }
            else
            {
                {
                    Destroy(gameObject);
                    _player._uScore += _uAddScore;
                    _player._uiManager.UScoreManage(_player._uScore);

                }


            }
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(_enemyType == EnemyType.Archer)
        {
            if(collision.gameObject.tag == "Bolt")
            {
                Destroy(gameObject);
                _player._uScore += _uAddScore;
                _player._uiManager.UScoreManage(_player._uScore);
            }
        }

        if (collision.gameObject.tag == "Floor")
        {
            _rigid.AddForce(Vector2.up * _enemyJump, ForceMode2D.Impulse);
        }

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.gameObject.tag);
            _enemyHP -= _player._playerDamage ;
            if (_enemyHP >= 1)
            {
                if (_enemyHP < _UEnemyArmored.Length - 1 || _UEnemyArmored == null)
                {
                    _uEnemyRenderer.sprite = _UEnemyArmored[_enemyHP - 1];

                }
                
                if (collision.gameObject.tag == "Player")
                {
                    _player._hp -= _enemyDamege;
                    _player._uiManager.HPManage(_player._hp, _player._maxHP);
                    _player._uiManager.ScoreManage(_player._hp);
                    _player._isInvincible = true;
                    _player._invincibleTimer = 0f;
                    _player.StartInvisible();
                }

            }
            else
            {
                {
                    Destroy(gameObject);
                    _player._uScore += _uAddScore;
                    _player._uiManager.UScoreManage(_player._uScore);

                }


            }


        }
    }


    public IEnumerator UInvisible()
    {
        Color color = _uEnemyRenderer.color;

        for (var i = 0; i < _uSuperTime; i++)
        {
            yield return (new WaitForSecondsRealtime(_uFlashTime));
            _uEnemyRenderer.color = new Color(color.r, color.g, color.b, 0.0f);

            yield return (new WaitForSecondsRealtime(_uFlashTime));
            _uEnemyRenderer.color = new Color(color.r, color.g, color.b);

        }
        //Debug.Log("a");
         _uEnemyRenderer.color = color;
        
        //Debug.Log("b");
    }



    private void BoltSpawn(GameObject prefab)
    {
        Instantiate(prefab, new Vector3(gameObject.transform.position.x -0.5f * _boltPile, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);

    }

    private void SpawnBolt()
    {
        BoltSpawn(_bolt);
    }

    public void StartUInvisible()
    {
        _uIsInvincible = true;
        _uInvincibleTimer = 0f;
        StartCoroutine(UInvisible());
    }


}
