using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.UI
{
    public abstract class UIView : MonoBehaviour
    {
        protected virtual void OnInit()
        {
        }

        protected virtual void OnEnter()
        {
        }

        protected virtual void OnExit()
        {
        }

        protected void Awake()
        {
        }

        protected void Start()
        {
            OnInit();
            OnEnter();
        }

        protected void OnDestroy()
        {
            OnExit();
        }
    }
}
