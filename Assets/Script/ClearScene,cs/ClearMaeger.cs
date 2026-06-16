using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ClearMaeger : MonoBehaviour
{
    [SerializeField,Header("テキスト")]
    private TMP_Text _rankTaxt;
    [SerializeField, Header("テキスト")]
    private TMP_Text _scoreText;

    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "score: " + _gameManager._boxScore;

        if(_gameManager._boxScore > 100)
        {
            _rankTaxt.color = Color.yellow;
            _rankTaxt.text = "A";
        }

        else if (_gameManager._boxScore < 30)
        {
            _rankTaxt.color = Color.red;
            _rankTaxt.text = "C";
        }

        else
        {
            _rankTaxt.color = Color.black;
            _rankTaxt.text = "B";
        }

       




    }
}
