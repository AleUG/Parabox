using UnityEngine;
using UnityEngine.UI;

public class ButtonSystem : MonoBehaviour
{
    private Button button;

    private Animator animator; // El Animator que ejecutar� la animaci�n

    void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayAnimation);
    }

    void PlayAnimation()
    {
        animator.Play("click");
    }
}
