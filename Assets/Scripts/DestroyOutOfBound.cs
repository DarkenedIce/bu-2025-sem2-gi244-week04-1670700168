using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    public float bound = 20f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -bound || transform.position.z > bound)
        {
            Destroy(gameObject);
        }
    }
}
