using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class ShowImageOnGrab : MonoBehaviour
{
    [Header("Sprite to Show When Grabbed")]
    public Sprite imageToShow;

    [Header("Default Sprite to Show When Released")]
    public Sprite defaultImage;

    [Header("UI Image Component on Canvas")]
    public Image canvasImage;

    [Header("GameObject to Enable When Grabbed")]
    public GameObject objectToEnableOnGrab;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        if (grabInteractable == null)
        {
            Debug.LogError("ShowImageOnGrab: No XRGrabInteractable found on " + gameObject.name);
            return;
        }

        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);

        // Initialize UI and target object
        if (canvasImage != null && defaultImage != null)
            canvasImage.sprite = defaultImage;

        if (objectToEnableOnGrab != null)
            objectToEnableOnGrab.SetActive(false); // Ensure it starts disabled
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (canvasImage != null && imageToShow != null)
            canvasImage.sprite = imageToShow;

        if (objectToEnableOnGrab != null)
            objectToEnableOnGrab.SetActive(true);
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        CheckIfAnythingIsGrabbed();
    }

    private void CheckIfAnythingIsGrabbed()
    {
        Invoke(nameof(VerifyGrabState), 0.05f);
    }

    private void VerifyGrabState()
    {
        if (!grabInteractable.isSelected)
        {
            if (canvasImage != null && defaultImage != null)
                canvasImage.sprite = defaultImage;

            if (objectToEnableOnGrab != null)
                objectToEnableOnGrab.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
            grabInteractable.selectExited.RemoveListener(OnReleased);
        }
    }
}
