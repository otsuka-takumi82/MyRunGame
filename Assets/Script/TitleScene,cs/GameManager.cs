using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public float _boxScore;
    public float _boxSpeed = 5;
    public int _boxStage = 1;
    

    private void Awake()
    {
        if (FindObjectsByType<GameManager>(
    FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }
            DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_boxStage);
    }
}
