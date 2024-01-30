using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private Transform leftLimit;
    [SerializeField]
    private Transform rightLimit;

    private bool moveLeft = true;

    private void Update()
    {
        if (this.transform.position.x <= this.leftLimit.position.x)
            moveLeft = false;

        if (this.transform.position.x >= this.rightLimit.position.x)
            moveLeft = true;

        if (moveLeft)
            this.transform.position = new Vector3(this.transform.position.x - (1 * Time.deltaTime), this.transform.position.y, this.transform.position.z);
        else
            this.transform.position = new Vector3(this.transform.position.x + (1 * Time.deltaTime), this.transform.position.y, this.transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        }
    }
}
