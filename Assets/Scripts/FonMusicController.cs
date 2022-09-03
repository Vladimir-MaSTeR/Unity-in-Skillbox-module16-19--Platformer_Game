using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FonMusicController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;


    private int currentIndexScene;

    private void Start()
    {
        currentIndexScene = SceneManager.GetActiveScene().buildIndex;
        SelectMainScene();
    }


    private void SelectMainScene()
    {
        if (currentIndexScene == 0)
        {
            audioSource.clip = audioClips[0];

        }

        audioSource.Play();
        audioSource.loop = true;
    }


}
