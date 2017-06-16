using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokiku.Entity.ViewTables
{
    public class MoldsEnter
    {
        /*
         LegendMoldReduction, UsePosition, Code, SerialNumber, " +
                         " b.Name as Name1, UnitWeight, SurfaceTreatment, PaintArea, " +
                         " MembraneTreatment, MinimumYield, ProductionIngot, " +
                         " TotalOrderWeight, c.Name as Name2, Comment
         */
        public String LegendMoldReduction { get; set; }
        public String UsePosition { get; set; }
        public String Code { get; set; }
        public String SerialNumber { get; set; }
        public String Name1 { get; set; }
        public float UnitWeight { get; set; }
        public String SurfaceTreatment { get; set; }
        public float PaintArea { get; set; }
        public float MembraneTreatment { get; set; }
        public float MinimumYield { get; set; }
        public float ProductionIngot { get; set; }
        public float TotalOrderWeight { get; set; }
        public String Name2 { get; set; }
        public String Comment { get; set; }

    }
}
