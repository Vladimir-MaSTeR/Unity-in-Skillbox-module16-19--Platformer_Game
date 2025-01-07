using UnityEngine;
public class ClickButtons : MonoBehaviour {

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    public void Click() {
        audioSource.PlayOneShot(clip);
    }
}
