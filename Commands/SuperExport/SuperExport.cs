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
    public class SuperExport : Command
    {
        public SuperExport()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static SuperExport Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "SuperExport"; }
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
                go.SetCommandPrompt("Select Objects to Export:");
                go.GetMultiple(1, 0);
                if(go.ObjectCount > 0)
                {
                    List<String> GeometryRecord = new List<String>();
                    for (int i = 0; i < go.ObjectCount; i++)
                    {
                        ObjRef oref = new ObjRef(go.Object(i).ObjectId);
                        String objname = oref.Object().Geometry.ObjectType.ToString();
                        GeometryRecord.Add(objname);
                    }

                    List<String> GeoStatement = new List<String>();
                    var GROccur = GeometryRecord.GroupBy(i => i);
                    {
                        foreach (var i in GROccur)
                        {
                            String GeoStat = i.Key + " x " + i.Count().ToString();
                            GeoStatement.Add(GeoStat);
                        }
                    }
                    FormSuperExport FSE = new FormSuperExport();
                    FSE.SelectedItemNames = GeoStatement;
                    FSE.ItemCount = GeometryRecord.Count;
                    if (FSE.ShowDialog() == DialogResult.OK)
                    {
                        for (int i = 0; i < FSE.ItemCount; i++)
                        {
                            RhinoDoc.ActiveDoc.Objects.UnselectAll();
                            RhinoDoc.ActiveDoc.Objects.Select(go.Object(i).ObjectId);
                            String Scri = String.Format("-_Export \"{0}\"", FSE.FullPath[i]);
                            RhinoApp.RunScript("-_Export \"" + FSE.FullPath[i] + "\" Enter Enter ", true);
                        }
                        RhinoDoc.ActiveDoc.Objects.UnselectAll();
                        doc.Views.Redraw();
                        RhinoApp.WriteLine("Super Export Completed", EnglishName);
                        return Result.Success;
                    }
                    else
                    {
                        return Result.Failure;
                    }
                }
                else
                {
                    RhinoApp.WriteLine("Nothing Selected, Operation Cancelled");
                    return Result.Failure;
                }

            }
            catch
            {
                return Result.Failure;
            }
            
        }
    }
}
