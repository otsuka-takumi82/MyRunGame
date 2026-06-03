using UnityEngine;

public class JumpPeople : MonoBehaviour
{
    [SerializeField, Header("ジャンプ速度")]
    private float _jumpSpeed;

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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            _rigid.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            
        }
    }
}
