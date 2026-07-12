using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    
    
    [SerializeField, Header("距離")]
    public float _cameraScale;


    private Player _player;
    private float _distanse;
    private float num;
    private bool _start = true;
    private void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = FindFirstObjectByType<Player>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_player == null) return;
       if(_player._onFloor && _start)
        {
            num = _player.transform.position.y;
            _start = false;
        }
            _distanse = num + 4;
                transform.position = new Vector3(_player.transform.position.x + _cameraScale, _distanse + 0.2f,transform.position.z);
    }

    public void SetScope(float Scale,float TimeScale)
    {
        _cameraScale = Scale;
        Time.timeScale = TimeScale;
    }
}
