using UnityEngine;
using UnityEngine.InputSystem;

public class CamMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;
    private GameObject CamParent;
    [SerializeField]
    private Transform camRotator;

    Vector3 position;
    private Vector2 LookPos;
    private float Xrotation = 0f;
    private Vector3 LastPosition = new Vector3(0,0,0);
    private Vector3 difference = new Vector3(0,0,0);

    [SerializeField]
    private float rotationSens = 5f;
    [SerializeField]
    private GameObject playerRenderer;
    //[SerializeField]
    //public Transform target;

    void Start()
    {
        LastPosition = camRotator.position;
        //if (!thirdperson)
        //{
        //    playerRenderer.SetActive(false);
        //}
        CamParent = cam.transform.parent.gameObject;

        position = new Vector3(camRotator.position.x, camRotator.position.y + 5, camRotator.position.z - 10);
        playerRenderer.SetActive(true);

        CamParent.transform.position = position;
    }

    void Update()
    {

        // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
        //transform.LookAt(target, Vector3.up);
        

        camRotator.rotation = Quaternion.identity;


        difference = camRotator.position - LastPosition;

        LookAround();
        CamParent.transform.Translate(difference.x , difference.y, difference.z );

        LastPosition = camRotator.position;
    }

    void LookAround()
    {
        Xrotation = LookPos.x * rotationSens * Time.deltaTime;
          
        if (Mathf.Abs(LookPos.x) > 0)
        {
            CamParent.transform.RotateAround(transform.position, Vector3.up, Xrotation);
            CamParent.transform.rotation = Quaternion.identity;

        }

        cam.transform.LookAt(transform.position);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        LookPos = context.ReadValue<Vector2>();
    }

    //public void OnToggleCamera(InputAction.CallbackContext context)
    //{
    //    if(context.performed || context.canceled) { return; }
        
    //    thirdperson = thirdperson ? false : true;

    //    if (thirdperson == false)
    //    {
    //        position = new Vector3(camRotator.position.x, camRotator.position.y + firstPersonHeight, camRotator.position.z);
    //        playerRenderer.SetActive(false);
    //    }
    //    else
    //    {

           
    //}
}
