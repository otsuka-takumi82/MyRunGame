using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrossBow : MonoBehaviour
{
    [SerializeField, Header("クロスボウ")]
    private GameObject _crossBow;

    private Vector3 _mousePos;
    private Player _player;
    private float _angle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _player = FindAnyObjectByType<Player>();
        _angle = Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Deg2Rad;
        transform.localRotation = Quaternion.Euler(0, 0, _angle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoltAttack()
    {
        
    }
}
