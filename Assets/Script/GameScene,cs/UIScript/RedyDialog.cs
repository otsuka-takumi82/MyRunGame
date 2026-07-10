using UnityEngine;
using UnityEngine.UI;

public class RedyDialog : MonoBehaviour
{
    [SerializeField]
    private Text _diaText;

    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private string[] _redyLog =
    {
        "見張ってるぞ。危害を加えたら、わかっているな？",
        "私はお前を信用していない。だから容赦はしない。いいな？",
        "な、なんだ、真っ暗で何も見えない",
        "ここまできたか...少しはお前のこと、信じていいのかもな。",
        "お前のことだ。ここでへまするような奴じゃないだろう。"
        
    };

    private string[] _redyCollisionLog =
    {
        "見張ってるぞ。危害を加えたら、わかっているな？",
        "あの鐘には気をつけろ。牛車を呼ぶ鐘だ。今の貴様には必要ないだろう。押すなよ？",
        "宮廷の道化師殿？なぜここに？...",
        "ここは人が多い。大事な命だが、鳥くらいなら王も怒らないだろう",
        "シャンデリアは乗っても壊れないから！王の食事だけは邪魔するな！。"

    };

    public void Dialog(int num)
    {
        _diaText.text = _redyLog[num];
    }

    public void DiaCollisionlog(int num)
    {
        _diaText.text = _redyCollisionLog[num];
    }
}
