using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private Transform ball;
    private GameManager gameManager;
    public GameObject[] childRings;
    float radius = 15f;
    float force = 150f;
    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }
    void Update()
    {
        if (transform.position.y > ball.position.y) //3y assagi inince 
        {
            GameManager.outLevelIndex++;
            for (int i = 0; i < childRings.Length; i++)
            {

                childRings[i].GetComponent<Rigidbody>().isKinematic = false;
                childRings[i].GetComponent<Rigidbody>().useGravity = true;
                //childRings[i].GetComponent<MeshCollider>().isTrigger = true;

                Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

                foreach (Collider newCollider in colliders)
                {
                    Rigidbody rb = newCollider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(force, transform.position, radius);
                        //Debug.Log(force);
                    }
                }
                childRings[i].GetComponent<MeshCollider>().enabled = false;
                childRings[i].transform.parent = null;
                Destroy(childRings[i].gameObject, 2f);
                Destroy(this.gameObject, 5f);
            }
            this.enabled = false;
            gameManager.IncreaseScore(5);
        }
    }
}
