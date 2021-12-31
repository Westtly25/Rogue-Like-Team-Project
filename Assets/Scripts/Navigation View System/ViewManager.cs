using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace RogueLike.UINavigation
{
    public class ViewManager : MonoBehaviour
    {
        public static ViewManager instance;

        [SerializeField] private View startView;
        [SerializeField] private View endView;
        [SerializeField] private View[] views;
        private View currentView;
        [SerializeField] private readonly Stack<View> viewStack = new Stack<View>();

        private void Awake() => instance = this;

        private void Start()
        {
            for (var i = 0; i < views.Length; i++)
            {
                views[i].Initialize();

                views[i].Hide();
            }

            if(startView != null)
            {
                Show(startView, true);
            }
        }

        private void Update()
        {
            //BackButtonPressed();
        }

        public static T GetView<T>() where T : View
        {
            for (var i = 0; i < instance.views.Length; i++)
            {
                if(instance.views[i] is T tView)
                {
                    return tView;
                }
            }

            return null;
        }

        public static void Show<T>(bool remember = true) where T : View
        {
            for (var i = 0; i < instance.views.Length; i++)
            {
                if(instance.views[i] is T)
                {
                    if(remember)
                    {
                        instance.viewStack.Push(instance.currentView);
                    }

                    instance.currentView.Hide();
                }

                instance.views[i].Show();

                instance.currentView = instance.views[i];
            }
        }

        public static void Show(View view, bool remember = true)
        {
            if(instance.currentView != null)
            {
                if(remember)
                {
                    instance.viewStack.Push(instance.currentView);
                }

                instance.currentView.Hide();
            }

            view.Show();

            instance.currentView = view;
        }

        public static void Show(View view, bool remember = true, bool isAnimate = false)
        {
            if(instance.currentView != null)
            {
                if(remember)
                {
                    instance.viewStack.Push(instance.currentView);
                }

                instance.currentView.Hide();
            }

            view.Show();

            instance.currentView = view;
        }

        public static void ShowLast()
        {
            if(instance.viewStack.Count != 0)
            {
                Show(instance.viewStack.Pop(), false);
            }
        }

        public void BackButtonPressed()
        {
            ShowLast();

            if(instance.viewStack.Count <= 0 && endView != null)
            {
                Show(endView, false);
            }
        }
    }
}