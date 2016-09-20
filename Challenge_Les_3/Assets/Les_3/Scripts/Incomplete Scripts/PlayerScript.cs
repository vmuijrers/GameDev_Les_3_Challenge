using UnityEngine;
using System.Collections;
using System;

public class PlayerScript : MonoBehaviour, IHolder {

    [Header("Player Stats")]
    public float acceleration;
    public float gravity = 10;
    public float friction;
    public float pickupRange = 2;
    public float holdDistance = 1f;
    public LayerMask worldLayerMask;
    private Vector3 velocity;
    private IPickupable currentItem;
    private float collisionRadius = 0.5f;

    [Header("Camera")]
    public float cameraSensitivityX;
    public float cameraSensitivityY;
    private float angleX = 0;
    private float angleY = 0;
    
    //Components
    private Rigidbody rb;
    private GameObject cam;
    private AudioSource audioSource;

    //Input
    private bool actionButtonDown = false;
    private float forwardAxis = 0;
    private float sideAxis = 0;
    private float mouseX = 0;
    private float mouseY = 0;

    // Use this for initialization
    private void Start ()
    {
        angleX = transform.localEulerAngles.y;
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        cam = transform.FindChild("Main Camera").gameObject;
    }
	
	// Update is called once per frame
	private void Update ()
    {
        GetInput();
        CheckPickup();
    }

    private void FixedUpdate()
    {
        UpdatePosition();
        UpdateCamera();
        UpdatePickupPosition();
    }

    private void GetInput()
    {
        forwardAxis = Input.GetAxis("Vertical");
        sideAxis = Input.GetAxis("Horizontal");
        actionButtonDown = Input.GetMouseButtonDown(0);
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }

    private void CheckPickup()
    {

        if (actionButtonDown)
        {
            //If we have an object...
            if(currentItem != null)
            {
                //And we look at something...
                IHolder holder = null;
                RaycastHit hit;
                if (UnityEngine.Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange))
                {
                    //If it's a holder
                    holder = hit.collider.gameObject.GetComponent<IHolder>();
                    
                }
                //If it isn't null..
                if (holder != null && !holder.CheckHoldingObject())
                {
                    //Make it hold our released object
                    IPickupable releasedObject = ReleaseObject();
                    releasedObject.GetGameObject().transform.position = hit.point + hit.normal * 0.1f;
                    holder.HoldObject(releasedObject);
                    audioSource.Play();

                }
                else
                {
                    //Otherwise release our object
                    IPickupable releasedItem = ReleaseObject();
                    GameObject releasedGameObject = releasedItem.GetGameObject();
                    if (hit.collider != null)
                    {
                        releasedGameObject.transform.position = hit.point + hit.normal * 0.1f;
                        releasedGameObject.transform.rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
                    }

                }
            }
            else
            {
                //If we don't have an object and we are looking at something...
                RaycastHit hit;
                if(UnityEngine.Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange))
                {
                    //If the item is a pickup...
                    IPickupable pickup = hit.collider.gameObject.GetComponent<IPickupable>();
                    if (pickup != null)
                    {
                         //Pick up the object
                         HoldObject(pickup);
                    }
                    else
                    {
                        //And we look at a holder...
                        IHolder holder = hit.collider.gameObject.GetComponent<IHolder>();
                        if (holder != null)
                        {
                            //And it holds an object...
                            if (holder.CheckHoldingObject())
                            {
                                //Get it from the holder
                                IPickupable releasedObject = holder.ReleaseObject();
                                releasedObject.GetGameObject().transform.position = hit.point + hit.normal * 0.1f;
                                HoldObject(releasedObject);
                            }

                        }
                    }
                
                    
                }
            }
        }

    }
    


    private void UpdatePickupPosition()
    {
        if (currentItem == null) return;
        currentItem.GetGameObject().transform.position = cam.transform.position- cam.transform.up * 1f + cam.transform.forward * holdDistance;
        currentItem.GetGameObject().transform.rotation = cam.transform.rotation;

    }
    private void UpdatePosition()
    {
        RaycastHit hit;
        if(!UnityEngine.Physics.SphereCast(transform.position + collisionRadius * transform.up, collisionRadius, -transform.up, out hit, 0.01f, worldLayerMask))
        {
            //In Air
            velocity += gravity * -transform.up * Time.deltaTime;
        }
        else
        {
            //Grounded
            velocity -= new Vector3(velocity.x, 0, velocity.z) * friction * Time.deltaTime;
            velocity += (transform.forward * forwardAxis + transform.right * sideAxis).normalized * acceleration * Time.deltaTime;
            velocity = new Vector3(velocity.x, 0, velocity.z);
        }
        
        rb.velocity = velocity;
    }

    private void UpdateCamera()
    {

        angleX += mouseX * cameraSensitivityX;
        angleY += mouseY * -cameraSensitivityY;
        angleY = Mathf.Clamp(angleY, -85f, 85f);

        transform.localEulerAngles = new Vector3(0, angleX, 0);
        cam.transform.localEulerAngles = new Vector3(angleY,0, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + 2 * collisionRadius * transform.up, collisionRadius);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    /// <summary>
    /// Implement IHolder
    /// </summary>
    /// <param name="pickup"></param>

    public void HoldObject(IPickupable pickup)
    {
        throw new NotImplementedException();
    }

    public bool CheckHoldingObject()
    {
        throw new NotImplementedException();
    }

    public IPickupable ReleaseObject()
    {
        throw new NotImplementedException();
    }
}
