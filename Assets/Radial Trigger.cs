using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RadialTrigger : MonoBehaviour
{
    [SerializeField] private Transform BarrelPos;
    [SerializeField] private Transform PlayerPos;
    [SerializeField] private float radius;

    private void Update()
    {
        RadialTriggerCheck();
    }
    private void RadialTriggerCheck() {
        Vector3 delta = BarrelPos.position - PlayerPos.position; //
        float distance = CalculateMagnitude(delta);
        if (distance < radius){
            Debug.Log("Blast Trigger");
        }
        Debug.Log(distance);

    }
    float CalculateMagnitude(Vector3 v)
    { //Calcualting the distance between the barrel and the player, which is the magnitude of the delta vector
        return Mathf.Sqrt(v.x * v.x + v.y + v.y + v.z + v.z);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(BarrelPos.position, radius);   
        
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(PlayerPos.position, 1f);
    }
}
