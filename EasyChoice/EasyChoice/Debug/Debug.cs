// Authors: Christian Cox and Kyle Daniel Kirkpatrick
// Code inspired from the following Stack Overflow thread:
// https://stackoverflow.com/questions/48413592/net-core-c-sharp-debug-assert-doesnt-break-or-show-message-box

using System;
using System.Diagnostics;
using SystemDebug = System.Diagnostics.Debug;

namespace EasyChoice.Debug
{
    // This is a custom Debug class, written because C#'s Trace.Assert()
    // and Debug.Assert() were not working as needed
    public class Debug
    {
        // Assert checks the given condition and stops the program if it is false
        // (it additionally displays an error message, if given)
        public static void Assert(bool condition, string message = null)
        {
            if (!condition) Fail(message);
        }

        // Fail stops the program and pulls up the CallStack to see where the
        // error originates from
        private static void Fail(string message)
        {
            SystemDebug.WriteLine("Assert error occurred - " + (message ?? "No message"));
            if (!Debugger.IsAttached) Debugger.Launch();
            else Debugger.Break();

            // Exiting the program
            Environment.Exit(2);
        }
    }
}
