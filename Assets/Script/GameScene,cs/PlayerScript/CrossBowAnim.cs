using UnityEngine;

public class CrossBowAnim : MonoBehaviour
{
    private Player _player;
    private Animator _anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _anim = GetComponent<Animator>();
        _player = FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("CrossBow", _player._isCrossDirection);
        //_anim.SetBool("Close", !_player._isCrossDirection);
    }
}
