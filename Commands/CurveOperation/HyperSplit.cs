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
    public class HyperSplit : Command
    {
        public HyperSplit()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static HyperSplit Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "HyperSplit"; }
        }

        //==============================
        //Array of Curves Selected
        Double MTolerance = Rhino.RhinoDoc.ActiveDoc.ModelAbsoluteTolerance;
        ObjRef[] TempRef { get; set; }

        //==============================
        private Curve[] GetCurves()
        {
            GetObject go = new GetObject();
            go.GeometryFilter = Rhino.DocObjects.ObjectType.Curve;
            go.SetCommandPrompt("Hyper Split | Split All Curves With One Another:");
            go.EnablePreSelect(true, true);
            go.EnablePostSelect(true);
            go.GetMultiple(1, 0);

            Curve[] CurveSel = new Curve[go.ObjectCount];
            TempRef = go.Objects();
            for (int i = 0; i < go.ObjectCount; i++)
            {
                CurveSel[i] = go.Object(i).Curve();
            }
            
            return CurveSel;
        }

        private void MultiCurveSplit(Curve[] CurveArr)
        {
            List<Double>[] CurveParametersArr = new List<double>[CurveArr.Length];
            for (int i = 0; i < CurveArr.Length; i++)
            {
                List<Double> CurveParameters = new List<double>();

                Rhino.Geometry.Intersect.CurveIntersections SelfInter = Rhino.Geometry.Intersect.Intersection.CurveSelf(CurveArr[i], MTolerance);
                for(int a = 0; a < SelfInter.Count; a++)
                {
                    CurveParameters.Add(SelfInter[a].ParameterA);
                    CurveParameters.Add(SelfInter[a].ParameterB);
                }


                for(int j = 0; j < CurveArr.Length; j++)
                {
                    Rhino.Geometry.Intersect.CurveIntersections CurveInter = Rhino.Geometry.Intersect.Intersection.CurveCurve(CurveArr[i], CurveArr[j], MTolerance, MTolerance);
                    for (int k = 0; k < CurveInter.Count; k++)
                    {
                        CurveParameters.Add(CurveInter[k].ParameterA);
                    }
                }
                HashSet<Double> ParametersSet = new System.Collections.Generic.HashSet<Double>(CurveParameters);
                CurveParametersArr[i] = ParametersSet.ToList();
            }
            for (int i = 0; i < CurveArr.Length; i++)
            {
                Curve[] CurveSplit = CurveArr[i].Split(CurveParametersArr[i]);
                foreach(Curve cs in CurveSplit)
                {
                    Rhino.RhinoDoc.ActiveDoc.Objects.AddCurve(cs);
                }
                Rhino.RhinoDoc.ActiveDoc.Objects.Delete(TempRef[i], true);
            }
        }
        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // TODO: start here modifying the behaviour of your command.
            //Select objects
            try
            {
                Curve[] CurveToSplit = GetCurves();
                MultiCurveSplit(CurveToSplit);
                return Result.Success;
            }
            catch
            {
                return Result.Failure;
            }
        }
    }
}
