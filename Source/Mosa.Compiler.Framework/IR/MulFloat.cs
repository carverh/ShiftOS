﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.IR
{
	/// <summary>
	/// Intermediate representation of the floating point multiplication operation.
	/// </summary>
	/// <remarks>
	/// The instruction is a three-address instruction, where the result receives
	/// the value of the first operand (index 0) multiplied with the second operand (index 1).
	/// <para />
	/// Both the first and second operand must be the same floating point type. If the second operand
	/// is statically or dynamically equal to or larger than the number of bits in the first
	/// operand, the result is undefined.
	/// </remarks>
	public sealed class MulFloat : ThreeOperandInstruction
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MulFloat"/>.
		/// </summary>
		public MulFloat()
		{
		}
	}
}
