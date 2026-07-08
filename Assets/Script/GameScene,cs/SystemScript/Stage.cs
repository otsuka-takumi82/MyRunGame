using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private GameObject _floor;
    [SerializeField]
    private Transform _pearentTransform;

    private PrefabSetting _prefabSetting;
    private Collider2D _collider2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _prefabSetting = FindAnyObjectByType<PrefabSetting>();
        _collider2D = GetComponent<Collider2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(_floor,new Vector3(transform.position.x + 10,-1.5f - 0.87f,transform.position.z), Quaternion.identity,_pearentTransform);
            
            Destroy(gameObject);
            
        }
    }
}
