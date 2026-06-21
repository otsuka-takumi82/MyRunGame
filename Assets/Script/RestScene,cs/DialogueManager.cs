using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField, Header("NPC")]
    private GameObject[] _npc;
    [SerializeField, Header("セリフ")]
    private Text _npc1Coment;
    [SerializeField, Header("ボタン")]
    private GameObject _button;

    private bool _isTolking;
    private GameManager _gameManager;
    public int num = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Start()
    {
        if (_gameManager._boxStage > 5) return;
        _npc[_gameManager._boxStage - 1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Dialog();
    }

    private string[] _message =
    {
        "おはよう",
        "ころそうか",
        "好きだ"
    };

    public void NPC1()
    {
        Destroy(_button.gameObject);

        _isTolking = true;
        
        

        //_npc1Coment.text = _message[num]; 
    }

    public void Dialog()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            num++;
        }

        if (num < _message.Length && _isTolking == true)
        {
            _npc1Coment.gameObject.SetActive(true);
            _npc1Coment.text = _message[num];
            
        }
        else
        {
            _npc1Coment.gameObject.SetActive(false);
        }
    }

}
