using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    abstract public class TetrisView : Form
    {
        abstract public void changeView(TetrisModel model);
    }
}
