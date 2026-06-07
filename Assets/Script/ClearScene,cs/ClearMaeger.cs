using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ClearMaeger : MonoBehaviour
{
    [SerializeField,Header("テキスト")]
    private TMP_Text _rankTaxt;
    [SerializeField, Header("テキスト")]
    private TMP_Text _scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "score: " + Player.GameManager._score;

        if(Player.GameManager._score > 100)
        {
            _rankTaxt.color = Color.yellow;
            _rankTaxt.text = "A";
        }

        else if (Player.GameManager._score < 30)
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
