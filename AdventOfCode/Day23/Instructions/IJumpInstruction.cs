using System;

namespace Day23.Instructions
{
    internal interface IJumpInstruction
    {
        int Offset { get; }

        Func<Register, bool> Condition { get; }
    }
}