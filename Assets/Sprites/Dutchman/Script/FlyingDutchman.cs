using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDutchman : MonoBehaviour
{
    [SerializeField] private GameObject ironClad;
    [SerializeField] private float xPos = -14f;
    [SerializeField] private float chaseSpeed = 0.5f;
    void Start()
    {
        transform.position = new Vector3(xPos, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        shipFollow();
    }

    private void shipFollow() //Follow player's steamship vertically
    {
        Vector2 targetPos = new Vector2(xPos, ironClad.transform.position.y);
        transform.position = Vector2.Lerp(transform.position, targetPos,Time.deltaTime * chaseSpeed);
    }

    public void setNewXPosCutscene2() //Flying Dutchman pops up for cutscene
    {
        xPos = -5.7f;
    }

    public void setNewXPosStartChase() { //When chase sequence starts, Flying Dutchman goes back a bit to the edge of the left screen
        xPos = -8.5f;
    }

    public void setNewXPosFinal()
    {
        xPos = -14f;
    }
}
