using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Logger = PBFramework.Debugging.Logger;

namespace PBFramework.Graphics.Effects.CoffeeUI
{
    public abstract class BaseCoffeeEffect<T> : IEffect
        where T : MonoBehaviour
    {
        public abstract bool UsesMaterial { get; }

        /// <summary>
        /// The actual coffee effect being wrapped over.
        /// </summary>
        public T Component { get; private set; }


        bool IEffect.Apply(IGraphicObject obj)
        {
            if (Component != null)
            {
                Logger.LogWarning($"BaseCoffeeEffect.Apply - The effect is already bound to object: {Component.name}.");
                return false;
            }

            var graphic = GetGraphic(obj);
            if(graphic == null) return false;

            Component = obj.RawObject.AddComponent<T>();
            return false;
        }

        void IEffect.Revert(IGraphicObject obj)
        {
            var graphic = GetGraphic(obj);
            if (graphic == null) return;
        }

        /// <summary>
        /// Returns the Graphic component from the specified objct.
        /// </summary>
        protected Graphic GetGraphic(IGraphicObject obj)
        {
            var graphic = obj.RawObject.GetComponent<Graphic>();
            if (graphic == null)
            {
                Logger.LogWarning("BaseCoffeeEffect.GetGraphic - Graphic component not found for object: " + obj.Name);
            }
            return graphic;
        }
    }
}