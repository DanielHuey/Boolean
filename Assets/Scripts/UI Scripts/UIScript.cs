using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIScript : MonoBehaviour {
    AudioSource fx;
    public AudioClip Hover;
    public AudioClip Select;
    public AudioClip Quit;
    public GameObject confirmQuit;
    Animator fadeIt;
    public GameObject fadePanel;
	public RectTransform rect;
    
    void Start() {
        fx = FindObjectOfType<AudioSource>();
        fadeIt = fadePanel.GetComponent<Animator>();
		rect = fadePanel.GetComponent<RectTransform>();
    }
    public void FaderInactive() 
    {
		rect.offsetMax = new Vector2(360f, -1000f);
		fadeIt.ResetTrigger("transluscent");
		fadeIt.SetTrigger("normal");
    }
    public void FaderActive() 
    {
		rect.offsetMax = new Vector2(360f,0);
		fadeIt.ResetTrigger("normal");
		fadeIt.SetTrigger("transluscent");
    }
	void PlayAudio (AudioClip clip) {
        fx.PlayOneShot(clip);
	}
    public void QuitPressed()
    {
        FaderActive();
        confirmQuit.SetActive(true);
        PlayAudio(Quit);
    }
    public void ConfirmPressed() {
        Application.Quit();
    }

	public void Hovered () {
        PlayAudio(Hover);
	}
    public void Selected() {
        PlayAudio(Select);
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Menu");
    }
}
