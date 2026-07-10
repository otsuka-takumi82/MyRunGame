using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Fade : MonoBehaviour
{
    [SerializeField, Header("フェードImage")]
    public Image _fadeImage;
    [SerializeField]
    private float _fadeTime;

    [SerializeField]
    bool _fadeIn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(_fadeIn)
        {
            _fadeTime = 1;
        }
        else
        {
            _fadeTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!_fadeIn)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(FadeCol());
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(FadeIn());
            }
        }
        
    }

    public IEnumerator FadeCol()
    {
        while (true)
        {
            _fadeTime += Time.deltaTime;
            Color c = _fadeImage.color;
            c.a = _fadeTime / 1;
            _fadeImage.color = c;
            if (_fadeTime > 1)
            {
                SceneManager.LoadScene("RestScene");

                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator FadeIn()
    {
        while (true)
        {
            _fadeTime -= Time.deltaTime;
            Color c = _fadeImage.color;
            c.a = _fadeTime / 1;
            _fadeImage.color = c;
            if (_fadeTime < 0.1)
            {

                yield break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
