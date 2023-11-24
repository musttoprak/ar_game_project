using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

public class GameManager : MonoBehaviour
{
    public CanvasGroup pauseMenuCanvasGroup;
    public List<Sprite> sprites;
    public GameObject resultSprite; 
    public TextMeshProUGUI puanText;
    public Vector3 spriteScale = new Vector3(2.5f, 2.5f, 2.5f);
    int puan = 0;
    public int dogruObjeSayýsý = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        puanText.text = puan.ToString();
        pauseMenuCanvasGroup.alpha = 1;
    }

    public IEnumerator finish() {
        resultSprite.GetComponent<CanvasGroup>().alpha = 1;
        resultSprite.GetComponent<Image>().sprite = sprites[2];
        puanEkle();
        // Baþlangýç ölçeði
        Vector3 startScale = resultSprite.transform.localScale;
        // Hedef ölçek
        Vector3 targetScale = spriteScale;

        float timer = 0.0f;
        float duration = 0.5f; // Deðiþim süresi

        while (timer < duration)
        {
            resultSprite.transform.localScale = Vector3.Lerp(startScale, targetScale, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        resultSprite.transform.localScale = targetScale;

        yield return new WaitForSeconds(1);
        

    }

    public void puanEkle() {
        puan += 10;
        dogruObjeSayýsý++;
        puanText.text = puan.ToString();
    }
    public void puanCýkar()
    {
        puan -= 10;
        dogruObjeSayýsý--;
        puanText.text = puan.ToString();
    }

    public IEnumerator trueObject()
    {
        resultSprite.GetComponent<CanvasGroup>().alpha = 1;
        resultSprite.GetComponent<Image>().sprite = sprites[0];

        // Baþlangýç ölçeði
        Vector3 startScale = resultSprite.transform.localScale;
        // Hedef ölçek
        Vector3 targetScale = spriteScale;

        float timer = 0.0f;
        float duration = 0.5f; // Deðiþim süresi

        while (timer < duration)
        {
            resultSprite.transform.localScale = Vector3.Lerp(startScale, targetScale, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        resultSprite.transform.localScale = targetScale;

        yield return new WaitForSeconds(1);

        // Ýkinci animasyon: Küçültme
        startScale = targetScale;
        targetScale = Vector3.zero;
        timer = 0.0f;

        while (timer < duration)
        {
            resultSprite.transform.localScale = Vector3.Lerp(startScale, targetScale, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        resultSprite.transform.localScale = targetScale;

        // Diðer iþlemler
        resultSprite.GetComponent<CanvasGroup>().alpha = 0;
        Debug.Log("deðiþti");
        puanEkle();
    }


    public IEnumerator falseObject()
    {
        resultSprite.GetComponent<CanvasGroup>().alpha = 1;
        resultSprite.GetComponent<Image>().sprite = sprites[1];

        // Baþlangýç ölçeði
        Vector3 startScale = resultSprite.transform.localScale;
        // Hedef ölçek
        Vector3 targetScale = spriteScale;

        float timer = 0.0f;
        float duration = 0.5f; // Deðiþim süresi

        while (timer < duration)
        {
            resultSprite.transform.localScale = Vector3.Lerp(startScale, targetScale, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        resultSprite.transform.localScale = targetScale;

        yield return new WaitForSeconds(1);

        // Ýkinci animasyon: Küçültme
        startScale = targetScale;
        targetScale = Vector3.zero;
        timer = 0.0f;

        while (timer < duration)
        {
            resultSprite.transform.localScale = Vector3.Lerp(startScale, targetScale, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        resultSprite.transform.localScale = targetScale;

        // Diðer iþlemler
        resultSprite.GetComponent<CanvasGroup>().alpha = 0;
        Debug.Log("deðiþti");
        puanEkle();
    }


    public void ShowPauseMenu()
    {
        Debug.Log("ShowPauseMenu TIKLANDI");
        pauseMenuCanvasGroup.alpha = 1 - pauseMenuCanvasGroup.alpha;

        // Eðer gizliyse, interaktifliði etkinleþtir
        if (pauseMenuCanvasGroup.alpha > 0)
        {
            pauseMenuCanvasGroup.interactable = true;
            pauseMenuCanvasGroup.blocksRaycasts = true;
        }
        else
        {
            // Eðer gizli deðilse, interaktifliði devre dýþý býrak
            pauseMenuCanvasGroup.interactable = false;
            pauseMenuCanvasGroup.blocksRaycasts = false;
        }
    }
    public void ContinueGame()
    {
        // Oyuna devam etmek için yapýlacak iþlemler
        ShowPauseMenu(); // Menüyü kapat
        Debug.Log("Oyuna Devam Et");
    }
    public void ReturnToMainMenu()
    {
        // Ana menüye dönmek için yapýlacak iþlemler
        ShowPauseMenu(); // Menüyü kapat
        SceneManager.LoadScene("Main Menu");
    }
    public void RestartGame()
    {
        // Ana menüye dönmek için yapýlacak iþlemler
        ShowPauseMenu(); // Menüyü kapat
        SceneManager.LoadScene("SampleScene");
    }
}

