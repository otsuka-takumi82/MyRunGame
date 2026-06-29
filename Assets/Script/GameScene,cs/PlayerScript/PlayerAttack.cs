using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float _attackSpeed;

    private Transform _transform;
    private float _angle = 90;
    private bool _isAttack;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        _angle -= _attackSpeed * Time.deltaTime;
        _transform.localRotation = Quaternion.Euler(0, 0, _angle);

        if(_angle <= 0)
        {
            _angle = 90;
        }
    }
}
