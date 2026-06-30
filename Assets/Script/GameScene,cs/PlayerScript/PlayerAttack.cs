using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float _attackSpeed;
    [SerializeField]
    private float _attackCoolTime;

    private Transform _transform;
    private float _angle = 90;
    public bool _isAttacking;
    private float _attackTime;
    public Collider2D _collider;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transform = GetComponent<Transform>();
        _collider = GetComponentInChildren<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        _collider.enabled = true;
        _angle -= _attackSpeed * Time.deltaTime;
        _transform.localRotation = Quaternion.Euler(0, 0, _angle);
        _isAttacking = true;
        //Debug.Log(_angle);

        if(_angle <= 0)
        {
            _angle = 0;
            _attackTime += Time.deltaTime;
            if(_attackTime >= _attackCoolTime)
            {
                _angle = 90;
                _attackTime = 0;
                _isAttacking = false;
                _collider.enabled = false;

            }
        }
    }

    //public void NonAttack()
    //{
    //    if(_angle > 0)
    //    {
    //        _collider.enabled = true;
    //        _angle -= _attackSpeed * Time.deltaTime;
    //        _transform.localRotation = Quaternion.Euler(0, 0, _angle);
    //    }
    //    else
    //    {
    //        _angle = 0;
    //        _collider.enabled = false;
    //    }
    //    //
    //}

}
