using UnityEngine;

public class PooSpowner : MonoBehaviour
{
    [SerializeField, Header("POO")]
    private GameObject _poo;
    [SerializeField, Header("間隔")]
    private float _pooDis;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpornPoo), 1, _pooDis);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PSpawn(GameObject prefab)
    {
        Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + -2, transform.position.z), Quaternion.identity);
    }

    public void SpornPoo()
    {
        PSpawn(_poo);
    }
}
