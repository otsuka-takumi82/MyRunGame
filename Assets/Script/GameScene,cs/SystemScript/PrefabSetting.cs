using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PrefabSetting : MonoBehaviour
{
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


        if (!_player) return;
        
        if (transform.position.x < _player.transform.position.x - 10f)
        {
            Destroy(gameObject);
        }


        
    }
}
