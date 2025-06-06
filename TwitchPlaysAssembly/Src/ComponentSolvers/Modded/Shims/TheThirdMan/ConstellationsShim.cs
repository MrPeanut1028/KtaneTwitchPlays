﻿using System;
using System.Collections;

[ModuleID("constellations")]
public class ConstellationsShim : ComponentSolverShim
{
	public ConstellationsShim(TwitchModule module)
		: base(module)
	{
		_component = module.BombComponent.GetComponent(ComponentType);
		_buttons = _component.GetValue<KMSelectable[]>("btns");
	}

	protected override IEnumerator ForcedSolveIEnumeratorShimmed()
	{
		yield return null;

		yield return DoInteractionClick(_buttons[_component.GetValue<int>("correctButton")]);
	}

	private static readonly Type ComponentType = ReflectionHelper.FindType("constellationsScript", "constellations");

	private readonly object _component;
	private readonly KMSelectable[] _buttons;
}
