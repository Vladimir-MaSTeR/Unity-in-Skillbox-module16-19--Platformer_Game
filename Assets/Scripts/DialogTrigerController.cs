using GamePush;
using UnityEngine;
using UnityEngine.Serialization;
public class DialogTrigerController : MonoBehaviour {
    [FormerlySerializedAs("dialogText")]
    [SerializeField] private string[] dialogTextRu;
    [SerializeField] private string[] dialogTextEng;

    private Language language;
    private string currentDialogText;

    private void Start() {
        // if(dialogTextRu.Length != 0) {
        //     currentDialogText = dialogTextRu[0];
        // }
        
        if(Language.Russian == language) {
            // buttonText.text = "начать игру";
            Debug.Log($"язык игры - –усский");
            if(dialogTextRu.Length != 0) {
                currentDialogText = dialogTextRu[0];
            }
        } else if(Language.English == language) {
            Debug.Log($"язык игры - јнглийский");
            if(dialogTextEng.Length != 0) {
                currentDialogText = dialogTextEng[0];
            }
        } else if(Language.Turkish == language) {
            Debug.Log($"язык игры - “урецкий");
        } else if(Language.German == language) {
            Debug.Log($"язык игры - Ќемецкий");
        } else if(Language.Spanish == language) {
            Debug.Log($"язык игры - »спанский");
        }
    }


    public string getCurrentDialogText() {
        return currentDialogText;
    }

}
