using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float xPos = 2.5f;
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float hitXPos = 1f;
    [SerializeField] private float slowerSpeed = 0.25f;
    [SerializeField] private AudioSource hitSFX;
    public GameObject badEndCutscene;
    public bool canShift = false;

    private float currentSpeed;

    [SerializeField] private Camera cam;
    [SerializeField] private float shakeStrength = 0.75f, maxShakeDuration = 0.3f;
    private bool shake = false, dragBack = false;
    private float shakeTime = 0f;

    private Vector2 mousePos;
    private Vector2 gunToMouse;
    private Rigidbody2D rb;
    private CannonFire playerScript;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerScript = GetComponent<CannonFire>();
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Vector2
        gunToMouse = mousePos - (Vector2)transform.position; //Vector2
        updateRotate();
        updatePosition();
        updateShake();
        shiftKeyDetect();

        if(transform.position.x < -5f)
        {
            gameOver();
        }

        if (dragBack)
        {
            xPos -= 0.05f;
        }
    }

    private void updatePosition() {
        float yMousePos = Mathf.Abs(mousePos.y) <= 4.5f ? mousePos.y : 4.5f * Mathf.Sign(mousePos.y);
        Vector2 targetPos = new Vector2(xPos, yMousePos);
        transform.position = Vector2.Lerp(transform.position, targetPos, Time.deltaTime * currentSpeed);
    }
        private void updateRotate()
    {

        float radAngle_gunToMouse = Mathf.Atan2(gunToMouse.y, gunToMouse.x);
        float degAngle_gunToMouse = (180 / Mathf.PI) * radAngle_gunToMouse;

        Quaternion rotation1 = Quaternion.Euler(0f,0f,transform.rotation.eulerAngles.z);
        Quaternion rotation2;

        if (Mathf.Abs(degAngle_gunToMouse) <= 5f)
        {
            rotation2 = Quaternion.Euler(0f, 0f, degAngle_gunToMouse - 90);
        }else if (degAngle_gunToMouse > 5f)
        {
            rotation2  = Quaternion.Euler(0f, 0f, -85f);
        }
        else
        {
            rotation2 = Quaternion.Euler(0f, 0f, -95f);
        }
        transform.rotation = Quaternion.Lerp(rotation1, rotation2, 0.125f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            hitSFX.Play();
            shake = true;
            xPos -= hitXPos; //Ship gets hit and moves backwards (Closer to Flying Dutchman!)
        }
        if (collision.gameObject.CompareTag("tentacle"))
        {
            hitSFX.Play();
            shake = true;
            dragBack = true;
            currentSpeed = slowerSpeed; //Ship gets hit and go slower
            xPos -= 1f;
        }
        if (collision.gameObject.CompareTag("dutchman"))
        {
            gameOver();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tentacle"))
        {
            dragBack = false;
            currentSpeed = speed;
        }
    }

    private void updateShake()
    {
        if (shake)
        {
            cameraShake();
            shakeTime += Time.deltaTime;
            if(shakeTime >= maxShakeDuration)
            {
                shake = false;
                cameraShake();
                shakeTime = 0f;
            }
        }
        else
        {
            return;
        }
    }

    private void cameraShake()
    {
        if (shake)
        {
            float randomX = Random.value - 0.5f;
            float randomY = Random.value - 0.5f;

            cam.transform.localEulerAngles = new Vector3(randomX, randomY, 0) * shakeStrength;
        }
        else if (!shake)
        {
            cam.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

    }
    private void shiftKeyDetect()
    {
        if (Input.GetKey(KeyCode.LeftShift) && canShift)
        {
            currentSpeed = speed + 0.5f;
            xPos += 0.05f;
        }
        else
        {
            currentSpeed = speed;
        }
    }

    private void gameOver()
    {
        badEndCutscene.SetActive(true);
    }

    public void enableScript()
    {
        playerScript.enabled = true;
    }

    public void disableScript()
    {
        playerScript.enabled = false;
    }

    public void cutsceneSpeedUp()
    {
        xPos += 13f;
    }
}
