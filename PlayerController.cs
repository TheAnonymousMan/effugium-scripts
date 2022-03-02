//#define JUMP_ACTIVE

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float gravity = -10f;

#if JUMP_ACTIVE
    [SerializeField]
    private float jumpHeight = 2f;
#endif

    [SerializeField]
    private AudioSource walkingAudioSource;

    [SerializeField]
    private AudioSource interactingAudioSource;

    [SerializeField]
    private AudioSource keyItemSound;

    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private TextMeshProUGUI interactableText;

    [SerializeField]
    private TextMeshProUGUI collectedText;

    [SerializeField]
    private GameObject lorePanel;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float groundDistance = 0.4f;

    [SerializeField]
    private LayerMask groundMask;

    // TODO
    [SerializeField]
    private GameObject tempDoor;

    [SerializeField]
    private GameObject gigglingWitch;

    [SerializeField]
    private GameObject playerInsanitySound;

    [SerializeField]
    private GameObject gameWinPanel;

   
    private bool isGrounded;
    

    Vector3 downwardsVelocity = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // Reload level
        if (Input.GetKey(KeyCode.Equals) && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && downwardsVelocity.y < 0)
        {
            downwardsVelocity.y = -2f;
        }

        // Movement
        float movementDirectionX = Input.GetAxisRaw("Horizontal");
        float movementDirectionZ = Input.GetAxisRaw("Vertical");

        if (movementDirectionX != 0.0f || movementDirectionZ != 0.0f)
        {
            if (!walkingAudioSource.isPlaying)
                walkingAudioSource.Play();
        }
        else
        {
            walkingAudioSource.Stop();
        }

        Vector3 moveBy = transform.right * movementDirectionX + transform.forward * movementDirectionZ;
        controller.Move(moveBy * speed * Time.deltaTime);

#if JUMP_ACTIVE
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
#endif

        // the player should keep falling
        downwardsVelocity.y += gravity * Time.deltaTime;
        controller.Move(downwardsVelocity * Time.deltaTime);
    }

}
