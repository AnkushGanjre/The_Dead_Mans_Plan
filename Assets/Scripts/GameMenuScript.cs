using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject gameImage;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject backgroundImage;
    [SerializeField] private VideoPlayer videoPlayer1;
    [SerializeField] private GameObject videoBurningEvidence;
    [SerializeField] private GameObject skipButton;
    [SerializeField] private GameObject crossFade;
    [SerializeField] private GameObject blackBG;

    [SerializeField] private Animator animator;

    private void Awake()
    {
        gameImage.SetActive(true);
        playButton.SetActive(true);
        backgroundImage.SetActive(false);
        videoBurningEvidence.SetActive(false);
        skipButton.SetActive(false);
        crossFade.SetActive(false);
        blackBG.SetActive(true);
    }
    private void Start()
    {
        StartCoroutine(CrossFade());
    }
    private IEnumerator CrossFade()
    {
        yield return new WaitForSeconds(1);
        blackBG.SetActive(false);
        crossFade.SetActive(true);
    }
    public void PlayButton()
    {
        Invoke("SkipButton", 26f);
        gameImage.SetActive(false);
        playButton.SetActive(false);
        backgroundImage.SetActive(true);
        videoBurningEvidence.SetActive(true);
        skipButton.SetActive(true);
    }
    public void SkipButton()
    {
        animator.SetTrigger("CrossfadeEnds");
        Invoke("OnNextScene", 2f);
    }
    public void OnNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
