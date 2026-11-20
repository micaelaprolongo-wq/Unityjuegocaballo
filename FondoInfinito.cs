using UnityEngine;

public class FondoInfinito : MonoBehaviour
{
    public float velocidad = 5f;
    private float anchoSprite;

    void Start()
    {
        
        anchoSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);

       
        if (transform.position.x <= -anchoSprite)
        {
            transform.position += new Vector3(anchoSprite * 3f, 0f, 0f);
        }
    }
}