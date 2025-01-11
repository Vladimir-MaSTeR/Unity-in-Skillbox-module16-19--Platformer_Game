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
            // buttonText.text = "������ ����";
            Debug.Log($"���� ���� - �������");
            if(dialogTextRu.Length != 0) {
                currentDialogText = dialogTextRu[0];
            }
        } else if(Language.English == language) {
            Debug.Log($"���� ���� - ����������");
            if(dialogTextEng.Length != 0) {
                currentDialogText = dialogTextEng[0];
            }
        } else if(Language.Turkish == language) {
            Debug.Log($"���� ���� - ��������");
        } else if(Language.German == language) {
            Debug.Log($"���� ���� - ��������");
        } else if(Language.Spanish == language) {
            Debug.Log($"���� ���� - ���������");
        }
    }


    public string getCurrentDialogText() {
        return currentDialogText;
    }

}
