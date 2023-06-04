using UnityEngine;

namespace Movement
{
    public class CharacterInputController : MonoBehaviour
    {
        private IControllable controllable; 

        private void Awake()
        {
            controllable = GetComponent<IControllable>();
        }

        private void Update()
        {
            
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

            
            controllable.Move(movement);

            
            if (movement != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(movement);
                controllable.Rotate(rotation);
            }
        }
    }
}