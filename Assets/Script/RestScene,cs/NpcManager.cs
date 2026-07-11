using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NpcManager : MonoBehaviour
{
    [SerializeField, UnitHeaderInspectable("NPCテキスト")]
    private Text _tolk;

    public int _npcNum;
    [SerializeField, Header("会話ログ0")]
    private string[] _dialog;
    [SerializeField, Header("会話ログ1")]
    private string[] _dialog1;
    [SerializeField, Header("会話ログ2")]
    private string[] _dialog2;
    [SerializeField, Header("会話ボックス")]
    private GameObject _textBox;

    public int _indexNum;
    private GameManager _gameManager;
    private bool _crossBow;
    private bool _bigSword;
    private bool _canon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_indexNum);

        if((Input.GetKeyDown(KeyCode.Space) && _tolk.gameObject.activeSelf))
        {
            if(GameManagerNum(11))
            {
                NPCNumSet(_dialog);
            }
            else if(GameManagerNum(12))
            {
                NPCNumSet(_dialog1);
            }
            else if (GameManagerNum(13))
            {
                NPCNumSet(_dialog2);
            }

        }
        
        if(GameManagerNum(11))
        {
            NPCDialog(_dialog);
        }
        else if (GameManagerNum(12))
        {
            NPCDialog(_dialog1);
        }
        else if (GameManagerNum(13))
        {
            NPCDialog(_dialog2);
        }


    }

    public void NPCDialog(string[] text)
    {
        if(_indexNum < text.Length)
        {
            _tolk.text = text[_indexNum];
        }
        else
        {
            _textBox.SetActive(false);
        }
        
    }

    public void NPCNumSet(string[] diamess)
    {
        if (_indexNum <= diamess.Length)
        {
            _indexNum++;
        }
           
    }

    public void NPCPlass()
    {
        _npcNum++;
    }

    public void NPC0()
    {
        NPCNumSet(_dialog);
    }

    public bool GameManagerNum(int num)
    {
        return _gameManager._boxStage == num;
    }



}
