using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpBall : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rb;
    public float jumpForce;
    public GameObject splashImage;
    private GameManager gameManager;
    public GameObject gameOver;
    public ParticleSystem particle;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>(); //unutmaaaa
        this.gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = new Vector3(0, jumpForce, 0);

        if (collision.gameObject.CompareTag("Breakable"))
        {
            Instantiate(particle.gameObject, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
            GameManager.gameOver = true;
            this.gameObject.SetActive(false);
        }

        else if (collision.gameObject.CompareTag("Platform"))
        {
            GameObject splash = Instantiate(splashImage, transform.position + new Vector3(0f, -0.6f, 0f), Quaternion.Euler(90, 0, 0));
            splash.transform.SetParent(collision.gameObject.transform);
        }

        /*if (collision.gameObject.CompareTag("GameOver"))
        {
            GameManager.gameOver = true;
        }*/
        if (collision.gameObject.CompareTag("Win"))
        {
            GameManager.win = true;
        }

















        /*
         GameObject splash = Instantiate(splashImage, transform.position + new Vector3(0f, -0.2f, 0f), Quaternion.Euler(90, 0, 0));
         splash.transform.SetParent(collision.gameObject.transform);

         string materialNme = collision.gameObject.GetComponent<MeshRenderer>().material.name;
         Debug.LogWarning(materialNme);

         if (materialNme == "Platform 1 (Instance)")
         {
             Instantiate(particles, transform.position + new Vector3(0f, -0.2f, 0f), Quaternion.Euler(90, 0, 0)).transform.SetParent(collision.gameObject.transform);
         }
         else if (materialNme == "Danger (Instance)")
         {

         }
         else if (materialNme == "Win (Instance)")
         {

         }
        */

    }

}
