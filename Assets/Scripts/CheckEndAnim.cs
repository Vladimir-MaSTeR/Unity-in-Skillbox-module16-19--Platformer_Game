using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEndAnim : MonoBehaviour
{
    private bool endAmim = false;
    
    private void CheckAnim()
    {


        endAmim = true;
        Debug.Log("��������� ������ �����������");
    }

    public bool GetEndAnim()
    {
        
        return this.endAmim;
    }
}
