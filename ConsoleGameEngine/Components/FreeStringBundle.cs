using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameEngine.Components
{
    public class FreeStringBundle
    {
        public int startRow, startColumn, endColumn;
        public Color tColorDefault = Color.White, bColorDefault = Color.Black;
        Alignment alignmentDefault = Alignment.Left;
        public List<FreeString> content = new List<FreeString>();

        #region Constructor
        public FreeStringBundle(int row, int leftLimit, int rightLimit)
        {
            startRow = row;
            startColumn = leftLimit;
            endColumn = rightLimit;
        }

        public FreeStringBundle(int row, int leftLimit, int rightLimit,
                          Color tColorDefault, Color bColorDefault)
                          : this(row, leftLimit, rightLimit)
        {
            this.tColorDefault = tColorDefault;
            this.bColorDefault = bColorDefault;
        }

        public FreeStringBundle(int row, int leftLimit, int rightLimit, Alignment alignmentDefault)
            : this(row, leftLimit, rightLimit)
        {
            this.alignmentDefault = alignmentDefault;
        }

        public FreeStringBundle(int row, int leftLimit, int rightLimit,
                           Color tColorDefault, Color bColorDefault, Alignment alignmentDefault)
                           : this(row, leftLimit, rightLimit, tColorDefault, bColorDefault)
        {
            this.alignmentDefault = alignmentDefault;
        }
        #endregion



        public void ClearContent()
        {
            content.Clear();
        }
    }
}
