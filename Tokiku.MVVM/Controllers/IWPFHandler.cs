using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokiku.MVVM
{
    public interface IWPFHandler
    {
        /// <devdoc>
        ///    <para>
        ///       Drives web processing execution.
        ///    </para>
        /// </devdoc>
        void ProcessRequest(IFrameNavigationService context);

        /// <devdoc>
        ///    <para>
        ///       Allows an IHTTPHandler instance to indicate at the end of a
        ///       request whether it can be recycled and used for another request.
        ///    </para>
        /// </devdoc>
        bool IsReusable { get; }
    }
}