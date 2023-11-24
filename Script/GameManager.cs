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
    public int dogruObjeSay�s� = 0;
    
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
        // Ba�lang�� �l�e�i
        Vector3 startScale = resultSprite.transform.localScale;
        // Hedef �l�ek
        Vector3 targetScale = spriteScale;

        float timer = 0.0f;
        float duration = 0.5f; // De�i�im s�resi

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
        dogruObjeSay�s�++;
        puanText.text = puan.ToString();
    }
    public void puanC�kar()
    {
        puan -= 10;
        dogruObjeSay�s�--;
        puanText.text = puan.ToString();
    }

    public IEnumerator trueObject()
    {
        resultSprite.GetComponent<CanvasGroup>().alpha = 1;
        resultSprite.GetComponent<Image>().sprite = sprites[0];

        // Ba�lang�� �l�e�i
        Vector3 startScale = resultSprite.transform.localScale;
        // Hedef �l�ek
        Vector3 targetScale = spriteScale;

        float timer = 0.0f;
        float duration = 0.5f; // De�i�im s�resi

        while (timer < duration)
        {
            resultSprite.transform.localScale = Vector3.Lerp(startScale, targetScale, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        resultSprite.transform.localScale = targetScale;

        yield return new WaitForSeconds(1);

        // �kinci animasyon: K���ltme
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

        // Di�er i�lemler
        resultSprite.GetComponent<CanvasGroup>().alpha = 0;
        Debug.Log("de�i�ti");
        puanEkle();
    }


    public IEnumerator falseObject()
    {
        resultSprite.GetComponent<CanvasGroup>().alpha = 1;
        resultSprite.GetComponent<Image>().sprite = sprites[1];

        // Ba�lang�� �l�e�i
        Vector3 startScale = resultSprite.transform.localScale;
        // Hedef �l�ek
        Vector3 targetScale = spriteScale;

        float timer = 0.0f;
        float duration = 0.5f; // De�i�im s�resi

        while (timer < duration)
        {
            resultSprite.transform.localScale = Vector3.Lerp(startScale, targetScale, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        resultSprite.transform.localScale = targetScale;

        yield return new WaitForSeconds(1);

        // �kinci animasyon: K���ltme
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

        // Di�er i�lemler
        resultSprite.GetComponent<CanvasGroup>().alpha = 0;
        Debug.Log("de�i�ti");
        puanEkle();
    }


    public void ShowPauseMenu()
    {
        Debug.Log("ShowPauseMenu TIKLANDI");
        pauseMenuCanvasGroup.alpha = 1 - pauseMenuCanvasGroup.alpha;

        // E�er gizliyse, interaktifli�i etkinle�tir
        if (pauseMenuCanvasGroup.alpha > 0)
        {
            pauseMenuCanvasGroup.interactable = true;
            pauseMenuCanvasGroup.blocksRaycasts = true;
        }
        else
        {
            // E�er gizli de�ilse, interaktifli�i devre d��� b�rak
            pauseMenuCanvasGroup.interactable = false;
            pauseMenuCanvasGroup.blocksRaycasts = false;
        }
    }
    public void ContinueGame()
    {
        // Oyuna devam etmek i�in yap�lacak i�lemler
        ShowPauseMenu(); // Men�y� kapat
        Debug.Log("Oyuna Devam Et");
    }
    public void ReturnToMainMenu()
    {
        // Ana men�ye d�nmek i�in yap�lacak i�lemler
        ShowPauseMenu(); // Men�y� kapat
        SceneManager.LoadScene("Main Menu");
    }
    public void RestartGame()
    {
        // Ana men�ye d�nmek i�in yap�lacak i�lemler
        ShowPauseMenu(); // Men�y� kapat
        SceneManager.LoadScene("SampleScene");
    }
}

