using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField, Header("HPImage")]
    private Image _imageHP;
    [SerializeField, Header("SniceImage")]
    private Image _sniceImage;
    [SerializeField, Header("UScoreImage")]
    private Image _imageUScore;
    [SerializeField, Header("CanonImage")]
    private Image[] _canonImage;
    [SerializeField, Header("スコア表示")]
    private TMP_Text _scoreText;
    [SerializeField, Header("Underスコア表示")]
    private TMP_Text _uScoreText;
    [SerializeField, Header("Uスコアボタン")]
    private GameObject _kingButton;
    [SerializeField, Header("スピード表示")]
    private TMP_Text _speedText;
    [SerializeField, Header("ボルト本数")]
    private TMP_Text _boltText;

    private bool _isActive = true;
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

    public void CanonImage(int ImageType, float Gage, float MaxGage)
    {
        _canonImage[ImageType].fillAmount = Mathf.Clamp01(Gage / MaxGage);
    }

    public void ScoreManage(float HP)
    {
        _scoreText.text = "Score:" + HP;
    }

    public void UScoreManage(float HP)
    {
        _uScoreText.text = "UScore:" + HP;
    }
    public void UScoreGage(float Gage, float MaxGage)
    {
        _imageUScore.fillAmount = (float)Gage / MaxGage;
        
        if(Gage >= MaxGage)
        {
            if(_isActive)
            {
                _kingButton.SetActive(true);
                _isActive = false;
            }
        }
    }
    public void ScoreColor(Color color)
    {
        _scoreText.color = color;
    }

    public void SpeedText(float speed)
    {
        _speedText.text = "Speed: " + speed.ToString("0.00");
    }
    public void BoltText(int bolt)
    {
        _boltText.text = "Bolt: " + bolt;
    }
}
