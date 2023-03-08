using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    public GameManager gm;
    public NavMeshAgent nma;
    public GameObject ammoPill;
    public GameObject ShootPoint;
    public TMP_Text scoreText;
    public GameObject SpawnPoint;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        nma = gameObject.GetComponent<NavMeshAgent>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayStartPos = transform.position;
        rayStartPos.y = rayStartPos.y + 1.5f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject pill = Instantiate(ammoPill, ShootPoint.transform.position, Quaternion.identity);
            Rigidbody rb = pill.GetComponent<Rigidbody>();
            rb.AddForce((ShootPoint.transform.forward * 2000));

            Destroy(pill, 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameObject.transform.position = SpawnPoint.transform.position;
            gameObject.transform.rotation = SpawnPoint.transform.rotation;
        }

        if (other.CompareTag("Wood"))
        {
            Destroy(other.gameObject);
            score = score + 1;
            scoreText.text = "Collected Wood: " + score.ToString();
        }
        
    }

    

}
