using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutABox : MonoBehaviour
{
    public GameManager gameManager;
    private string color;
    private RandomObjectSpawner randomObjectSpawner = new RandomObjectSpawner();

    private void Start()
    {
        color = gameObject.GetComponent<MeshRenderer>().materials[0].name.ToString();
        Debug.Log(color);
        randomObjectSpawner = GameObject.Find("spawner").GetComponent<RandomObjectSpawner>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("sekil")) // Eðer istediðimiz obje bu tag'a sahipse
        {
            if (other.GetComponent<MeshRenderer>().materials[0].name.ToString() == color)
            {
                if (gameManager.dogruObjeSayýsý == randomObjectSpawner.randomObjeSaysý - 1)
                {
                    StartCoroutine(gameManager.finish());
                }
                else {

                    StartCoroutine(gameManager.trueObject());
                }
                           
            }
            else {
                StartCoroutine(gameManager.falseObject());
            }         
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("sekil")) // Eðer istediðimiz obje bu tag'a sahipse
        {
            if (other.GetComponent<MeshRenderer>().materials[0].name.ToString() == color)
            {
                gameManager.puanCýkar();
            }            
        }
    }
}
