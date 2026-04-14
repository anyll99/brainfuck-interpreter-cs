# Brainfuck Interpreter in C#

A Brainfuck Virtual Machine and interpreter built with .NET. Featuring a pre-computed jump map for fast loop execution and a decoupled VM state for easy debugging.

## Features

- **Fast Loop Execution**: Uses a bracket map to handle `[` and `]` jumps in $O(1)$ time.
- **Unchecked Arithmetic**: Implements standard 8-bit cell wrapping ($255 + 1 = 0$).
- **State Dumper**: Includes a `DumpState()` method to visualize the Instruction Pointer (IP), Data Pointer (DP), and current cell values.
- **Clean Architecture**: Separate parsing and execution logic.

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or newer recommended)

### Installation
Clone the repository:
```bash
git clone [https://github.com/anyll99/brainfuck-interpreter-cs.git](https://github.com/anyll99/brainfuck-interpreter-cs.git)
cd brainfuck-interpreter-cs
