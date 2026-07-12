using Unity.VisualScripting;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField, Header("背景")]
    private GameObject[] _backGround;

    private GameManager _gameManager;
    private Player _player;

    private float _distanse;
    private float num;
    private bool _start = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gameManager = FindFirstObjectByType<GameManager>();
        _player = FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player == null) return;
        if (_gameManager._boxStage < 10)
        {
            RockPosition0();
        }
        else if (_gameManager._boxStage < 13)
        {
            RockPosition1();
        }
        else if( _gameManager._boxStage >= 13)
        {
            RockPosition2();
        }
    }

    public void RockPosition0()
    {
        if (_player == null) return;
        if (_player._onFloor && _start)
        {
            num = _player.transform.position.y;
            _start = false;
        }
        _distanse = num + 4;
        _backGround[0].transform.position = new Vector3(_player.transform.position.x + 10, _distanse + 0.8f, transform.position.z);
    }

    public void RockPosition1()
    {
        if (_player == null) return;
        if (_player._onFloor && _start)
        {
            num = _player.transform.position.y;
            _start = false;
        }
        _distanse = num + 4;
        _backGround[1].transform.position = new Vector3(_player.transform.position.x + 9, _distanse, transform.position.z);
    }

    public void RockPosition2()
    {
        if (_player == null) return;
        if (_player._onFloor && _start)
        {
            num = _player.transform.position.y;
            _start = false;
        }
        _distanse = num + 4;
        _backGround[2].transform.position = new Vector3(_player.transform.position.x + 9, _distanse, transform.position.z);
    }
}
