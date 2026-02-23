using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class LaserBounce : MonoBehaviour
{
    public int maxBounces;

    public void OnDrawGizmos()
    {
        Vector2 origin = transform.position; //origin of the laser, we can use transform.position because the laser is at the position of the game object
        Vector2 dir = transform.right; //x axis
        Ray ray = new Ray(origin, dir); //creating a ray from the origin in the direction of the laser, we can use this ray to check for collisions with other objects in the scene

        for (int i = 0; i < maxBounces; i++) {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(ray.origin, hit.point);
                Vector2 reflected = Reflect(ray.direction, hit.normal);
                Gizmos.color = Color.limeGreen;
                Gizmos.DrawLine(hit.point, (Vector2)hit.point + reflected);
                ray.direction = reflected; //setting the direction of the ray to the reflected direction, so that we can check for collisions in the new direction in the next iteration of the loop
                ray.origin = hit.point; //setting the origin of the ray to the point of collision, so that we can check for collisions from that point in the next iteration of the loop
            }
            else {
                break; //if the ray doesn't hit anything, we can break out of the loop because there are no more bounces to check for
            }
        }
    }

    Vector2 Reflect(Vector2 inDir, Vector2 n)
    { //inDir is the direction of the laser, n is the normal of the surface we are reflecting off of
        float proj = Vector2.Dot(inDir, n);
        return inDir - 2 * proj * n;
    }
}
