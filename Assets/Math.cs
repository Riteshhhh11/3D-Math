using UnityEngine;

public class Math : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public float scProj;
    private void OnDrawGizmos()
    {
        Vector2 a = A.position; 
        Vector2 b = B.position;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(default, a);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(default, b);

        //normalizing A manually
        //float alen = Mathf.Sqrt(a.x * a.x + a.y * a.y); //pythagorean theorem, magnitude of a vector is the square root of the sum of the squares of its components
        //float alen = a.magnitude; //we can also use the magnitude property of the vector, which does the same thing as above but is more efficient because it doesn't require a square root calculation
        //Vector2 aNorm = a / alen; //we can also do a.normalized, which does the same thing as above but is more efficient because it doesn't require a square root calculation

        Vector2 aNorm = a.normalized; //quick and easy way to normalize a vector, it returns a new vector with the same direction but a magnitude of 1
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(aNorm, 0.3f); //drawing normalized version of A, it should be a unit vector pointing in the same direction as A

        //Scalar Projection
        scProj = Vector2.Dot(aNorm, b); //aNorm is normalized and b is non normalized

        //Vector Projection
        Vector2 vecProj = aNorm * scProj;
        Gizmos.color = Color.yellowGreen;
        Gizmos.DrawSphere(vecProj, 0.06f);

    }

}




