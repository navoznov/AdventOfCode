using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day23.Instructions
{
    internal class InstructionFactory
    {
        private readonly Register[] _registers;

        public InstructionFactory(Register[] registers)
        {
            _registers = registers;
        }

        public IEnumerable<Instruction> Parse(string[] lines)
        {
            var regex = new Regex(@"(?<inst>\w+) (?<reg>[ab]+)?(?:\, )?(?<offset>[\+\-]\d+)?");


            foreach (var line in lines)
            {
                var match = regex.Match(line);
                var instructionName = match.Groups["inst"].Value;
                var register = match.Groups["reg"].Value;
                var offsetStr = match.Groups["offset"].Value;
                var offset = string.IsNullOrEmpty(offsetStr) ? 0 : int.Parse(offsetStr);
                if (instructionName == "hlf")
                {
                    yield return new HalfInstruction(_registers.Single(x => x.Name == register));
                }
                else if (instructionName == "tpl")
                {
                    yield return new TripleInstruction(_registers.Single(x => x.Name == register));
                }
                if (instructionName == "inc")
                {
                    yield return new IncrementInstruction(_registers.Single(x => x.Name == register));
                }
                if (instructionName == "jmp")
                {
                    yield return new JumpInstruction(offset, x => true);
                }
                if (instructionName == "jie")
                {
                    yield return new JumpInstruction(offset, x => x.Value%2 == 0, _registers.Single(x => x.Name == register));
                }
                if (instructionName == "jio")
                {
                    yield return new JumpInstruction(offset, x => x.Value == 1, _registers.Single(x => x.Name == register));
                }
            }
        }
    }
}