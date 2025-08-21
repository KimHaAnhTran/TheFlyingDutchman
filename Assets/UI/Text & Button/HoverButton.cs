using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hovering");
        anim.SetBool("hover", true);
        //throw new System.NotImplementedException();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Unhovering");
        anim.SetBool("hover", false);
        //throw new System.NotImplementedException();
    }

}
