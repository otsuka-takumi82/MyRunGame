using System.Collections;
using UnityEngine;

public class ActionEnemy : MonoBehaviour
{
    public float _enemySpeed;
    public float _enemyJump;
    public float _enemyDamege;
    public float _uAddScore;


    public GameObject _playerRenderer;
    private Rigidbody2D _rigid;
    private Collider2D _collider;
    private Player _player;
    
    //private UIManager _uUIManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRenderer = GameObject.FindWithTag("Player");
        _rigid = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _player = FindFirstObjectByType<Player>();
        //_uUIManager = FindFirstObjectByType<UIManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _rigid.linearVelocity = new Vector2(_enemySpeed * -1, _rigid.linearVelocity.y);
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
       {
           _rigid.AddForce(Vector2.up * _enemyJump, ForceMode2D.Impulse);
       }

        if (collision.gameObject.tag == "Player")
        {
            _player._uScore += _uAddScore;
            _player._uiManager.UScoreManage(_player._uScore);
            if (_enemyDamege > 0)
            {
                _player._hp -= _enemyDamege;
                _player._uiManager.HPManage(_player._hp, _player._maxHP);
                _player._uiManager.ScoreManage(_player._hp);
                
            }
            
        }

        //IEnumerator Invisible()
        //{

        //    Color color = _player._spriteRenderer.color;

        //    for (var i = 0; i < _player._superTime; i++)
        //    {
        //        yield return (new WaitForSeconds(_player._flashTime));
        //        _player._spriteRenderer.color = new Color(color.r, color.g, color.b, 0.0f);
        //        yield return (new WaitForSeconds(_player._flashTime));
        //        _player._spriteRenderer.color = new Color(color.r, color.g, color.b);

        //    }
        //    _player._spriteRenderer.color = new Color(color.r, color.g, color.b);
        //    _player._spriteRenderer.color = Color.yellow;
        //    _player._isInvincible = false;
        //}

    }
    

}
