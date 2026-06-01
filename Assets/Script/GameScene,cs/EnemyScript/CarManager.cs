using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CarManager : MonoBehaviour
{

    
    [SerializeField, Header("馬車")]
    private GameObject _car;
    [SerializeField, Header("間隔")]
    private float _spacing = 10;
    [SerializeField, Header("プレイヤー")]
    private Transform _player;


    private bool _chackbell;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(_car,
                new Vector3(
                    _player.position.x + _spacing,
                    transform.position.y,
                    transform.position.z),
                Quaternion.identity);

            
        }
    }

   

}
