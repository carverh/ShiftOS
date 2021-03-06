﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x86.Instructions
{
	/// <summary>
	/// Representations the x86 Btr instruction.
	/// </summary>
	public sealed class Btr : TwoOperandInstruction
	{
		#region Data Members

		private static readonly OpCode RM_C = new OpCode(new byte[] { 0x0F, 0xB3 }, 6);
		private static readonly OpCode RM_R = new OpCode(new byte[] { 0x0F, 0xBA });

		#endregion Data Members

		#region Methods

		/// <summary>
		/// Computes the opcode.
		/// </summary>
		/// <param name="destination">The destination operand.</param>
		/// <param name="source">The source operand.</param>
		/// <param name="third">The third operand.</param>
		/// <returns></returns>
		protected override OpCode ComputeOpCode(Operand destination, Operand source, Operand third)
		{
			if (third.IsConstant)
				return RM_C;
			else
				return RM_R;
		}

		#endregion Methods
	}
}
