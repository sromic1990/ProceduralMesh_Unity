

﻿using System;

namespace Sourav.Utilities.Scripts.Attributes
{
	[AttributeUsage(AttributeTargets.Method)]
	public class ButtonAttribute : System.Attribute
	{
		public string ButtonName;
        public ButtonWorkType WorkMode;
		
		
        public ButtonAttribute(string buttonName, ButtonWorkType workMode = ButtonWorkType.Both)
		{
			this.ButtonName = buttonName;
			this.WorkMode = workMode;
		}
		
		public ButtonAttribute() : this("")
		{}
	}
	
    [Flags]
	public enum ButtonWorkType
	{
		EditorOnly = 1,
		RunTimeOnly = 2,
		Both = EditorOnly | RunTimeOnly
	}
}

