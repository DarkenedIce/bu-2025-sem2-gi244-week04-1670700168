using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 10.0f;
    public float walkRange = 10.0f;

    public GameObject foodPrefab;

    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");

    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * walkSpeed * Time.deltaTime * Vector3.right);

        if(transform.position.x < -walkRange)
        {
            transform.position = new Vector3(-walkRange, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > walkRange)
        {
            transform.position = new Vector3(walkRange, transform.position.y, transform.position.z);
        }

        if(shootAction.triggered)
        {
            Instantiate(foodPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(transform.position, 1f);
        //Gizmos.color = Color.blue;
        //Gizmos.DrawLine(transform.position, Camera.main.transform.position);

        Gizmos.color = Color.red;
        Vector3 left = new Vector3(-walkRange, transform.position.y, transform.position.z);
        Vector3 right = new Vector3(walkRange, transform.position.y, transform.position.z);
        Gizmos.DrawLine(left, right);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(left, 0.5f);
        Gizmos.DrawWireSphere(right, 0.5f);
    }
}
