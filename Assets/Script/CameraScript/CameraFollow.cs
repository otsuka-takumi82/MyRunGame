using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField, Header("プレイヤー情報")]
    private Transform _player;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null) return;
        transform.position = new Vector3(_player.position.x, transform.position.y,transform.position.z);
    }
}
