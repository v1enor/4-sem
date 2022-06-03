using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{

    float moveSpeed = 0.5f;
    float rotSeedTank  = 0.5f; 
    float rotSpeedBash  = 0.5f; 
    float speedCore  = 0.1f;
    public Transform target;
    public Transform bash; 
    public Transform stvol; 
    public GameObject core; 
    bool canShoot;
    int life = 3;
    private float rotZ;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            
            transform.LookAt(new Vector3(0, 0, transform.position.z));

            ////После определения, что танк находится в триггере игрока, нужно вычислить некоторые значения:
            ////1)	дистанцию до игрока: 
            //float distance = Vector3.Distance(other.transform.position, transform.position);
            ////2)	Определить вектор направления:
            //Vector3 relativePos = (other.transform.position - transform.position);

            ////3)	И по вектору направления определить поворот:
            //Quaternion newRot = Quaternion.LookRotation(relativePos);


            ////В независимости от расстояния, но при нахождении в триггере поворачиваем башню в сторону игрока: 
            ////bash.rotation = Quaternion.Slerp(bash.rotation, newRot, Time.deltaTime * rotSpeedBash);


            ////переменная для определения объекта попадания «луча»
            RaycastHit hit;
            ////если выпущен луч из башни в направлении относительно нее – вперед
            if (Physics.Raycast(stvol.position, stvol.TransformDirection(Vector3.forward), out hit))
            {
                //если луч попал в коллайдер игрока и можно выстрелить
                if ((hit.transform.tag == "Player") && canShoot)
                {
                    //запускаем короутину для выстрела танка-бота
                    StartCoroutine(botshoot());
                }
            }




            ////Интерполяция - нахождение неизвестных промежуточных значений некоторой функции, 
            ////по имеющемуся дискретному набору её известных значений, определенным способом.

            ////При дистанции меньше 20, бот должен двигаться и поворачиваться в направлении к игроку
            //if (distance > 20)
            //{


            //    relativePos.z = transform.position.z;
            //    transform.LookAt(relativePos);
            //    //Quaternion rotation = Quaternion.AngleAxis(rotZ , Vector3( 1f,1f,1f);
            //    //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotSeedTank);


            //    // поворачиваем танк с помощью интерполяции между текущим поворотом и требуемым
            //    // направлением в сторону игрока с заданной скоростью
            //    /*Quaternion */
            //    //newRot = Quaternion.LookRotation(relativePos);
            //    //transform.rotation = Quaternion.Slerp(transform.rotation, newRot, Time.deltaTime * rotSeedTank);
            //    //// плавно двигаем танк-бота в сторону игрока
            //    //transform.position = Vector3.Lerp(transform.position, other.transform.position, Time.deltaTime * moveSpeed);
            //}
        }
    }

        IEnumerator botshoot()
        {
            canShoot = false;//указываем, что танк-бот стрелять пока не может
                            //определяем координату для положения снаряда танка-бота
            Vector3 forwardofstvol = stvol.transform.position + stvol.transform.TransformDirection(Vector3.forward * 8f);
            //создаем снаряд из префаба снаряда в требуемой координате относительно ствола
            GameObject newcore = Instantiate(core, forwardofstvol, stvol.rotation);
            //ждем 3 секунды (время «перезарядки»)
            yield return new WaitForSeconds(3f);
            //указываем, что танк может сделать выстрел
            canShoot = true;
        }
        

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "core")
            {
                life--;
                if (life < 1) Destroy(gameObject);
            }
        }
 }

