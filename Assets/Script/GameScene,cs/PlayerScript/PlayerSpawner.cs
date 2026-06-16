using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject _playerPrefab;
    [SerializeField]
    public int _stageNumber;

    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        if (_stageNumber == _gameManager._boxStage)
        {
            Instantiate(_playerPrefab);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
