using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private GameManager gm;
    public Rigidbody rb;

    public Image levelBar;

    private Vector2 firstPos;
    private Vector2 secondPos;
    private Vector2 currentPos;
    
    public float moveSpeed;

    public float currentGroundsNumber;
    
    void Start()
    {
        FreezeRotationAndPositionY();
        gm = GameObject.FindObjectOfType<GameManager>();
    }
    
    private void Update()
    {
        Slide();
        
        levelBar.fillAmount = currentGroundsNumber / gm.groundsNumber;
        if (levelBar.fillAmount == 1)
        {
            gm.LevelUpdate();
        }
    }

    private void Slide()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentPos = new Vector2(secondPos.x - firstPos.x, secondPos.y - firstPos.y);
        }

        currentPos.Normalize();

        if (currentPos.y < 0 && currentPos.x > -0.5f && currentPos.x < 0.5f)
        {
            // Back
            rb.velocity = Vector3.back * moveSpeed;
        }
        else if (currentPos.y > 0 && currentPos.x > -0.5f && currentPos.x < 0.5f)
        {
            // Forward
            rb.velocity = Vector3.forward * moveSpeed;
        }
        else if (currentPos.x < 0 && currentPos.y > -0.5f && currentPos.y < 0.5f)
        {
            // Left
            rb.velocity = Vector3.left * moveSpeed;
        }
        else if (currentPos.x > 0 && currentPos.y > -0.5f && currentPos.y < 0.5f)
        {
            // Right
            rb.velocity = Vector3.right * moveSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (collision.gameObject.GetComponent<MeshRenderer>().material.color !=
                gameObject.GetComponent<MeshRenderer>().material.color)
            {
                collision.gameObject.GetComponent<MeshRenderer>().material.color =
                    gameObject.GetComponent<MeshRenderer>().material.color;
                currentGroundsNumber++;
            }
        }
    }
    
    private void FreezeRotationAndPositionY()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
}