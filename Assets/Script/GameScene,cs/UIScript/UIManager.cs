using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField, Header("HPImage")]
    private Image _imageHP;
    [SerializeField, Header("SniceImage")]
    private Image _sniceImage;
    [SerializeField, Header("スコア表示")]
    private TMP_Text _scoreText;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HPManage(float HP,float MaxHP)
    { 
        _imageHP.fillAmount = (float)HP / MaxHP;
    }

    public void SniceManage(float Snice, float MaxSnice)
    {
        
        _sniceImage.fillAmount = Mathf.Clamp01(Snice / MaxSnice);
    }

    public void ScoreManage(float HP)
    {
        _scoreText.text = "Score:" + HP;
    }
    public void ScoreColor(Color color)
    {
        _scoreText.color = color;
    }
}
