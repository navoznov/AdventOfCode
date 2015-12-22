using System;
using System.IO;
using System.Linq;
using Day07.Gates;

namespace Day07
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            var lines = File.ReadAllLines("input1.txt");
            var logicNetwork = new LogicNetwork();
            foreach (var line in lines)
            {
                AddElementsFromInputString(line, logicNetwork);
            }

            var aWire = logicNetwork.GetByName("a");
            Console.WriteLine(aWire.GetValue());
        }
        private static void Part2()
        {
            var lines = File.ReadAllLines("input1.txt");
            var logicNetwork = new LogicNetwork();
            foreach (var line in lines)
            {
                AddElementsFromInputString(line, logicNetwork);
            }
            
            var aWire = logicNetwork.GetByName("a");
            var aWireValue = aWire.GetValue();
            var bWire = logicNetwork.GetByName("b");
            logicNetwork.Elements.OfType<Wire>().ToList().ForEach(x => x.Reset());
            bWire.SetValue(aWireValue);

            Console.WriteLine(aWire.GetValue());
        }

        private static void AddElementsFromInputString(string str, LogicNetwork logicNetwork)
        {
            var parts = str.Split(new[] {"->"}, StringSplitOptions.None);

            var sourceStr = parts[0].Trim();
            var sourceParts = sourceStr.Split(' ');

            IHasValue source;
            if (sourceParts.Length == 1)
            {
                // constant values and wires
                source = ParseElementaryElementAndAddToNetwork(logicNetwork, sourceParts[0].Trim());
            }
            else if (sourceParts.Length == 2)
            {
                // NOT
                var unaryGateStr = sourceParts[0].Trim();
                var unaryGateObjectStr = sourceParts[1].Trim();
                source = ParseUnaryGateElementAndAddToNetwork(logicNetwork, unaryGateStr, unaryGateObjectStr);
            }
            else if (sourceParts.Length == 3)
            {
                // AND OR RSHIFT LSHIFT
                var binaryGateStr = sourceParts[1].Trim();
                var binaryGateObject1Str = sourceParts[0].Trim();
                var binaryGateObject2Str = sourceParts[2].Trim();
                source = ParseBinaryGateElementAndAddToNetwork(logicNetwork, binaryGateStr, binaryGateObject1Str,
                    binaryGateObject2Str);
            }
            else
            {
                throw new ArgumentException("Некорректная строка источника сигнала: " + sourceStr);
            }

            var targetWireName = parts[1].Trim();
            var targetWire = (Wire)ParseElementaryElementAndAddToNetwork(logicNetwork, targetWireName);
            targetWire.Source = source;
        }

        private static IHasValue ParseElementaryElementAndAddToNetwork(LogicNetwork logicNetwork,
            string sourceElementaryStr)
        {
            IHasValue source;
            ConstantValue constantValue;

            if (!ConstantValue.TryParse(sourceElementaryStr, out constantValue))
            {
                var sourceWireName = sourceElementaryStr;
                var wire = logicNetwork.GetByName(sourceWireName);
                if (wire == null)
                {
                    wire = new Wire(sourceWireName);
                    logicNetwork.Elements.Add(wire);
                }
                source = wire;
            }
            else
            {
                logicNetwork.Elements.Add(constantValue);
                source = constantValue;
            }
            return source;
        }

        private static IHasValue ParseUnaryGateElementAndAddToNetwork(LogicNetwork logicNetwork, string unaryGateStr,
            string unaryGateObjectStr)
        {
            var gateSource = ParseElementaryElementAndAddToNetwork(logicNetwork, unaryGateObjectStr);
            if (unaryGateStr.ToUpper() == "NOT")
            {
                var notLogicGate = new NotLogicGate(gateSource);
                logicNetwork.Elements.Add(notLogicGate);
                return notLogicGate;
            }
            throw new ArgumentException("Неизвестный унарный оператор: " + unaryGateStr);
        }

        private static IHasValue ParseBinaryGateElementAndAddToNetwork(LogicNetwork logicNetwork, string binaryGateStr,
            string binaryGateObject1Str, string binaryGateObject2Str)
        {
            var gateSource1 = ParseElementaryElementAndAddToNetwork(logicNetwork, binaryGateObject1Str);
            var gateSource2 = ParseElementaryElementAndAddToNetwork(logicNetwork, binaryGateObject2Str);
            IHasValue binaryGate = null;
            switch (binaryGateStr)
            {
                case "AND":
                    binaryGate = new AndLogicGate(gateSource1, gateSource2);
                    break;
                case "OR":
                    binaryGate = new OrLogicGate(gateSource1, gateSource2);
                    break;
                case "RSHIFT":
                    binaryGate = new RightShiftLogicGate(gateSource1, gateSource2.GetValue());
                    break;
                case "LSHIFT":
                    binaryGate = new LeftShiftLogicGate(gateSource1, gateSource2.GetValue());
                    break;
                default:
                    throw new ArgumentException("Неизвестный бинарный оператор: " + binaryGateStr);
            }
            logicNetwork.Elements.Add(binaryGate);
            return binaryGate;
        }
    }
}