using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayForm.Constants
{
    public class PdfFormatConstants
    {
        public const string PDF_CERTIFICATE_FORMAT = @"
<h1>Form {0}</h1>
<br/>
<h1>Date: {2} - {3}</h1>
<br/>
<h3>Employee name: {4}</h3>
<br/>
<h2>Description</h2>
<br/>
<p>{1}</p>
<br />
<h2>Query Type: {5}</h2>
<br />
<h4>Signed By {4}</h4>
<br />
<h5>Department: {6}</h5>
<br />
";
    }
}