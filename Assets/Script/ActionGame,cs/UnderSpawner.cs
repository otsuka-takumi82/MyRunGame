using UnityEngine;

public class UnderSpawner : MonoBehaviour
{
    [SerializeField, Header("発生間隔")]
    private float _Spacing;
    [SerializeField, Header("発生時間隔")]
    private float _spacingTime;
    [SerializeField, Header("生成物")]
    private GameObject[] _Prefab;
    //[SerializeField, Header("第二生成物")]
    //private GameObject _Prefab2;
    [SerializeField, Header("ストッパー")]
    private GameObject _stopper;

    private GameObject _player;
    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        _player = GameObject.FindWithTag("Player");
        InvokeRepeating(nameof(SpawnUenemy), 0.5f, _spacingTime);
        //InvokeRepeating(nameof(SpawnEnemy2), 1f, 4f);
        //if (_gameManager._boxStage >= 2 && _gameManager._boxStage < 10) return;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Uspawn(GameObject[] prefab)
    {
        if (_player == null) return;
        for (var i  = 0; i < 7; i += 2)
        {
            Instantiate(prefab[Random.Range(0, prefab.Length)], new Vector3(_player.transform.position.x + _Spacing + i, _player.transform.position.y, _player.transform.position.z), Quaternion.identity);
        }
        


    }

    //private void Spawn2(GameObject prefab)
    //{
    //    if (_player == null || _stopper == null) return;
    //    Instantiate(prefab, new Vector3(_player.transform.position.x + Random.Range(_Spacing, 45f), transform.position.y, transform.position.z), Quaternion.identity);

    //}

    private void SpawnUenemy()
    {
        Uspawn(_Prefab);

    }
    //private void SpawnEnemy2()
    //{
    //    Spawn2(_Prefab2);
    //}

}
