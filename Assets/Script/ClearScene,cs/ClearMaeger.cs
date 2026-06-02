using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ClearMaeger : MonoBehaviour
{
    [SerializeField,Header("テキスト")]
    private TMP_Text _ScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Player.GameManager._score > 100)
        {
            _ScoreText.color = Color.yellow;
        }

        else if (Player.GameManager._score < 30)
        {
            _ScoreText.color = Color.red;
        }

        else
        {
            _ScoreText.color = Color.black;
        }


    }
}
