/*  ucOCLedStrip.cs

This file is part of a program that implements a Software-Defined Radio.

This code/file can be found on GitHub : https://github.com/ramdor/Thetis

Copyright (C) 2020-2024 Richard Samphire MW0LGE

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

The author can be reached by email at

mw0lge@grange-lane.co.uk
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thetis
{
    public partial class ucOCLedStrip : UserControl
    {
        public ucOCLedStrip()
        {
            InitializeComponent();
        }

        private bool m_bTX = false;
        public bool TX
        {
            get { return m_bTX; }
            set {
                m_bTX = value;
                this.Invalidate();
            }
        }
        private int m_nBits = 0;
        public int Bits
        {
            get { return m_nBits; }
            set
            {
                m_nBits = value;
                this.Invalidate();
            }
        }

        private int m_displayBits = 7;
        public int DisplayBits
        {
            get { return m_displayBits; }
            set
            {
                m_displayBits = value;
            }
        }

        private void usOCLedStrip_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for(int nPin = 0; nPin < m_displayBits; nPin++)
            {
                int x = nPin * 16;

                Rectangle r = new Rectangle(x, 0, 15, this.Height-1);
                Brush b;

                bool bOn = (m_nBits & (1 << nPin)) != 0;

                if (bOn)
                {
                    if (m_bTX)
                        b = Brushes.OrangeRed;
                    else
                        b = Brushes.GreenYellow;
                }
                else
                {
                    b = Brushes.Gray;
                }

                g.FillRectangle(b, r);
                g.DrawRectangle(Pens.Black, r);
            }
        }
    }
}
