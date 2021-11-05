using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathOnCollision : MonoBehaviour
{
    public bool destroySelf;
    public GameObject Player;
    public GameObject Explosion;
    public Vector3 lastCheckpointPos;

    private void Start()
    {
        lastCheckpointPos = Player.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (destroySelf == true)
        {
            Instantiate(Explosion, collision.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (collision.collider.tag == "Player")
        {
            Instantiate(Explosion, collision.transform.position, Quaternion.identity);
            collision.transform.position = lastCheckpointPos;
            collision.rigidbody.velocity = new Vector3(0f, 0f, 0f);
            FindObjectOfType<AudioManager>().Play("Respawn");
        }
        else
        {
            Instantiate(Explosion, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
