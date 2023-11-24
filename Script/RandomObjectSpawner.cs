using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] myObjects;
    public Material[] colors;
    public int randomObjeSaysý = 20;
    private void Start()
    {
        for (int i = 0; i < randomObjeSaysý; i++)
        {
            int randomObjectIndex = Random.Range(0, myObjects.Length);
            int randomColorIndex = Random.Range(0, colors.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.RandomRange(-2, 4), -1, Random.RandomRange(-3, 6));
            Quaternion quaternion = new Quaternion();
            quaternion.x = Random.Range(1, 360);
            quaternion.y = Random.Range(1, 360);
            quaternion.z = Random.Range(1, 360);
      
           var gameObject =  Instantiate(myObjects[randomObjectIndex], randomSpawnPosition, quaternion);
           gameObject.transform.SetParent(this.transform);
           gameObject.GetComponent<MeshRenderer>().material = colors[randomColorIndex];
        }
        
    }

}
