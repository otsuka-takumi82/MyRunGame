using Unity.VisualScripting;
using UnityEngine;

public class TitleSetting : MonoBehaviour
{
    [SerializeField, Header("ゲーム内容")]
    private GameObject _game;
    [SerializeField, Header("タイトル画面")]
    private GameObject _title;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_game = FindAnyObjectByType<Player> ().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Born()
    {
        _game.SetActive(true);
        _title.SetActive(false);
    }
}
