using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class AnimationChanger : MonoBehaviour
    {
        [SerializeField] private Animator target;
        [SerializeField] private String stateName;
        
        private int stateNameHash;

        private void Awake()
        {
            stateNameHash = Animator.StringToHash(stateName);
        }

        // Start is called before the first frame update
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        void OnButtonClick()
        {
            target.Play(stateNameHash);
        }
    }
}
