using UnityEngine;

public class SwitchCharacterCar : MonoBehaviour
{
    [Header("References")]
    public GameObject car;        // السيارة (التحكم)
    public GameObject player;     // اللاعب
    public GameObject visualCar;  // شكل السيارة الخارجي

    private bool isInCar = false;

    void Start()
    {
        car.SetActive(false);      // السيارة مطفأة بالبداية
        player.SetActive(true);    // اللاعب ظاهر
        visualCar.SetActive(true);
    }

    void Update()
    {
        // زر الدخول والخروج
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isInCar)
            {
                EnterCar();
            }
            else
            {
                ExitCar();
            }
        }
    }

    void EnterCar()
    {
        isInCar = true;

        car.SetActive(true);       // تفعيل السيارة
        player.SetActive(false);   // إخفاء اللاعب
        visualCar.SetActive(false);

        Debug.Log("Entered Car");
    }

    void ExitCar()
    {
        isInCar = false;

        car.SetActive(false);      // إيقاف السيارة
        player.SetActive(true);    // إظهار اللاعب
        visualCar.SetActive(true);

        // وضع اللاعب بجانب السيارة
        player.transform.position = visualCar.transform.position + visualCar.transform.right * 2f;

        Debug.Log("Exited Car");
    }
}
