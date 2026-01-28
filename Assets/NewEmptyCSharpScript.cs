using UnityEngine;

public class CarButton : MonoBehaviour
{
    public GameObject player;
    public GameObject car;

    bool inCar = false;

    public void PressButton()
    {
        if (!inCar)
        {
            player.SetActive(false);
            inCar = true;
        }
        else
        {
            player.SetActive(true);
            inCar = false;
        }
    }
}
