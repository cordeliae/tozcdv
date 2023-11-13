using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tescior : MonoBehaviour
{
    private Rigidbody rb;
    public float JumpForce = 5f;
    private int coins;
    public TextMeshProUGUI coinText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.back*0.1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * 0.1f);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.localScale+=Vector3.one;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.localScale-=Vector3.one;
        }
        if (Input.GetKey(KeyCode.C))
        {
            transform.Rotate(new Vector3(0,1,0),Space.Self);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up *JumpForce, ForceMode.Impulse);
        }
        Debug.Log("MONETKI: " + coins);
        coinText.text = "Coin: " + coins.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bigger"))
        {
            transform.localScale = new Vector3(10f, 10f, 10f);
        }
        if (other.gameObject.CompareTag("Smaller"))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if(other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            coins++;
        }
        if(other.gameObject.CompareTag("death"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.gameObject.CompareTag("door") && coins >= 7)
        {
            other.GetComponent<Animator>().SetTrigger("Opening");
        }
       
  

    }
    private void Start()
    {
        Physics.gravity = new Vector3(0, -100, 0);
        CoinManager.coinCounter = 0;
    }
     
 
}
