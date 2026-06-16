using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryManager : MonoBehaviour
{
    [SerializeField, Header("リトライボタン")]
    private GameObject _retry;

    [SerializeField, Header("シーン")]
    private string _scene;

    private GameObject _player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckDead();
    }

    public void CheckDead()
    {
        if (_player != null) return;
        _retry.SetActive(true);
           
        
    }

    public void Retry()
    {
        SceneManager.LoadScene(_scene);
    }

    

    
}
