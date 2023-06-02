using UnityEngine;

namespace Movement
{
    public class CameraMovement : MonoBehaviour
    {
        public Transform target;                      
        public float distance = 5f;                   
        public float height = 2f;                     
        public float rotationSpeed = 5f;              

        private float currentX = 0f;
        private float currentY = 0f;

        private void LateUpdate()
        {
        
            currentX += Input.GetAxis("Mouse X") * rotationSpeed;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        
            currentY = Mathf.Clamp(currentY, -90f, 90f);

        
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);
            Vector3 position = target.position - rotation * Vector3.forward * distance + Vector3.up * height;

        
            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
