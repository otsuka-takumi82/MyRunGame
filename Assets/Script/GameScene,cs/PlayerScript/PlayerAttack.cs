using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    public float _attackSpeed;
    [SerializeField]
    private float _attackCoolTime;
    [SerializeField]
    public GameObject _arm;
    [SerializeField]
    public GameObject _bigSword;

    private Transform _transform;
    public float _angle = 0;
    public bool _isAttacking;
    public bool _isBigAttacking;
    bool _bigDir = true;
    private float _attackTime;
    public Collider2D _collider;
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transform = GetComponent<Transform>();
        _collider = GetComponentInChildren<Collider2D>();
        _collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_isBigAttacking);
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
            _collider.enabled = false;
            if (_attackTime >= _attackCoolTime)
            {
                _angle = 90;
                _attackTime = 0;
                _isAttacking = false;

            }
        }
    }

    public void BigSword()
    {
        
        if (_isBigAttacking)
        {
            
            if(_angle < 40 && _bigDir)
            {
                if(_angle >= 35)
                {
                    _angle += _attackSpeed * 0.01f * Time.deltaTime;
                    _transform.localRotation = Quaternion.Euler(0, 0, _angle);
                }
                if (_angle >= 25)
                {
                    _angle += _attackSpeed * 0.02f * Time.deltaTime;
                    _transform.localRotation = Quaternion.Euler(0, 0, _angle);
                }
                else if(_angle >= 20)
                {
                    _angle += _attackSpeed * 0.2f * Time.deltaTime;
                    _transform.localRotation = Quaternion.Euler(0, 0, _angle);
                }
                else
                {
                    _bigSword.SetActive(true);
                    _arm.SetActive(false);
                    _angle += _attackSpeed * 0.5f * Time.deltaTime;
                    _transform.localRotation = Quaternion.Euler(0, 0, _angle);
                }
                
            }
            if (_angle >= 40 && _bigDir)
            {
                _angle = 40;
                _bigDir = false;
            }
            if (_angle <= 40 && _angle >= -90 && !_bigDir)
            {
                _angle -= _attackSpeed * 3f * Time.deltaTime;
                _transform.localRotation = Quaternion.Euler(0, 0, _angle);
                //Debug.Log(_angle);
            }
            if (_angle <= -90)
            {
                _attackTime += Time.deltaTime;
                

            }
            if (_attackTime >= _attackCoolTime)
            {
                _bigDir = true;
                _angle = 0;
                _transform.localRotation = Quaternion.Euler(0, 0, _angle);
                _attackTime = 0;
                _isBigAttacking = false;
                _arm.SetActive(true);
            }
        }

    }

    public void StepAttack()
    {

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
