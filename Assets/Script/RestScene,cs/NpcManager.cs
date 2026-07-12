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
    [SerializeField, Header("説明ボックス")]
    private GameObject[] _planBox;
    [SerializeField, Header("NPC画像")]
    private GameObject[] _npcImage;

    public int _indexNum;
    private GameManager _gameManager;
    public bool _crossBow;
    public bool _bigSword;
    public bool _canon;
    private bool _isPlanIng;
    private bool _isTolking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        _isTolking = true;
        _isPlanIng = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_canon);

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
            NPCDialog(_dialog, 0);
            _npcImage[0].SetActive(true);
        }
        else if (GameManagerNum(12))
        {
            NPCDialog(_dialog1, 1);
            _npcImage[1].SetActive(true);
        }
        else if (GameManagerNum(13))
        {
            NPCDialog(_dialog2, 2);
            _npcImage[2].SetActive(true);
        }


    }

    public void NPCDialog(string[] text, int index)
    {
        if(_indexNum < text.Length)
        {
            _tolk.text = text[_indexNum];
            if(_isTolking && _indexNum > 0)
            {
                _textBox.SetActive(true);
                _isTolking = false;
            }
        }
        else
        {
            if(_isPlanIng)
            {
                _textBox.SetActive(false);
                _planBox[index].SetActive(true);
                _isPlanIng = false;
            }
            
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

    public void OnOk(int index)
    {
        _isPlanIng = false;
        _planBox[index].SetActive(false );

    }

    public void OnOK0()
    {
        OnOk(0);
        _canon = true;
        _gameManager._isCanon = _canon;
    }
    public void OnOK1()
    {
        OnOk(1);
        _crossBow = true;
        _gameManager._isCrossBow = _crossBow;
    }
    public void OnOK2()
    {
        OnOk(2);
        _bigSword = true;
        _gameManager._caveOnOff = false;
        _gameManager._isBigSword = _bigSword;
    }



}
