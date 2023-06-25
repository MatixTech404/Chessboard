using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessboard.Classes
{
    internal class EngineManager
    {
        private Process _engine;
        private string _engineOutput = "";

        public EngineManager(string pathToEngine)
        {
            _engine = new Process();
            _engine.StartInfo.FileName = pathToEngine;
            _engine.StartInfo.UseShellExecute = false;
            _engine.StartInfo.RedirectStandardOutput = true;
            _engine.StartInfo.RedirectStandardInput = true;

            _engine.OutputDataReceived += new DataReceivedEventHandler((sender, e) => { _engineOutput += e.Data; });

            _engine.Start();
        }

        ~EngineManager()
        {
            _engine.WaitForExit();
        }

        public void SendCommand(string command)
        {
            _engine.StandardInput.WriteLine(command);
        }

        public string GetOutput()
        {
            string output = _engineOutput;

            if (output[-1] != '\n')
            {
                return "";
            }

            _engineOutput = "";
            return output;
        }
    }
}
