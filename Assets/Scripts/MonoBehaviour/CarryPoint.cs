using BoxLoader;
using UnityEngine;


public class CarryPoint : MonoBehaviourExt
{
   
    [SerializeField] private CharacterAnimationController characterAnimationController;
    [SerializeField] private Transform _leftHand;
    [SerializeField] private Transform _rightHand;

   
    
    void Update()
    {
        // if (!_characterAnimationsEvents._isUsing)
        //     return;

        transform.position = CalculateCenter(_leftHand.position, _rightHand.position);
     //TODO remove and obj in prefab
    }
    
    private Vector3 CalculateCenter(Vector3 one, Vector3 second)
    {
        return new Vector3(one.x + second.x, one.y + second.y, one.z + second.z) / 2;
    }
    
}