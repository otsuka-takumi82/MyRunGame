using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Header("発生間隔")]
    private float _Spacing;
    [SerializeField,Header("生成物")]
    private GameObject _Prefab;
    [SerializeField, Header("第二生成物")]
    private GameObject _Prefab2;
    [SerializeField, Header("ストッパー")]
    private GameObject _stopper;

    private GameObject _player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        InvokeRepeating(nameof(SpawnEnemy), 1f, 4f);
        InvokeRepeating(nameof(SpawnEnemy2), 1f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void Spawn(GameObject prefab)
    {
        if (_player == null||_stopper == null) return;
        Instantiate(prefab, new Vector3(_player.transform.position.x + Random.Range(_Spacing,35f), transform.position.y, transform.position.z),Quaternion.identity);
        
    }

    private void Spawn2(GameObject prefab)
    {
        if (_player == null||_stopper ==null) return;
        Instantiate(prefab, new Vector3(_player.transform.position.x + Random.Range(_Spacing, 45f), transform.position.y, transform.position.z), Quaternion.identity);

    }

    private void SpawnEnemy()
    {
        Spawn(_Prefab);

    }
         private void SpawnEnemy2()
    {
        Spawn2(_Prefab2);
    }

}
