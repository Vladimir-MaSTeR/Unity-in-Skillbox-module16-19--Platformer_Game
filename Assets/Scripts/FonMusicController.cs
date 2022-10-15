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
        else if (currentIndexScene == 2)
        {
            audioSource.clip = audioClips[2];

        } else if (currentIndexScene == 3)
        {
            audioSource.clip = audioClips[3];

        } else
        {
            audioSource.clip = audioClips[1];
        }

        audioSource.Play();
        audioSource.loop = true;
    }


}
