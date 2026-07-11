using System.Collections;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    [SerializeField]
    ActivateTiming _timing = ActivateTiming.Get;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Activate()
    {
        Debug.Log("オーバーライドしろ！");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(_timing == ActivateTiming.Get)
            {
                Activate();
                Destroy(gameObject);
            }
            else if(_timing == ActivateTiming.Use)
            {
                transform.position = Camera.main.transform.position;
                GetComponent<Collider2D>().enabled = false;
                collision.gameObject.GetComponent<Player>().GetItem(this);
            }
        }
    }

   

    enum ActivateTiming
    { 
        Get,
        Use,
    
    }

}
