using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button sceneChangeButton;
    void Start()
    {
         sceneChangeButton=this.GetComponent<Button>();
         sceneChangeButton.onClick.AddListener(LoadTargetScene);

    }
    void LoadTargetScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                LoadTargetScene();
            }
        }
    }
}
