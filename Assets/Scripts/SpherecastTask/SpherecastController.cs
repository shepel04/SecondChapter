using UnityEngine;

namespace SpherecastTask
{
    public class SpherecastController : MonoBehaviour
    {
        public float SphereRadius = 0.5f;
        public float MaxDistance = 100f;
    
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
    
                if (Physics.SphereCast(ray, SphereRadius, out hit, MaxDistance))
                {
                    Debug.Log("Hit: " + hit.collider.name);
                    Debug.DrawLine(ray.origin, hit.point, Color.red, 2f);
                    DrawSphere(hit.point, SphereRadius, Color.green, 2f);
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * MaxDistance, Color.red, 2f);
                }
            }
        }
    
        void DrawSphere(Vector3 position, float radius, Color color, float duration)
        {
            int segments = 20;
            float step = Mathf.PI * 2 / segments;
    
            for (int i = 0; i < segments; i++)
            {
                float angle1 = step * i;
                float angle2 = step * (i + 1);
    
                Vector3 point1 = position + new Vector3(Mathf.Cos(angle1), 0, Mathf.Sin(angle1)) * radius;
                Vector3 point2 = position + new Vector3(Mathf.Cos(angle2), 0, Mathf.Sin(angle2)) * radius;
                Debug.DrawLine(point1, point2, color, duration);
    
                Vector3 point3 = position + new Vector3(0, Mathf.Cos(angle1), Mathf.Sin(angle1)) * radius;
                Vector3 point4 = position + new Vector3(0, Mathf.Cos(angle2), Mathf.Sin(angle2)) * radius;
                Debug.DrawLine(point3, point4, color, duration);
    
                Vector3 point5 = position + new Vector3(Mathf.Cos(angle1), Mathf.Sin(angle1), 0) * radius;
                Vector3 point6 = position + new Vector3(Mathf.Cos(angle2), Mathf.Sin(angle2), 0) * radius;
                Debug.DrawLine(point5, point6, color, duration);
            }
        }
    }
}

