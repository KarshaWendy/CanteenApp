using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanteenDaily
{
    public class ExportReportModel
    {
        public string SavePathReport { get; set; }
        public string DocumentAuthor { get; set; }
        public string DocumentTitle { get; set; }
        public string SheetName { get; set; }
        public string DocumentFontName { get; set; }
    }
}
