using UnityEngine;

public class BigSword : MonoBehaviour
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
    public bool _isBigAttacking;
    bool _bigDir = true;
    private float _attackTime;
    //public Collider2D _collider;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transform = GetComponent<Transform>();
        //_collider = GetComponentInChildren<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_angle);
    }

    public void BigSwordAttack()
    {

        if (_isBigAttacking)
        {
            if (_angle == 90)
            {
                _angle = 0;
            }
            if (_angle < 40 && _bigDir)
            {

                _bigSword.SetActive(true);
                _arm.SetActive(false);

                if (_angle >= 35)
                {
                    //Debug.Log("a");
                    _angle += _attackSpeed * 0.01f * Time.deltaTime;
                    _transform.localRotation = Quaternion.Euler(0, 0, _angle);
                }
                if (_angle >= 25)
                {

                    _angle += _attackSpeed * 0.02f * Time.deltaTime;
                    _transform.localRotation = Quaternion.Euler(0, 0, _angle);
                }
                else if (_angle >= 20)
                {
                    _angle += _attackSpeed * 0.2f * Time.deltaTime;
                    _transform.localRotation = Quaternion.Euler(0, 0, _angle);
                }
                else
                {
                    //_bigSword.SetActive(true);
                    //_arm.SetActive(false);
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
                _angle -= _attackSpeed * 5f * Time.deltaTime;
                _transform.localRotation = Quaternion.Euler(0, 0, _angle);
                //Debug.Log(_angle);
            }
            if (_angle <= -90)
            {
                _attackTime += Time.deltaTime;
                Time.timeScale = 0.1f;

            }
            if (_attackTime >= 0.1f)
            {
                Time.timeScale = 1;
                _bigDir = true;
                _angle = 0;
                _transform.localRotation = Quaternion.Euler(0, 0, _angle);
                _attackTime = 0;
                _isBigAttacking = false;
                _arm.SetActive(true);
            }
        }

    }
}
