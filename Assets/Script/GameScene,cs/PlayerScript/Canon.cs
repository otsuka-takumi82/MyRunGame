using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _exprotion;

    
    private Player _player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exprotion(int ExprotionNum)
    {
            Instantiate(_exprotion[ExprotionNum], new Vector2(transform.position.x + 8, transform.position.y - 2), Quaternion.identity);
           
        
    }
}
