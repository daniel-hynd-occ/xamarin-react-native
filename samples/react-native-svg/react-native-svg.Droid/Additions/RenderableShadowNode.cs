using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Facebook.React.Uimanager;

namespace Com.Horcrux.Svg
{
    public abstract partial class RenderableShadowNode
    {
        public virtual void AddChildAt(Java.Lang.Object child, int i)
        {
            AddChildAt((ReactShadowNodeImpl)child, i);
        }

        public virtual void AddNativeChildAt(Java.Lang.Object child, int nativeIndex)
        {
            AddNativeChildAt((ReactShadowNodeImpl)child, nativeIndex);
        }

        public virtual int GetNativeOffsetForChild(Java.Lang.Object child)
        {
            return GetNativeOffsetForChild((ReactShadowNodeImpl)child);
        }

        public virtual int IndexOf(Java.Lang.Object child)
        {
            return IndexOf((ReactShadowNodeImpl)child);
        }

        public virtual int IndexOfNativeChild(Java.Lang.Object child)
        {
            return IndexOfNativeChild((ReactShadowNodeImpl)child);
        }

        public virtual bool IsDescendantOf(Java.Lang.Object ancestorNode)
        {
            return IsDescendantOf((ReactShadowNodeImpl)ancestorNode);
        }
    }
}