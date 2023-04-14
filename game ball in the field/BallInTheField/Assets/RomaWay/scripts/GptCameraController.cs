using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GptCameraController : MonoBehaviour
{
    public Transform player; // ссылка на игрока
    public float followZoneSize = 1f; // радиус области, в которой камера не изменяет направление своего взгляда
    public float rotationSpeed = 1.0f;
    public float smoothness = 0.1f;
    void LateUpdate()
    {
        // выравниваем позицию камеры по игроку
        //transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

        // выравниваем направление камеры на игрока
        //transform.LookAt(player);
        // вычисляем расстояние между игроком и камерой
        //float distance = Vector3.Distance(player.position, transform.position);

        // если игрок находится за пределами зоны, камера выравнивается на игрока
        //if (distance > followZoneSize)
        //{
        // вычисляем направление к игроку
        //Vector3 direction = (player.position - transform.position).normalized;

        // выравниваем направление камеры на игрока
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, -direction);
        //transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        //}

        //float rot = Mathf.MoveTowardsAngle(transform.eulerAngles.y, player.eulerAngles.y, 10f * Time.deltaTime);
        //transform.localEulerAngles = new Vector3(0, rot, 0);
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 targetDirection = direction;
        if (Math.Abs(AngleBetweenVectors(direction, Camera.main.transform.forward)) > 15f)
        {
            //transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            /*
            Vector3 currentDirection = transform.forward;
            float step = rotationSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(currentDirection, targetDirection, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
            */

            // Определить новое направление камеры, сглаживая поворот с помощью Quaternion.Slerp
            Quaternion newRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, smoothness);
        }
    }
    public static float AngleBetweenVectors(Vector3 vector1, Vector3 vector2)
    {
        return Mathf.Acos(Vector3.Dot(vector1.normalized, vector2.normalized)) * Mathf.Rad2Deg;
    }
}
