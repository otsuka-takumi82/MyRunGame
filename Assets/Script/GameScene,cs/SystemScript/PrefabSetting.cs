using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PrefabSetting : MonoBehaviour
{
    private Transform _player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (_player == null) return;
        if (transform.position.x < _player.position.x - 10f)
        {
            Destroy(gameObject);
        }

        
    }
}
