using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    public float timeLerp = 4f;
    private void OnMouseUp()
    {
        // Sürükleme bitti
        isDragging = false;
        this.GetComponent<Rigidbody>().isKinematic = false;
        transform.SetParent(GameObject.Find("spawner").transform);
    }

    private void OnMouseDown()
    {
        // Dokunulan objeyi al
        isDragging = true;
        this.GetComponent<Rigidbody>().isKinematic = true;

    }

    private void OnMouseDrag()
    {
        // Objeyi sürükle
        Vector3 touch = Input.mousePosition;
        if (isDragging)
        {
            transform.SetParent(GameObject.Find("transformObject").transform);          
            Vector3 newPosition =
                Camera.main.ScreenToWorldPoint(new Vector3(touch.x, touch.y, 1f)) ;
            transform.position = Vector3.Lerp(transform.position, newPosition, timeLerp * Time.deltaTime);    
        }
    } 
}

