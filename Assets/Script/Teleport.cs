using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string sceneToLoad;

    // เมื่อมีการชนกับ GameObject นี้
    void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่า GameObject ที่ชนเป็น player หรือไม่
        if (other.CompareTag("Player"))
        {
            // โหลด scene ที่ต้องการ
            SceneManager.LoadScene(sceneToLoad);

            // หา GameObject ที่มี Tag เป็น "TeleportPoint" ใน scene ที่โหลด
            GameObject teleportPoint = GameObject.FindGameObjectWithTag("TeleportPoint");

            // ย้าย player ไปยังตำแหน่งที่กำหนดใน teleportPoint
            other.transform.position = teleportPoint.transform.position;
        }
    }
}
