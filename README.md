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
cd brainfuck-interpreter-c
```

### Running scripts

You can run any `.bf` file by passing it as a command-line argument.

```bash
dotnet run -- hello-world.bf
```
### Example: Hello World

This repository includes a classic `hello-world.bf` script. You can see it in action immmediately:

## Code Snapshot:

```brainfuck
++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.
```
### Project Structure

* **main.cs:** The core Virtual Machine logic and program entry point.
* **hello-world.bf:** Standard "Hello World" implementation.
* **addition.bf:** A sample script demonstrating basic arithmetic and pointer shifting.

### Configuration:

The VM is configured with a standard 30,000-cell tape. To adjust the memory limit or modify the pointer wrap-around behavior, edit the `tape` array initialization in `main.cs`:

```C#
private readonly byte[] tape = new byte[30000];
```
