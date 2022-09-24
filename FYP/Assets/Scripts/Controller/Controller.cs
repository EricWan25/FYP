using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public SoundManager soundManager;

    [Header("Camera")]
    public Transform camAxis_Central;
    public Transform cam;
    public float distance = 4.5f;
    public float camSpeed;
    public bool canCamMove;
    float mouseX;
    float mouseY;
    float wheel;

    [Header("Player")]
    public Transform playerAxis;
    public Transform player;
    public float playerSpeed;
    public Vector3 movement;
    public int atkDamage;
    public int heal;
    public int playerDef;
    public Slider playerHPSlider;
    public bool enableToMove;
    public bool canAttack;

    [Header("Enemy")]
    public int thisLvlEnemyDamage;
    public Slider thisLvlEnemyHP;

    void Start()
    {
        canCamMove = true;
        enableToMove = true;
        canAttack = true;

        wheel = -2;
        mouseY = 4;

        playerSpeed = 3.5f;
        atkDamage = 20;
        heal = 0;
        playerDef = 0;
    }

    void Update()
    {
        CamMove();
        Zoom();
        StopClipping();

        if (enableToMove == true)
        {
            PlayerMove();
        }
    }

    void CamMove()
    {
        if (canCamMove == true)
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y") * -1;

            if (mouseY > 10)
                mouseY = 10;
            if (mouseY < -0.5)
                mouseY = -0.5f;

            camAxis_Central.rotation = Quaternion.Euler(new Vector3(
                camAxis_Central.rotation.x + mouseY,
                camAxis_Central.rotation.y + mouseX, 0) * camSpeed);
        }
    }

    void Zoom()
    {
        if (canCamMove == true)
        {
            wheel += Input.GetAxis("Mouse ScrollWheel") * 10;

            if (wheel >= -2)
                wheel = -2;
            if (wheel <= -5)
                wheel = -5;

            cam.localPosition = new Vector3(0, 0, wheel);   
        }
    }

    void PlayerMove()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (movement != Vector3.zero)
        {
            playerAxis.rotation = Quaternion.Euler(new Vector3(
                0, camAxis_Central.rotation.y + mouseX, 0) * camSpeed);

            playerAxis.Translate(movement * Time.deltaTime * playerSpeed);

            player.localRotation = Quaternion.Slerp(player.localRotation,
                Quaternion.LookRotation(movement), 5 * Time.deltaTime);

            player.GetComponent<Animator>().SetBool("isWalking", true);

            soundManager.sfxList[0].Play();
        }
        if (movement == Vector3.zero)
        {
            player.GetComponent<Animator>().SetBool("isWalking", false);
        }

        camAxis_Central.position = new Vector3(player.position.x, player.position.y + 1, player.position.z);
    }

    public void StopClipping()
    {
        RaycastHit hit;
        if (Physics.Linecast(player.position + Vector3.up, cam.position, out hit))
        {
            string name = hit.collider.gameObject.tag;
            if (name != "MainCamera")
            {
                float currentDistance = Vector3.Distance(hit.point, player.position);
                if (currentDistance < distance)
                {
                    cam.position = hit.point;
                }
            }

        }
    }
}
