using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example1
{
	public partial class TestUserControl : UserControl
	{
		public TestUserControl()
		{
			InitializeComponent();

			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.SetStyle(ControlStyles.Selectable, true);
		}
	}
}
