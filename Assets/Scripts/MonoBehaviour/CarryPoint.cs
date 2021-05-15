using BoxLoader;
using UnityEngine;


public class CarryPoint : MonoBehaviourExt
{
   
    [SerializeField] private CharacterAnimationController characterAnimationController;
    [SerializeField] private Transform _leftHand;
    [SerializeField] private Transform _rightHand;

    
    void Update()
    {
        transform.position = CalculateCenter(_leftHand.position, _rightHand.position);
    }
    
    private Vector3 CalculateCenter(Vector3 one, Vector3 second)
    {
        return (one + second) / 2;
    }

}