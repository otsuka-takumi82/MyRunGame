using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField, Header("ランゲーム")]
    private GameObject _runOver;
    [SerializeField, Header("アクションゲーム")]
    private GameObject _actionOver;

    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        if (_gameManager._boxStage < 10)
        {
            _runOver.SetActive(true);
        }
        else
        {
            _actionOver.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
