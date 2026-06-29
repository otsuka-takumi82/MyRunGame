using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _boltDamege;
    private Player _player;
    private Rigidbody2D _rigid;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _player = FindAnyObjectByType<Player>();
        Vector2 direction = (_player.transform.position - transform.position).normalized;
        float angle;
        angle = Mathf.Atan2(direction.y * -1, direction.x * -1) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle);
        Destroy(gameObject,3f);
        
        
        
        _rigid.linearVelocity = (direction * _speed);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            _player._hp -= _boltDamege;
            _player._uiManager.HPManage(_player._hp, _player._maxHP);
            _player._uiManager.ScoreManage(_player._hp);
            _player._isInvincible = true;
            _player._invincibleTimer = 0f;
            _player.StartInvisible();
        }
    }
}
