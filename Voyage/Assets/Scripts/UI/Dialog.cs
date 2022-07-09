using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace UI
{
    public class Dialog : MonoBehaviour
    {
        public Button buttonContinue;
        public TextMeshProUGUI textStory;
        public ScrollRect scrollRect;
        public float turnSpeed = 1;

        private string _dummyStory = "";

        public void Start()
        {
            textStory.SetText("Loading...");
            buttonContinue.onClick.AddListener(OnContinueClicked);
            buttonContinue.interactable = false;
            if (Application.isEditor)
            {
                CallGenerator("Generated response dummy text...");
            }
            else
            {
                JSWrapper.Initialize();
                CallGenerator(" You open Unity");
            }

        }

        private void OnContinueClicked()
        {
            if(textStory.text.EndsWith(".")) CallGenerator(" Then you");
            else if(textStory.text.EndsWith(" ")) CallGenerator("Unity");
            else CallGenerator("");
        }

        private void CallGenerator(string input)
        {
            if (Application.isEditor)
            {
                _dummyStory += input + "\nsome response...\n";
                GeneratorResponse(_dummyStory);
            }
            else
            {
                JSWrapper.CallGenerator(input);
            }
        }

        public void GeneratorResponse(string message)
        {
            buttonContinue.interactable = true;
            textStory.SetText(message);
            scrollRect.velocity = Vector2.up * 300;
        }

        public void Update()
        {
            var offset = new Vector3(Input.mousePosition.y-Screen.height/2, Screen.width/2-Input.mousePosition.x)*turnSpeed;
            transform.rotation = Quaternion.Euler(offset);
        }
    }
}
