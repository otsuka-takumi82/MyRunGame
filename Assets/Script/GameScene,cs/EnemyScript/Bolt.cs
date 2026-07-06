using Unity.VisualScripting;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    //[SerializeField]
    //private float _directionPile;
    [SerializeField]
    private float _boltDamege;
    float angle;
    [SerializeField]
    private int _boltType;
    private Player _player;
    private Rigidbody2D _rigid;
    private Vector3 _mousePos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(_boltType == 0)
        {
            _rigid = GetComponent<Rigidbody2D>();
            _player = FindAnyObjectByType<Player>();
            Vector2 direction = (_player.transform.position - transform.position).normalized;
            
            angle = Mathf.Atan2(direction.y * -1, direction.x * -1) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            Destroy(gameObject, 3f);



            _rigid.linearVelocity = (direction * _speed);
        }
        if( _boltType == 1)
        {
            gameObject.layer = LayerMask.NameToLayer("Bolt");
            _rigid = GetComponent<Rigidbody2D>();

            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (_mousePos - transform.position).normalized;
            angle = Mathf.Atan2(direction.y * -1, direction.x * -1) * Mathf.Rad2Deg;
            if (angle > -90)
            {

                Destroy(gameObject);

            }
            else if (angle < -180)
            {

                Destroy(gameObject);
            }
            transform.rotation = Quaternion.Euler(0, 0, angle);
            Destroy(gameObject, 3f);
            _rigid.linearVelocity = (direction * _speed);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arm")
        {
            gameObject.layer = LayerMask.NameToLayer("Bolt");
            Vector2 direction = (_player.transform.position - transform.position).normalized;
            float angle;
            angle = Mathf.Atan2(direction.y * 1, direction.x * 1) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            Destroy(gameObject, 3f);



            _rigid.linearVelocity = (direction * _speed * -1);
        }

        if(collision.gameObject.tag == "Exprotion")
        {
            Destroy(gameObject);
        }
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
        if(collision.gameObject.tag == "UEnemy" || collision.gameObject.tag =="Floor")
        {
            Destroy(gameObject);
        }
        

    }
}
