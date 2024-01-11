using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject platform;
    private GameObject myPlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("platform"))
        {
            myPlatform = (GameObject)Instantiate(platform, new Vector2(Random.Range(-2.5f, 2.5f), player.transform.position.y + (14 + Random.Range(0.5f, 1f))), Quaternion.identity);
 
            Destroy(collision.gameObject);
        }
    }
}
