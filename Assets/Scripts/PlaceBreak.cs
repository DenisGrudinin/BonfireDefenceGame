using UnityEngine;
using System.Threading.Tasks;
using System;

public class PlaceBreak : MonoBehaviour
{
    [SerializeField] GameObject block;
    [SerializeField] GameObject placeBtn;
    [SerializeField] GameObject aim;
    [SerializeField] Transform raycastPoint;
    [SerializeField] Joystick joystick;
    Vector3 direction;
    Vector3 joystickDirection;
    Vector2 endpos;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");
            endpos = raycastPoint.position + direction.normalized * 4f;
        }
        else
        {
            joystickDirection.x = joystick.Horizontal;
            joystickDirection.y = joystick.Vertical;
            endpos = raycastPoint.position + joystickDirection.normalized * 4f;
        }
        aim.transform.position = endpos;
        Debug.DrawRay(raycastPoint.position, aim.transform.position, Color.red);
    }

    public void OnClickPlaceButton()
    {
        Instantiate(block, endpos, Quaternion.identity);
        Cooldown(placeBtn, 1);
    }

    async void Cooldown(GameObject btn, float time)
    {
        btn.SetActive(false);
        await Task.Delay(TimeSpan.FromSeconds(time));
        btn.SetActive(true);
    }
}
