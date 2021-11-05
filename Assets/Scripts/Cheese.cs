using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    private const float interval = 0.03f;
    Animator animator;
    public GameObject explosion;
    public GameObject winMenuUI, winFirstButton;
    public GameObject gameManager;
    public GameObject cameraRig;
    public AudioManager audioManager;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            animator.SetTrigger("CheeseCollect");

            collider.transform.position = this.transform.position;
            collider.attachedRigidbody.velocity = new Vector3(0f, 0f, 0f);
            collider.attachedRigidbody.drag = 100f;

            audioManager.Play("CheeseCollect");

            Destroy(this.GetComponent<BoxCollider>());
            gameManager.SetActive(false);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("CheeseEnd") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= interval)
        {
            winMenuUI.SetActive(true);
            cameraRig.GetComponent<Animator>().enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Instantiate(explosion, transform.position, Quaternion.identity);

            audioManager.Play("WinMusic");
            FindObjectOfType<MenuController>().SelectFirstMenuButton(winFirstButton);
        }
    }
}
