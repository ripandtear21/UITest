using UnityEngine;

namespace Movement
{
    public class PlayerMovement : MonoBehaviour, IControllable
    {
        public float moveSpeed = 5f;     
        public float turnSpeed = 10f;    

        private Rigidbody _playerRigidbody;   
        private Transform _cameraTransform;   
        private Animator animator;           
        private readonly int isRunningHash = Animator.StringToHash("isRunning");
        private void Start()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
            _cameraTransform = Camera.main.transform;
            animator = GetComponent<Animator>();
        }

        public void Move(Vector3 movement)
        {
            
            Vector3 cameraForward = Vector3.Scale(_cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 movementDirection = movement.z * cameraForward + movement.x * _cameraTransform.right;

            
            Vector3 newPosition = _playerRigidbody.position + movementDirection * (moveSpeed * Time.fixedDeltaTime);

            
            _playerRigidbody.MovePosition(newPosition);
            bool isRunning = movement.magnitude > 0f;
            animator.SetBool(isRunningHash, isRunning);
            
            if (movementDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movementDirection);
                _playerRigidbody.MoveRotation(Quaternion.Lerp(_playerRigidbody.rotation, toRotation, turnSpeed * Time.fixedDeltaTime));
            }
        }

        public void Rotate(Quaternion rotation)
        {
            
            if (rotation != Quaternion.identity)
            {
                Quaternion cameraRotation = Quaternion.Euler(0f, _cameraTransform.rotation.eulerAngles.y, 0f);
                Quaternion targetRotation = cameraRotation * rotation;
                _playerRigidbody.MoveRotation(Quaternion.Lerp(_playerRigidbody.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime));
            }
        }
    }
}
