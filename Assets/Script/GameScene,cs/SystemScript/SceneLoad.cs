using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{

    private Player _player;
    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = FindFirstObjectByType<Player>();
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearLoad()
    {
        _player._isSceneChanging = true;
        SceneManager.LoadScene("ClearScene");
    }

    public void TitleLoad()
    {
        _gameManager._boxSpeed = 5;
        _gameManager._boxScore = 100;
        _gameManager._boxStage = 1;
        SceneManager.LoadScene("Title");
    }
}
