using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class BrainfuckVM
{
    private readonly char[] code;
    private readonly byte[] tape = new byte[30000];
    private int dp = 0;
    private int ip = 0;
    private readonly Dictionary<int, int> bracketMap;
    private readonly Queue<char> inputBuffer;
    private readonly StringBuilder output = new StringBuilder();

    public BrainfuckVM(char[] code, string inputStream = "")
    {
        this.code = code;
        this.inputBuffer = new Queue<char>(inputStream.ToCharArray());
        this.bracketMap = BuildBracketMap(code);
    }

    public static char[] ParseCode(string source)
    {
        List<char> instructions = new List<char>();
        char[] validCommands = { '>', '<', '+', '-', '.', ',', '[', ']' };
        foreach (char c in source)
        {
            if (Array.Exists(validCommands, cmd => cmd == c)) 
                instructions.Add(c);
        }
        return instructions.ToArray();
    }

    private Dictionary<int, int> BuildBracketMap(char[] code)
    {
        var map = new Dictionary<int, int>();
        var stack = new Stack<int>();
        for (int i = 0; i < code.Length; i++)
        {
            if (code[i] == '[') stack.Push(i);
            else if (code[i] == ']')
            {
                if (stack.Count == 0) throw new FormatException($"Unmatched ']' at {i}");
                int openIndex = stack.Pop();
                map[openIndex] = i;
                map[i] = openIndex;
            }
        }
        if (stack.Count > 0) throw new FormatException($"Unmatched '[' at {stack.Peek()}");
        return map;
    }

    public bool Step()
    {
        if (ip < 0 || ip >= code.Length) return false;

        switch (code[ip])
        {
            case '>': dp++; break;
            case '<': if (--dp < 0) throw new Exception("Pointer out of bounds"); break;
            case '+': unchecked { tape[dp]++; } break;
            case '-': unchecked { tape[dp]--; } break;
            case '.': output.Append((char)tape[dp]); break;
            case ',': tape[dp] = inputBuffer.Count > 0 ? (byte)inputBuffer.Dequeue() : (byte)0; break;
            case '[': if (tape[dp] == 0) ip = bracketMap[ip]; break;
            case ']': if (tape[dp] != 0) ip = bracketMap[ip]; break;
        }

        ip++; 
        return true;
    }

    public void RunUntilEnd() { while (Step()); }
    public string GetOutput() => output.ToString();

    public void DumpState()
    {
        char instr = (ip >= 0 && ip < code.Length) ? code[ip] : ' ';
        Console.WriteLine($"IP:{ip} ('{instr}') | DP:{dp} | Val:{tape[dp]}");
    }

    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: dotnet run -- <path-to-file.bf>");
            return;
        }

        try
        {
            string source = File.ReadAllText(args[0]);
            char[] cleanCode = ParseCode(source);
            BrainfuckVM vm = new BrainfuckVM(cleanCode);
            vm.RunUntilEnd();
            Console.Write(vm.GetOutput());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
        }
    }
}