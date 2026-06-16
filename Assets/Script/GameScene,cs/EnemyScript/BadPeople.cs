using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BadPeople : MonoBehaviour
{
    [SerializeField, Header("追跡距離")]
    private float _chaseDistance;
    [SerializeField, Header("追跡速さ")]
    private float _moveSpeed;

    private Rigidbody2D _rigid;
    float distance;
    private GameObject _player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       _rigid = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!_player) return;
        distance = Vector2.Distance(transform.position, _player.transform.position);
        
        if(distance <= _chaseDistance)
        {
            if (_player.transform.position.x >= transform.position.x)
            {
                _rigid.linearVelocityX = _moveSpeed;
                transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z);
            }
            else
            {
                _rigid.linearVelocityX = -_moveSpeed;
                transform.localScale = new Vector3( 1, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
