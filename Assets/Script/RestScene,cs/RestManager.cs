using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestManager : MonoBehaviour
{
    [SerializeField]
    public Button _goStageButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoStage()
    {
        SceneManager.LoadScene("2DRunGame");
    }
}
