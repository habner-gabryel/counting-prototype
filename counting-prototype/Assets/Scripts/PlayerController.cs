using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public GameManager gameManager;
    public float horizontalInput;
    private float speed = 15F;
    private float zRange = 25F;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0 && gameManager.isGameActive){
            if(transform.position.z >= zRange && horizontalInput > 0){
                transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
            } else if(transform.position.z <= -zRange && horizontalInput < 0){
                transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
            } else {
                transform.Translate(Vector3.forward * speed * horizontalInput * Time.deltaTime);
            }
        }
    }
}
