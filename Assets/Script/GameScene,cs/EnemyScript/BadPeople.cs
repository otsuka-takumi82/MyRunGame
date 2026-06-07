using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BadPeople : MonoBehaviour
{
    [SerializeField, Header("Player")]
    private Transform _player;
    [SerializeField, Header("追跡距離")]
    private float _chaseDistance;
    [SerializeField, Header("追跡速さ")]
    private float _moveSpeed;

    private Rigidbody2D _rigid;
    float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, _player.position);

        if(distance <= _chaseDistance)
        {
            if (_player.position.x >= transform.position.x)
            {
                _rigid.linearVelocityX = _moveSpeed;
            }
            else
            {
                _rigid.linearVelocityX = -_moveSpeed;
            }
        }
    }
}
