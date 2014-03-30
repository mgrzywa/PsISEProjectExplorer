﻿using System.Globalization;
using PsISEProjectExplorer.Enums;
using System;

namespace PsISEProjectExplorer.Model.DocHierarchy.Nodes
{
    public class PowershellFunctionNode : AbstractNode
    {
        public override NodeType NodeType { get { return NodeType.Function; } }

        public string FilePath { get; private set; }

        public PowershellFunction PowershellFunction { get; private set; }

        public PowershellFunctionNode(string filePath, PowershellFunction func, INode parent)
            : base(GetNodePath(filePath, func), func.Name, parent)
        {
            this.FilePath = filePath;
            this.PowershellFunction = func;
        }

        private static string GetNodePath(string filePath, PowershellFunction func)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("filePath");
            }
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }

            return System.IO.Path.Combine(filePath, func.StartLine.ToString(CultureInfo.InvariantCulture));
        }
    }
}
