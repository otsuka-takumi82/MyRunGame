using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestManager : MonoBehaviour
{
    [SerializeField]
    public Button _goStageButton;
    [SerializeField]
    public GameObject _runRest;
    [SerializeField]
    public GameObject _actionRest;

    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        if (_gameManager._boxStage < 10)
        {
            _runRest.SetActive(true);
        }
        else
        {
            _actionRest.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoStage()
    {
        if(_gameManager._boxStage < 13)
        {
            _gameManager._boxStage += 1;
        }
        
        if (_gameManager._boxStage < 10)
        {
            SceneManager.LoadScene("2DRunGame");
        }
        else
        {
            SceneManager.LoadScene("2DActionGame");
        }
    }
}
