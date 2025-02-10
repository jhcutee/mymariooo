using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public CharactorBase Charactor;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Charactor.groundCheck = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Charactor.groundCheck = false;
    }
}
