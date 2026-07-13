using Unity.VisualScripting;
using UnityEngine;

public class AudioManagar : MonoBehaviour
{
    [SerializeField,UnitHeaderInspectable("オーディオソース")]
    private AudioSource _managarSource;
    [SerializeField, UnitHeaderInspectable("矢")]
    private AudioClip _arrow;
    [SerializeField, UnitHeaderInspectable("鎧")]
    private AudioClip _armored;
    [SerializeField, UnitHeaderInspectable("爆発")]
    private AudioClip _bomb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Arow()
    {
        _managarSource.PlayOneShot(_arrow);
    }

    public void Damage()
    {
        _managarSource.PlayOneShot(_armored);
    }
    public void Bomb()
    {
        _managarSource.PlayOneShot(_bomb);
    }
}
