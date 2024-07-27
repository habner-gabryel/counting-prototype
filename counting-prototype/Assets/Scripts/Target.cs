using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float maxTorq = 4;
    private float yRange = 20;
    private float zSpawn = 25;
    private float verticalForce = 5F;
    private float horizontalForce = 10F;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);
        transform.position = getPosition();

        if(transform.position.z == zSpawn){
            targetRb.AddForce(ForceRight(), ForceMode.Impulse);
        } else {
            targetRb.AddForce(ForceLeft(), ForceMode.Impulse);
        }
    }
    
    Vector3 ForceLeft(){
        return new Vector3(0, verticalForce, horizontalForce);
    }

    Vector3 ForceRight(){
        return new Vector3(0, verticalForce, -horizontalForce);
    }

    float RandomTorque(){
        return Random.Range(-maxTorq, maxTorq);
    }

    Vector3 getPosition(){

    int randPos = Random.Range(0, 2);

        if(randPos == 0){
            return new Vector3(0F, Random.Range(6, yRange), -zSpawn);
        } else {
            return new Vector3(0F, Random.Range(6, yRange), zSpawn);
        }
    }

    public void IncreaseSpeed(float addSpeed){
        horizontalForce += addSpeed;
        verticalForce += addSpeed;
    }
}
