using SpacewareCheats.SDK.ButtonAPI;
using System;
using UnityEngine;

namespace SpacewareCheats.Modules
{
    internal class BaseModule
    {
        public string name;
        public bool toggled;
        public bool save;

        public string discription;
        public QMNestedButton category;
        public bool isToggle;
        public Sprite image;

        //format of Buttons 
        public BaseModule(string name, string discription, QMNestedButton category, Sprite image = null, bool isToggle = false)
        {
            this.name = name;
            this.discription = discription;
            this.category = category;
            this.isToggle = isToggle; 
            this.image = image;
        }

        public virtual void OnEnable()
        {

        }

        public virtual void OnDisable()
        {

        }

        public virtual void OnPreferencesSaved()
        {

        }

        public virtual void OnUIInit()
        {
            if (isToggle)
            {
                QMToggleButton qMToggleButton = new QMToggleButton(category.menuTransform, name, discription, new Action<bool>((bool state) =>
                {
                    this.toggled = state;
                    if (state)
                    {
                        OnEnable();
                    }
                    else
                    {
                        OnDisable();
                    }
                    Main.Instance.OnUpdateEventArray = Main.Instance.OnUpdateEvents.ToArray();

                }));
            }
            else
            {
                new QMSingleButton(category.menuTransform, name, discription, image, delegate
                {
                    OnEnable();
                });
            }
        }
    }
}