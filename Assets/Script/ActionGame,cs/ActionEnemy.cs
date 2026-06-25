using System.Collections;
using UnityEngine;

public class ActionEnemy : MonoBehaviour
{
    public float _enemySpeed;
    public float _enemyJump;

    private Rigidbody2D _rigid;
    private Collider2D _collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _rigid.linearVelocity = new Vector2(_enemySpeed * -1,_rigid.linearVelocity.y);
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
       {
           _rigid.AddForce(Vector2.up * _enemyJump, ForceMode2D.Impulse);
       }
        
    }
    

}
