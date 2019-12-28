using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;

namespace Zachitect_RH
{
    [CommandStyle(Style.ScriptRunner)]
    public class SuperDifference : Command
    {
        public SuperDifference()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static SuperDifference Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "SuperDifference"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // TODO: start here modifying the behaviour of your command.
            //Select objects
            try
            {
                GetObject go = new GetObject();
                go.EnablePreSelect(true, true);
                go.EnablePostSelect(true);
                go.SetCommandPrompt("Super Difference | Advanced Boolean Difference:");
                go.GetMultiple(1, 0);
                if (go.ObjectCount > 0)
                {
                    RhinoApp.RunScript("_BooleanDifference", true);
                    RhinoApp.RunScript("_SelLast", true);
                    RhinoApp.RunScript("_MergeAllFaces", true);
                    RhinoApp.RunScript("_ShrinkTrimmedSrf", true);
                }
                return Result.Success;
            }
            catch
            {
                return Result.Failure;
            }
            
        }
    }
}
