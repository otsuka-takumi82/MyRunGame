using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField, Header("大剣Image")]
    private Image _bigImage;
    [SerializeField, Header("クロスボウImage")]
    private Image _crossBowImage;
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
    [SerializeField, Header("キー")]
    private TMP_Text[] _keyNum;
    [SerializeField]
    private GameObject _chuat;
    [SerializeField]
    private GameObject _chuatRun;



    [SerializeField]
    private float _time = 1;
    [SerializeField]
    private float _maxTime = 1;
    [SerializeField]
    private float _time2 = 1;
    [SerializeField]
    private float _time3 = 1;


    private float _dir = 1;
    private float _dir2 = 1;
    private float _dir3 = 1;
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

    public void KeyNum()
    {
        Color c = _keyNum[0].color;
        if(_time >= _maxTime  || _time <= 0)
        {
            _dir *= -1;
        }

        _time += Time.deltaTime * _dir;

        c.a = _time;
        _keyNum[0].color = c;
        
    }

    public void KeyNum1()
    {
        Color c = _keyNum[1].color;
        if (_time2 >= _maxTime || _time <= 0)
        {
            _dir2 *= -1;
        }

        _time2 += Time.deltaTime * _dir2;

        c.a = _time2;
        _keyNum[1].color = c;
    }

    public void KeyNum2()
    {
        Color c = _keyNum[2].color;
        if (_time3 >= _maxTime || _time3 <= 0)
        {
            _dir3 *= -1;
        }

        _time3 += Time.deltaTime * _dir3;

        c.a = _time3;
        _keyNum[2].color = c;
    }

    public void BigSwordImage(float cool, float maxCool)
    {
        _bigImage.gameObject.SetActive(true);
        _bigImage.fillAmount = Mathf.Clamp01(cool / maxCool);
    }
    public void CrossBowImage()
    {
        _crossBowImage.gameObject.SetActive(true);
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

    //public Color BrackFade()
    //{
    //    Color color;
    //   return  color = _fadeImage.color;
    //}

    public void Chuat()
    {
        _chuat.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ChuatButton()
    {
        _chuat.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ChuatRun()
    {
        _chuatRun.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ChuatRunButton()
    {
        _chuatRun.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
