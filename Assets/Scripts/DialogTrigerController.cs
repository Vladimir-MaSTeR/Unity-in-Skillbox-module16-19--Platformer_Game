using UnityEngine;
public class DialogTrigerController : MonoBehaviour {
    [SerializeField] private string[] dialogText;

    private string currentDialogText;

    private void Start() {
        if(dialogText.Length != 0) {
            currentDialogText = dialogText[0];
        }
    }


    public string getCurrentDialogText() {
        return currentDialogText;
    }

}
