using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_ShoeInventory
{
    class MarkaLabel : Label
    {
        private bool _isSelected;
        public int BrandId { get; set; }
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value)
                    this.BackColor = Color.Yellow;
                else
                    this.BackColor = Color.White;

                _isSelected = value;
            }
        }
        public MarkaLabel()
        {
            Width = 250;
            Height = 50;
            Margin = new Padding(10);
            BackColor = Color.White;
            Font = new Font(FontFamily.GenericSansSerif, 22f);
        }
        protected override void OnClick(EventArgs e)
        {
            this.IsSelected = !IsSelected;
            base.OnClick(e);
        }
    }
}
