using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFly : MonoBehaviour
{
    public Transform target; // Целевой объект, на который будет смотреть камера
    public float radius = 10f; // Радиус окружности, по которой будет двигаться камера
    public float speed = 2f; // Скорость движения камеры по окружности

    private Vector3 offset; // Расстояние между камерой и целевым объектом

    private void Start()
    {
        // Вычисляем начальное смещение между камерой и целевым объектом
        offset = transform.position - target.position;
    }

    private void Update()
    {
        // Вычисляем новую позицию камеры по окружности
        float angle = Time.time * speed; // Угол поворота по окружности
        Vector3 circlePos = target.position + new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle)) * radius;
        transform.position = circlePos;

        // Направляем камеру на целевой объект
        transform.LookAt(target);
    }
}
