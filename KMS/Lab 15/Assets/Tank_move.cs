using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_move : MonoBehaviour
{
    public GameObject bashnya;         //объектная переменная для управления башней
    public GameObject stvol;           //объектная переменная для управления стволом

    public float TankMoveSpeed = 0.1f; //для регулирования скорости движения танка
    public float RotateSpeed = 1f;     //для регулирования скорости вращения башни
    public float min = 200f;           //минимальный угол поворота ствола
    public float max = 350f; 			//максимальный угол поворота ствола
    float rotV = 0f;
    float pushPower = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        float z = Input.GetAxis("Vertical");         // клавиши W и S
        if (z != 0)
        {
            //сдвигаемся по оси вдоль взгляда камеры на расстояние TankMoveSpeed*z

            transform.position +=
            transform.TransformDirection(Vector3.up * TankMoveSpeed * z);
        }


        float x = Input.GetAxis("Horizontal");    // клавиши A и D
        if (x != 0)
        {
            // поворачиваем на угол x вокруг оси Y
            transform.Rotate(0f,  0f, x);


        }

        float h = Input.GetAxis("Mouse X");
        if (h != 0)
        {
            bashnya.transform.Rotate(0f, h * RotateSpeed, 0f);
        }

        float v = Input.GetAxis("Mouse Y");


        rotV += v;
        rotV = Mathf.Clamp(rotV, min, max);

        stvol.transform.localRotation = Quaternion.Euler(rotV * RotateSpeed, 0, 0);


       

    }
}
