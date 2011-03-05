﻿using System.Text;
using RDotNet.Internals;

namespace RDotNet.Devices
{
	/// <summary>
	/// A console class handles user's inputs and outputs.
	/// </summary>
	public interface ICharacterDevice
	{
		/// <summary>
		/// Read input from console.
		/// </summary>
		/// <param name="prompt">The prompt message.</param>
		/// <param name="capacity">The buffer's capacity in byte.</param>
		/// <param name="history">Whether the input should be added to any command history.</param>
		/// <returns>The input.</returns>
		string ReadConsole(string prompt, int capacity, bool history);

		/// <summary>
		/// Write output on console.
		/// </summary>
		/// <param name="output">The output message</param>
		/// <param name="length">The output's length in byte.</param>
		/// <param name="outputType">The output type.</param>
		void WriteConsole(string output, int length, ConsoleOutputType outputType);

		/// <summary>
		/// Displays the message.
		/// </summary>
		/// <remarks>
		/// It should be brought to the user's attention immediately. 
		/// </remarks>
		/// <param name="message">The message.</param>
		void ShowMessage(string message);

		/// <summary>
		/// Invokes actions.
		/// </summary>
		/// <param name="which">The state.</param>
		void Busy(BusyType which);

#if WINDOWS
		/// <summary>
		/// <summary>
		/// Abort R environment itself as soon as possible.
		/// </summary>
		/// <param name="message">The message.</param>
		void Suicide(string message);

		/// <summary>
		/// Clear the console.
		/// </summary>
		void ResetConsole();

		/// <summary>
		/// Flush the console.
		/// </summary>
		void FlushConsole();

		/// <summary>
		/// Clear the error console.
		/// </summary>
		void ClearErrorConsole();

		/// <summary>
		/// Invokes any actions which occur at system termination.
		/// </summary>
		/// <param name="saveAction">The save type.</param>
		/// <param name="status">Exit code.</param>
		/// <param name="runLast">Whether R should execute <code>.Last</code>.</param>
		void CleanUp(StartupSaveAction saveAction, int status, bool runLast);

		/// <summary>
		/// Displays the contents of files. 
		/// </summary>
		/// <param name="files">The file paths.</param>
		/// <param name="headers">The header before the contents is printed.</param>
		/// <param name="title">The window title.</param>
		/// <param name="delete">Whether the file will be deleted.</param>
		/// <param name="pager">The pager used.</param>
		/// <returns></returns>
		bool ShowFiles(string[] files, string[] headers, string title, bool delete, string pager);

		/// <summary>
		/// Chooses a file.
		/// </summary>
		/// <param name="create">To be created.</param>
		/// <returns>The length of input.</returns>
		string ChooseFile(bool create);

		void EditFile(string file);

		SymbolicExpression LoadHistory(Language call, SymbolicExpression operation, Pairlist args, RDotNet.Environment environment);

		SymbolicExpression SaveHistory(Language call, SymbolicExpression operation, Pairlist args, RDotNet.Environment environment);

		SymbolicExpression AddHistory(Language call, SymbolicExpression operation, Pairlist args, RDotNet.Environment environment);

#endif

	}

}
