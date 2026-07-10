using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField, Header("ランゲームNPC")]
    private GameObject[] _npc;
    [SerializeField, Header("テキストボックス")]
    private Text _textBox;
    [SerializeField, Header("ボタン")]
    private GameObject _button;
    [SerializeField, Header("選択肢")]
    private GameObject _ChoisesButton;
    [SerializeField, Header("ピエロエフェクト")]
    private GameObject _pieroEffect;

    private bool _isText = true;
    private bool _isTolking;
    private int _YesNo = 0;
    private GameManager _gameManager;
    private int num = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Start()
    {
        if (_gameManager._boxStage > 4 || _gameManager._boxStage == 3) return;
        _npc[_gameManager._boxStage - 1].SetActive(true);
        _button.gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_isTolking);
        Dialog();
    }

    private string[] _npc1Message =
    {
        "こんばんは",
        "正直に、人は殺したかの？",
        "正直でよろしい。いいこと教えよう。",
        "この先は盗賊が多い。お前さんなら敵じゃあるまい。",
        "やっておしまいよ"
    };

    private string[] _npc1Message2 =
    {
        "",
        "",
        "う、嘘をつけい！",
        "わしは見た！見たんじゃからのう！",
        "マイケルはいいやつじゃった。うう,,,"
    };

    private string[] _npc2Message =
    {
        "こんばんは",
        "盗賊を倒してくれてありがとう",
        "秘密知りたいですか？",
        "宮廷の道化師さんって結構残虐な",
        "性格しているんです",
        "気を付けて"
    };

    private string[] _npc2Message2 =
    {
        "",
        "",
        "",
        "では、また"
    };

    private string[] _npc3Message =
    {
        "こんばんは",
        "君気に入ったよ、ひひっ",
        "君は王が好きかい？？",
        "おっと失礼",
        "お嬢様を忘れてましたよ",
        "ヒヒッ"
    };

    private string[] _npc3Message2 =
    {
        "",
        "",
        "",
        "HAHAHAHAHA",
        "何を大人ぶってるんだい坊や",
        "王様好きになるようなこと教えてアゲル！！",
        "王様は見栄っ張りなんだよね。HAHA",
        "あんなバケモノ食えるわけないのにネ！",
        "内心なくならないかと思っているだろうさ！",
        "みじめだね。ひひっ",
        "覚えとくといいよ。ひひっ",
        "Bye～"
    };

    private string[] _npc4Message =
    {
        "こんばんは!!",
        "かっけーなーこの鎧！",
        "王国の騎士のおっちゃんたちはだせーんだよな",
        "なんでかしりたい？",
        "あのおっちゃんたち、たまに落ちてくるう〇こに",
        "当たってるんだぜーハハッ",
        "あ、もしかしていっちゃまずかった？",
        "じゃ、じゃあおれいくわ",
        "う〇こには気をつけろよ～"
    };

    private string[] _npc4Message2 =
    {
        "",
        "",
        "",
        "",
        "あ、隣のねーちゃん王国の人？",
        "じゃあなんでもない。じゃあな～"
    };

    public void NPC1()
    {
        _button.gameObject.SetActive(false);

        _isTolking = true;
        
        

        //_npc1Coment.text = _message[num]; 
    }

    public void Yes()
    {
        _YesNo = 1;
        num++;
    }
    public void No()
    {
        _YesNo = 2;
        num++;
    }

    public void Dialog()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !_ChoisesButton.gameObject.activeSelf && _textBox.gameObject.activeSelf)
        {
            num++;
        }

        //ステージ１後
        if (_gameManager._boxStage == 1)
        {
            if (_isTolking == true)
            {
                _textBox.gameObject.SetActive(true);
                if (num == 1)
                {
                    _ChoisesButton.gameObject.SetActive(true);

                }
                else
                {
                    _ChoisesButton.gameObject.SetActive(false);
                }
                if (_YesNo <= 1)
                {
                    if(num < _npc1Message.Length)
                    {
                        _textBox.text = _npc1Message[num];
                    }
                    else
                    {
                        _textBox.gameObject.SetActive(false);
                    }
                }
                else if (_YesNo == 2)
                {
                    if (num < _npc1Message2.Length)
                    {
                        _textBox.text = _npc1Message2[num];
                    }
                    else
                    {
                        _textBox.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                _textBox.gameObject.SetActive(false);
                _isTolking = false;

            }
        }
        //ステージ2後
        else if (_gameManager._boxStage == 2)
        {
            if (_isTolking == true)
            {
                _textBox.gameObject.SetActive(true);
                if (num == 2)
                {
                    _ChoisesButton.gameObject.SetActive(true);

                }
                else
                {
                    _ChoisesButton.gameObject.SetActive(false);
                }
                if (_YesNo <= 1)
                {
                    if (num < _npc2Message.Length)
                    {
                        _textBox.text = _npc2Message[num];
                    }
                    else
                    {
                        _textBox.gameObject.SetActive(false);
                    }
                }
                else if (_YesNo == 2)
                {
                    if (num < _npc2Message2.Length)
                    {
                        _textBox.text = _npc2Message2[num];

                    }
                    else
                    {
                        _textBox.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                _textBox.gameObject.SetActive(false);
                _isTolking = false;

            }
        }

        //ステージ3後
        else if (_gameManager._boxStage == 3 && _gameManager._boxScore >= 100)
        {
            _npc[_gameManager._boxStage - 1].SetActive(true);
            _button.gameObject.SetActive(true);
            if (_isTolking == true)
            {
                _button.gameObject.SetActive(false);
                _textBox.gameObject.SetActive(true);
                if (num == 2)
                {
                    _ChoisesButton.gameObject.SetActive(true);

                }
                else
                {
                    _ChoisesButton.gameObject.SetActive(false);
                }
                if (_YesNo <= 1)
                {
                    if (num < _npc3Message.Length)
                    {
                        _textBox.text = _npc3Message[num];
                    }
                    else
                    {
                        EndDialog();
                        if (_isText)
                        {
                            Instantiate(_pieroEffect, _npc[2].transform.position, Quaternion.identity);
                            _isText = false;
                        }
                    }
                }
                else if (_YesNo == 2)
                {
                    if (num < _npc3Message2.Length)
                    {
                        _textBox.text = _npc3Message2[num];

                    }
                    else
                    {
                        EndDialog();
                        if (_isText)
                        {
                            Instantiate(_pieroEffect, _npc[2].transform.position,Quaternion.identity);
                            _isText = false;
                        }
                    }
                }
            }
            else
            {
                _textBox.gameObject.SetActive(false);
                _button.gameObject.SetActive(true);
                

            }
        }

        //ステージ4後
        else if (_gameManager._boxStage == 4)
        {
            if (_isTolking == true)
            {
                _textBox.gameObject.SetActive(true);
                if (num == 3)
                {
                    _ChoisesButton.gameObject.SetActive(true);

                }
                else
                {
                    _ChoisesButton.gameObject.SetActive(false);
                }
                if (_YesNo <= 1)
                {
                    if (num < _npc4Message.Length)
                    {
                        _textBox.text = _npc4Message[num];
                    }
                    else
                    {
                        _textBox.gameObject.SetActive(false);
                    }
                }
                else if (_YesNo == 2)
                {
                    if (num < _npc4Message2.Length)
                    {
                        _textBox.text = _npc4Message2[num];

                    }
                    else
                    {
                        _textBox.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                _textBox.gameObject.SetActive(false);
                _isTolking = false;

            }
        }
    }

    public void EndDialog()
    {
        _textBox.gameObject.SetActive(false);
        _npc[_gameManager._boxStage - 1].SetActive(false);

    }




}
