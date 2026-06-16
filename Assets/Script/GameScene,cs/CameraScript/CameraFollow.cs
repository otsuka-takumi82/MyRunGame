using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    
    
    [SerializeField, Header("距離")]
    public float _cameraScale;


    private GameObject _player;

    private void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null) return;
        transform.position = new Vector3(_player.transform.position.x + _cameraScale, transform.position.y,transform.position.z);
    }

    public void SetScope(float Scale,float TimeScale)
    {
        _cameraScale = Scale;
        Time.timeScale = TimeScale;
    }
}
