﻿// © Customize+.
// Licensed under the MIT license.

namespace CustomizePlus.Memory
{
	using System;
	using System.Runtime.InteropServices;
	using Dalamud.Game.ClientState.Objects.Types;

	[StructLayout(LayoutKind.Explicit)]
	public unsafe struct RenderSkeleton
	{
		[FieldOffset(0x050)] public short Length;
		[FieldOffset(0x068)] public PartialSkeleton* PartialSkeletons;

		public static RenderSkeleton* FromActor(Character p)
		{
			if (p.Address == IntPtr.Zero)
				return null;

			IntPtr drawObject = Marshal.ReadIntPtr(p.Address, 0x00F0);
			if (drawObject == IntPtr.Zero)
				return null;

			IntPtr renderSkele = Marshal.ReadIntPtr(drawObject, 0x0A0);
			if (renderSkele == IntPtr.Zero)
				return null;

			return (RenderSkeleton*)renderSkele.ToPointer();
		}
	}
}
