using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace RogueLike.Layouts
{
    public class TabGroup : MonoBehaviour
    {
        [SerializeField] protected List<TabItem> tabItems;
        [SerializeField] protected List<GameObject> objToSwap;
        [SerializeField] protected Sprite tabIdle;
        [SerializeField] protected Sprite tabHover;
        [SerializeField] protected Sprite tabActive;
        [SerializeField] protected TabItem selectedTab;

        public void Subscribe(TabItem tabItem)
        {
            if (tabItems == null)
            {
                tabItems = new List<TabItem>();
            }

            tabItems.Add(tabItem);
        }

        public void OnTabEnter(TabItem tabItem)
        {
            ResetTabs();

            if (selectedTab == null || tabItem != selectedTab)
            {
                if(tabHover != null)
                {
                    tabItem.background.sprite = tabHover;
                }

                tabItem.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f);
            }
        }

        public void OnTabExit(TabItem tabItem)
        {
            ResetTabs();

            tabItem.transform.DOScale(new Vector3(1f, 1f, 1f), 1f);
        }

        public virtual void OnTabSelected(TabItem tabItem)
        {
            if(selectedTab != null)
            {
                selectedTab.Deselect();
            }

            selectedTab = tabItem;

            selectedTab.Select();

            ResetTabs();
            tabItem.background.sprite = tabActive;

            int index = tabItem.transform.GetSiblingIndex();
            for (int i = 0; i < objToSwap.Count ; i++)
            {
                if(i == index)
                {
                    objToSwap[i].SetActive(true);
                }
                else
                {
                    objToSwap[i].SetActive(false);
                }
            }
        }

        public void ResetTabs()
        {
            foreach (TabItem item in tabItems)
            {
                if(selectedTab != null && item == selectedTab)
                {
                    continue;
                }

                item.background.sprite = tabIdle;
            }
        }
    }
}