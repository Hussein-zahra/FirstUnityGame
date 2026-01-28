using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carr : MonoBehaviour
{
    // ===== References =====
    public PrometeoCarController pCarController; // سكربت السيارة
    public GameObject carCam;                   // كاميرا السيارة
    public Transform carSeat;                   // مكان جلوس اللاعب داخل السيارة

    private Transform player;
    private GameObject playerObj;

    public AudioSource carEngine;
    public AudioSource openCloseDoor;

    private bool isInCar = false;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.transform;

        // إيقاف السيارة بالبداية
        pCarController.enabled = false;
        carCam.SetActive(false);

        if (carEngine != null)
            carEngine.Stop();
    }

    void Update()
    {
        // زر الدخول أو الخروج
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isInCar)
            {
                TryEnterCar();
            }
            else
            {
                ExitCar();
            }
        }
    }

    void TryEnterCar()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        // إذا اللاعب قريب من السيارة
        if (distance <= 3f)
        {
            EnterCar();
        }
    }

    void EnterCar()
    {
        isInCar = true;

        // صوت الباب
        if (openCloseDoor != null)
            openCloseDoor.Play();

        // تعطيل اللاعب
        playerObj.SetActive(false);

        // تفعيل السيارة
        pCarController.enabled = true;
        carCam.SetActive(true);

        if (carEngine != null)
            carEngine.Play();
    }

    void ExitCar()
    {
        isInCar = false;

        // صوت الباب
        if (openCloseDoor != null)
            openCloseDoor.Play();

        // إعادة اللاعب
        playerObj.SetActive(true);

        // وضع اللاعب بجانب السيارة
        player.position = transform.position + transform.right * 2f;

        // إيقاف السيارة
        pCarController.enabled = false;
        carCam.SetActive(false);

        if (carEngine != null)
            carEngine.Stop();
    }
}
