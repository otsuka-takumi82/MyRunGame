using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrossBow : MonoBehaviour
{
    [SerializeField, Header("クロスボウ")]
    private GameObject _crossBow;
    [SerializeField, Header("ボルト")]
    private GameObject _bolt;
    [SerializeField, Header("ノズル")]
    private GameObject _nozzle;
    [SerializeField,Header("発射間隔")]
    private float _boltLate;

    private Vector3 _mousePos;
    private Player _player;
    public float _angle;
    public bool _isShot;
    private float _lateTimer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        _player = FindAnyObjectByType<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoltDir()
    {
        transform.localRotation = Quaternion.Euler(0, 0, _angle + 27);
        if (_angle <= 90 && _angle >= 0)
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (_mousePos - transform.position).normalized;
            _angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        }
        if (_angle > 90)
        {

            _angle = 90;

        }
        if (_angle < 0)
        {

            _angle = 0;
        }
        
    }
    public void BoltReset()
    {
        _angle = 0;
        transform.localRotation = Quaternion.Euler(0, 0, _angle);
    }

    private void BoltSpawn(GameObject prefab)
    {
        //Instantiate(prefab, new Vector3(transform.position.x, transform.position.y,transform.position.z), Quaternion.identity);
        Instantiate(prefab, _nozzle.transform.position, _nozzle.transform.rotation);

    }

    public void SpawnBolt()
    {
        if( _isShot )
        {
            BoltSpawn(_bolt);
            _player.UseBolt();
            _isShot = false;
        }   
    }

    public void ReLoad()
    {
        if(!_isShot)
        {
            _lateTimer += Time.deltaTime;
        }
        

        if(_lateTimer >= _boltLate)
        {
            _isShot = true;
            _lateTimer = 0;
        }
    }
}
