using UnityEngine;

namespace Movement
{
    public interface IControllable 
    {
        void Move(Vector3 movement);
        void Rotate(Quaternion rotation);
    }
}
