using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.GetContact(0).normal.y <= -0.9)
            {
                Debug.Log("Le matamos");
            }
        }
    }
}
