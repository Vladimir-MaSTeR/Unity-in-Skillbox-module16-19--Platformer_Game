using System;
using UnityEngine;
public class CheckEndAnim : MonoBehaviour {
    private bool endAmim = false;

    public static Action enemyDeath;

    private void CheckAnim() {
        endAmim = true;
        Debug.Log("��������� ������ �����������");
        enemyDeath?.Invoke();
    }

    public bool GetEndAnim() {

        return this.endAmim;
    }
}
