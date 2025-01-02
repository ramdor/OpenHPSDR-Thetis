//=================================================================
// xvtr.cs
//=================================================================
// PowerSDR is a C# implementation of a Software Defined Radio.
// Copyright (C) 2004-2009  FlexRadio Systems
// Copyright (C) 2010-2013  Doug Wigley
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//
// You may contact us via email at: sales@flex-radio.com.
// Paper mail may be sent to: 
//    FlexRadio Systems
//    8900 Marybank Dr.
//    Austin, TX 78750
//    USA
//=================================================================

using System;
using System.Windows.Forms;

namespace Thetis
{
	public class XVTRForm : Form
	{
		#region Variable Declaration

		private Console console;
		//private NumericUpDownTS[] ucb_addr;
		private NumericUpDownTS[] begin;
		private NumericUpDownTS[] end;
		private CheckBoxTS[] enabled;
		private NumericUpDownTS[] lo_offset;
		private NumericUpDownTS[] lo_error;
		private NumericUpDownTS[] rx_gain;
		private CheckBoxTS[] rx_only;
		private NumericUpDownTS[] power;
		private CheckBoxTS[] xvtr_rf;
        private CheckBox[] disable_pa;
        private ComboBoxTS[] rx_antennas;

		private System.Windows.Forms.TextBoxTS txtBandButton0;
		private System.Windows.Forms.TextBoxTS txtBandButton1;
		private System.Windows.Forms.TextBoxTS txtBandButton2;
		private System.Windows.Forms.TextBoxTS txtBandButton3;
		private System.Windows.Forms.TextBoxTS txtBandButton4;
		private System.Windows.Forms.TextBoxTS txtBandButton5;
		private System.Windows.Forms.TextBoxTS txtBandButton6;
		private System.Windows.Forms.TextBoxTS txtBandButton7;
		private System.Windows.Forms.TextBoxTS txtBandButton8;
		private System.Windows.Forms.TextBoxTS txtBandButton9;
		private System.Windows.Forms.TextBoxTS txtBandButton10;
		private System.Windows.Forms.TextBoxTS txtBandButton11;
		private System.Windows.Forms.TextBoxTS txtBandButton12;
		private System.Windows.Forms.TextBoxTS txtBandButton13;
		private System.Windows.Forms.TextBoxTS txtBandButton14;
        private System.Windows.Forms.TextBoxTS txtBandButton15;
		private System.Windows.Forms.CheckBoxTS chkEnable0;
		private System.Windows.Forms.CheckBoxTS chkEnable1;
		private System.Windows.Forms.CheckBoxTS chkEnable2;
		private System.Windows.Forms.CheckBoxTS chkEnable3;
		private System.Windows.Forms.CheckBoxTS chkEnable4;
		private System.Windows.Forms.CheckBoxTS chkEnable5;
		private System.Windows.Forms.CheckBoxTS chkEnable6;
		private System.Windows.Forms.CheckBoxTS chkEnable7;
		private System.Windows.Forms.CheckBoxTS chkEnable8;
		private System.Windows.Forms.CheckBoxTS chkEnable9;
		private System.Windows.Forms.CheckBoxTS chkEnable10;
		private System.Windows.Forms.CheckBoxTS chkEnable11;
		private System.Windows.Forms.CheckBoxTS chkEnable12;
		private System.Windows.Forms.CheckBoxTS chkEnable13;
		private System.Windows.Forms.CheckBoxTS chkEnable14;
		private System.Windows.Forms.CheckBoxTS chkEnable15;
        private System.Windows.Forms.LabelTS lblBandButton;
		private System.Windows.Forms.LabelTS lblButtonText;
		private System.Windows.Forms.LabelTS lblEnabled;
		private System.Windows.Forms.TextBoxTS txtButtonText15;
		private System.Windows.Forms.TextBoxTS txtButtonText14;
		private System.Windows.Forms.TextBoxTS txtButtonText13;
		private System.Windows.Forms.TextBoxTS txtButtonText12;
		private System.Windows.Forms.TextBoxTS txtButtonText11;
		private System.Windows.Forms.TextBoxTS txtButtonText10;
		private System.Windows.Forms.TextBoxTS txtButtonText9;
		private System.Windows.Forms.TextBoxTS txtButtonText8;
		private System.Windows.Forms.TextBoxTS txtButtonText7;
		private System.Windows.Forms.TextBoxTS txtButtonText6;
		private System.Windows.Forms.TextBoxTS txtButtonText5;
		private System.Windows.Forms.TextBoxTS txtButtonText4;
		private System.Windows.Forms.TextBoxTS txtButtonText3;
		private System.Windows.Forms.TextBoxTS txtButtonText2;
		private System.Windows.Forms.TextBoxTS txtButtonText1;
		private System.Windows.Forms.TextBoxTS txtButtonText0;
		private System.Windows.Forms.LabelTS lblLOOffset;
		private System.Windows.Forms.NumericUpDownTS udLOOffset15;
		private System.Windows.Forms.NumericUpDownTS udLOOffset14;
		private System.Windows.Forms.NumericUpDownTS udLOOffset13;
		private System.Windows.Forms.NumericUpDownTS udLOOffset12;
		private System.Windows.Forms.NumericUpDownTS udLOOffset11;
		private System.Windows.Forms.NumericUpDownTS udLOOffset10;
		private System.Windows.Forms.NumericUpDownTS udLOOffset9;
		private System.Windows.Forms.NumericUpDownTS udLOOffset8;
		private System.Windows.Forms.NumericUpDownTS udLOOffset7;
		private System.Windows.Forms.NumericUpDownTS udLOOffset6;
		private System.Windows.Forms.NumericUpDownTS udLOOffset5;
		private System.Windows.Forms.NumericUpDownTS udLOOffset4;
		private System.Windows.Forms.NumericUpDownTS udLOOffset3;
		private System.Windows.Forms.NumericUpDownTS udLOOffset2;
		private System.Windows.Forms.NumericUpDownTS udLOOffset1;
		private System.Windows.Forms.NumericUpDownTS udLOOffset0;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin15;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin14;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin13;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin12;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin11;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin10;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin9;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin8;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin7;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin6;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin5;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin4;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin3;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin2;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin1;
		private System.Windows.Forms.NumericUpDownTS udFreqBegin0;
		private System.Windows.Forms.LabelTS lblFreqBegin;
		private System.Windows.Forms.LabelTS lblFreqEnd;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd15;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd14;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd13;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd12;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd11;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd10;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd9;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd8;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd7;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd6;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd5;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd4;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd3;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd2;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd1;
		private System.Windows.Forms.NumericUpDownTS udFreqEnd0;
		private System.Windows.Forms.LabelTS lblRXOnly;
		private System.Windows.Forms.CheckBoxTS chkRXOnly15;
		private System.Windows.Forms.CheckBoxTS chkRXOnly14;
		private System.Windows.Forms.CheckBoxTS chkRXOnly13;
		private System.Windows.Forms.CheckBoxTS chkRXOnly12;
		private System.Windows.Forms.CheckBoxTS chkRXOnly11;
		private System.Windows.Forms.CheckBoxTS chkRXOnly10;
		private System.Windows.Forms.CheckBoxTS chkRXOnly9;
		private System.Windows.Forms.CheckBoxTS chkRXOnly8;
		private System.Windows.Forms.CheckBoxTS chkRXOnly7;
		private System.Windows.Forms.CheckBoxTS chkRXOnly6;
		private System.Windows.Forms.CheckBoxTS chkRXOnly5;
		private System.Windows.Forms.CheckBoxTS chkRXOnly4;
		private System.Windows.Forms.CheckBoxTS chkRXOnly3;
		private System.Windows.Forms.CheckBoxTS chkRXOnly2;
		private System.Windows.Forms.CheckBoxTS chkRXOnly1;
		private System.Windows.Forms.CheckBoxTS chkRXOnly0;
		private System.Windows.Forms.NumericUpDownTS udLOError15;
		private System.Windows.Forms.NumericUpDownTS udLOError14;
		private System.Windows.Forms.NumericUpDownTS udLOError13;
		private System.Windows.Forms.NumericUpDownTS udLOError12;
		private System.Windows.Forms.NumericUpDownTS udLOError11;
		private System.Windows.Forms.NumericUpDownTS udLOError10;
		private System.Windows.Forms.NumericUpDownTS udLOError9;
		private System.Windows.Forms.NumericUpDownTS udLOError8;
		private System.Windows.Forms.NumericUpDownTS udLOError7;
		private System.Windows.Forms.NumericUpDownTS udLOError6;
		private System.Windows.Forms.NumericUpDownTS udLOError5;
		private System.Windows.Forms.NumericUpDownTS udLOError4;
		private System.Windows.Forms.NumericUpDownTS udLOError3;
		private System.Windows.Forms.NumericUpDownTS udLOError2;
		private System.Windows.Forms.NumericUpDownTS udLOError1;
		private System.Windows.Forms.NumericUpDownTS udLOError0;
		private System.Windows.Forms.LabelTS lblLOError;
		private System.Windows.Forms.NumericUpDownTS udPower15;
		private System.Windows.Forms.NumericUpDownTS udPower14;
		private System.Windows.Forms.NumericUpDownTS udPower13;
		private System.Windows.Forms.NumericUpDownTS udPower12;
		private System.Windows.Forms.NumericUpDownTS udPower11;
		private System.Windows.Forms.NumericUpDownTS udPower10;
		private System.Windows.Forms.NumericUpDownTS udPower9;
		private System.Windows.Forms.NumericUpDownTS udPower8;
		private System.Windows.Forms.NumericUpDownTS udPower7;
		private System.Windows.Forms.NumericUpDownTS udPower6;
		private System.Windows.Forms.NumericUpDownTS udPower5;
		private System.Windows.Forms.NumericUpDownTS udPower4;
		private System.Windows.Forms.NumericUpDownTS udPower3;
		private System.Windows.Forms.NumericUpDownTS udPower2;
		private System.Windows.Forms.NumericUpDownTS udPower1;
		private System.Windows.Forms.NumericUpDownTS udPower0;
		private System.Windows.Forms.LabelTS lblPower;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF15;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF14;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF13;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF12;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF11;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF10;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF9;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF8;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF7;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF6;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF5;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF4;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF3;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF2;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF1;
		private System.Windows.Forms.CheckBoxTS chkXVTRRF0;
		private System.Windows.Forms.LabelTS lblXVTRRF;
		private System.Windows.Forms.NumericUpDownTS udRXGain15;
		private System.Windows.Forms.NumericUpDownTS udRXGain14;
		private System.Windows.Forms.NumericUpDownTS udRXGain13;
		private System.Windows.Forms.NumericUpDownTS udRXGain12;
		private System.Windows.Forms.NumericUpDownTS udRXGain11;
		private System.Windows.Forms.NumericUpDownTS udRXGain10;
		private System.Windows.Forms.NumericUpDownTS udRXGain9;
		private System.Windows.Forms.NumericUpDownTS udRXGain8;
		private System.Windows.Forms.NumericUpDownTS udRXGain7;
		private System.Windows.Forms.NumericUpDownTS udRXGain6;
		private System.Windows.Forms.NumericUpDownTS udRXGain5;
		private System.Windows.Forms.NumericUpDownTS udRXGain4;
		private System.Windows.Forms.NumericUpDownTS udRXGain3;
		private System.Windows.Forms.NumericUpDownTS udRXGain2;
		private System.Windows.Forms.NumericUpDownTS udRXGain1;
		private System.Windows.Forms.NumericUpDownTS udRXGain0;
		private System.Windows.Forms.LabelTS lblRXGain;
		private System.Windows.Forms.CheckBoxTS chkUseXVTRTUNPWR;
        public CheckBoxTS chkAlexTRRelay;
        private CheckBoxTS chkDisablePA15;
        private CheckBoxTS chkDisablePA14;
        private CheckBoxTS chkDisablePA13;
        private CheckBoxTS chkDisablePA12;
        private CheckBoxTS chkDisablePA11;
        private CheckBoxTS chkDisablePA10;
        private CheckBoxTS chkDisablePA9;
        private CheckBoxTS chkDisablePA8;
        private CheckBoxTS chkDisablePA7;
        private CheckBoxTS chkDisablePA6;
        private CheckBoxTS chkDisablePA5;
        private CheckBoxTS chkDisablePA4;
        private CheckBoxTS chkDisablePA3;
        private CheckBoxTS chkDisablePA2;
        private CheckBoxTS chkDisablePA1;
        private CheckBoxTS chkDisablePA0;
        private LabelTS lblDisablePA;
        private LabelTS labelTS1;
        private ComboBoxTS comboAnt0;
        private ComboBoxTS comboAnt1;
        private ComboBoxTS comboAnt2;
        private ComboBoxTS comboAnt5;
        private ComboBoxTS comboAnt4;
        private ComboBoxTS comboAnt3;
        private ComboBoxTS comboAnt11;
        private ComboBoxTS comboAnt10;
        private ComboBoxTS comboAnt9;
        private ComboBoxTS comboAnt8;
        private ComboBoxTS comboAnt7;
        private ComboBoxTS comboAnt6;
        private ComboBoxTS comboAnt15;
        private ComboBoxTS comboAnt14;
        private ComboBoxTS comboAnt13;
        private ComboBoxTS comboAnt12;
        private System.ComponentModel.Container components = null;

		#endregion

		#region Constructor and Destructor

		public XVTRForm(Console c)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			console = c;
			SetupControlArrays();
			Common.RestoreForm(this, "XVTR", false);
            //if(console.fwc_init && console.CurrentModel == Model.FLEX5000)
            //    lblXVTRRF.Text = "Split RF";
            //else if(console.fwc_init && console.CurrentModel == Model.FLEX3000)
            //{
            //    lblXVTRRF.Visible = false;
            //    chkXVTRRF0.Visible = false;
            //    chkXVTRRF1.Visible = false;
            //    chkXVTRRF2.Visible = false;
            //    chkXVTRRF3.Visible = false;
            //    chkXVTRRF4.Visible = false;
            //    chkXVTRRF5.Visible = false;
            //    chkXVTRRF6.Visible = false;
            //    chkXVTRRF7.Visible = false;
            //    chkXVTRRF8.Visible = false;
            //    chkXVTRRF9.Visible = false;
            //    chkXVTRRF10.Visible = false;
            //    chkXVTRRF11.Visible = false;
            //    chkXVTRRF12.Visible = false;
            //    chkXVTRRF13.Visible = false;
            //    chkXVTRRF14.Visible = false;
            //    chkXVTRRF15.Visible = false;
            //}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XVTRForm));
            this.comboAnt15 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt14 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt13 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt12 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt11 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt10 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt9 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt8 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt7 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt6 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt5 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt4 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt3 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt2 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt1 = new System.Windows.Forms.ComboBoxTS();
            this.comboAnt0 = new System.Windows.Forms.ComboBoxTS();
            this.labelTS1 = new System.Windows.Forms.LabelTS();
            this.chkDisablePA15 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA14 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA13 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA12 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA11 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA10 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA9 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA8 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA7 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA6 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA5 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA4 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA3 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA2 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA1 = new System.Windows.Forms.CheckBoxTS();
            this.chkDisablePA0 = new System.Windows.Forms.CheckBoxTS();
            this.lblDisablePA = new System.Windows.Forms.LabelTS();
            this.chkAlexTRRelay = new System.Windows.Forms.CheckBoxTS();
            this.chkUseXVTRTUNPWR = new System.Windows.Forms.CheckBoxTS();
            this.udRXGain15 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain14 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain13 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain12 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain11 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain10 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain9 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain8 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain7 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain6 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain5 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain4 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain3 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain2 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain1 = new System.Windows.Forms.NumericUpDownTS();
            this.udRXGain0 = new System.Windows.Forms.NumericUpDownTS();
            this.lblRXGain = new System.Windows.Forms.LabelTS();
            this.chkXVTRRF15 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF14 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF13 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF12 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF11 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF10 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF9 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF8 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF7 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF6 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF5 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF4 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF3 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF2 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF1 = new System.Windows.Forms.CheckBoxTS();
            this.chkXVTRRF0 = new System.Windows.Forms.CheckBoxTS();
            this.lblXVTRRF = new System.Windows.Forms.LabelTS();
            this.udPower15 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower14 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower13 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower12 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower11 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower10 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower9 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower8 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower7 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower6 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower5 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower4 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower3 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower2 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower1 = new System.Windows.Forms.NumericUpDownTS();
            this.udPower0 = new System.Windows.Forms.NumericUpDownTS();
            this.lblPower = new System.Windows.Forms.LabelTS();
            this.udLOError15 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError14 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError13 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError12 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError11 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError10 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError9 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError8 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError7 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError6 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError5 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError4 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError3 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError2 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError1 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOError0 = new System.Windows.Forms.NumericUpDownTS();
            this.lblLOError = new System.Windows.Forms.LabelTS();
            this.chkRXOnly15 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly14 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly13 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly12 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly11 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly10 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly9 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly8 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly7 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly6 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly5 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly4 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly3 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly2 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly1 = new System.Windows.Forms.CheckBoxTS();
            this.chkRXOnly0 = new System.Windows.Forms.CheckBoxTS();
            this.lblRXOnly = new System.Windows.Forms.LabelTS();
            this.udFreqEnd15 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd14 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd13 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd12 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd11 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd10 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd9 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd8 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd7 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd6 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd5 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd4 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd3 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd2 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd1 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqEnd0 = new System.Windows.Forms.NumericUpDownTS();
            this.lblFreqEnd = new System.Windows.Forms.LabelTS();
            this.udFreqBegin15 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin14 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin13 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin12 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin11 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin10 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin9 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin8 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin7 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin6 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin5 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin4 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin3 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin2 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin1 = new System.Windows.Forms.NumericUpDownTS();
            this.udFreqBegin0 = new System.Windows.Forms.NumericUpDownTS();
            this.lblFreqBegin = new System.Windows.Forms.LabelTS();
            this.udLOOffset15 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset14 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset13 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset12 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset11 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset10 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset9 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset8 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset7 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset6 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset5 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset4 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset3 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset2 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset1 = new System.Windows.Forms.NumericUpDownTS();
            this.udLOOffset0 = new System.Windows.Forms.NumericUpDownTS();
            this.lblLOOffset = new System.Windows.Forms.LabelTS();
            this.txtButtonText15 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText14 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText13 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText12 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText11 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText10 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText9 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText8 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText7 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText6 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText5 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText4 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText3 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText2 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText1 = new System.Windows.Forms.TextBoxTS();
            this.txtButtonText0 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton15 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton14 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton13 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton12 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton11 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton10 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton9 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton8 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton7 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton6 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton5 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton4 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton3 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton2 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton1 = new System.Windows.Forms.TextBoxTS();
            this.txtBandButton0 = new System.Windows.Forms.TextBoxTS();
            this.lblEnabled = new System.Windows.Forms.LabelTS();
            this.chkEnable15 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable14 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable13 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable12 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable11 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable10 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable9 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable8 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable7 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable6 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable5 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable4 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable3 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable2 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable1 = new System.Windows.Forms.CheckBoxTS();
            this.chkEnable0 = new System.Windows.Forms.CheckBoxTS();
            this.lblButtonText = new System.Windows.Forms.LabelTS();
            this.lblBandButton = new System.Windows.Forms.LabelTS();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset0)).BeginInit();
            this.SuspendLayout();
            // 
            // comboAnt15
            // 
            this.comboAnt15.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt15.Enabled = false;
            this.comboAnt15.FormattingEnabled = true;
            this.comboAnt15.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt15.Location = new System.Drawing.Point(842, 407);
            this.comboAnt15.Name = "comboAnt15";
            this.comboAnt15.Size = new System.Drawing.Size(52, 21);
            this.comboAnt15.TabIndex = 240;
            this.comboAnt15.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt14
            // 
            this.comboAnt14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt14.Enabled = false;
            this.comboAnt14.FormattingEnabled = true;
            this.comboAnt14.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt14.Location = new System.Drawing.Point(842, 382);
            this.comboAnt14.Name = "comboAnt14";
            this.comboAnt14.Size = new System.Drawing.Size(52, 21);
            this.comboAnt14.TabIndex = 239;
            this.comboAnt14.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt13
            // 
            this.comboAnt13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt13.Enabled = false;
            this.comboAnt13.FormattingEnabled = true;
            this.comboAnt13.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt13.Location = new System.Drawing.Point(842, 358);
            this.comboAnt13.Name = "comboAnt13";
            this.comboAnt13.Size = new System.Drawing.Size(52, 21);
            this.comboAnt13.TabIndex = 238;
            this.comboAnt13.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt12
            // 
            this.comboAnt12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt12.Enabled = false;
            this.comboAnt12.FormattingEnabled = true;
            this.comboAnt12.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt12.Location = new System.Drawing.Point(842, 332);
            this.comboAnt12.Name = "comboAnt12";
            this.comboAnt12.Size = new System.Drawing.Size(52, 21);
            this.comboAnt12.TabIndex = 237;
            this.comboAnt12.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt11
            // 
            this.comboAnt11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt11.Enabled = false;
            this.comboAnt11.FormattingEnabled = true;
            this.comboAnt11.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt11.Location = new System.Drawing.Point(842, 307);
            this.comboAnt11.Name = "comboAnt11";
            this.comboAnt11.Size = new System.Drawing.Size(52, 21);
            this.comboAnt11.TabIndex = 236;
            this.comboAnt11.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt10
            // 
            this.comboAnt10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt10.Enabled = false;
            this.comboAnt10.FormattingEnabled = true;
            this.comboAnt10.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt10.Location = new System.Drawing.Point(842, 283);
            this.comboAnt10.Name = "comboAnt10";
            this.comboAnt10.Size = new System.Drawing.Size(52, 21);
            this.comboAnt10.TabIndex = 235;
            this.comboAnt10.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt9
            // 
            this.comboAnt9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt9.Enabled = false;
            this.comboAnt9.FormattingEnabled = true;
            this.comboAnt9.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt9.Location = new System.Drawing.Point(842, 259);
            this.comboAnt9.Name = "comboAnt9";
            this.comboAnt9.Size = new System.Drawing.Size(52, 21);
            this.comboAnt9.TabIndex = 234;
            this.comboAnt9.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt8
            // 
            this.comboAnt8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt8.Enabled = false;
            this.comboAnt8.FormattingEnabled = true;
            this.comboAnt8.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt8.Location = new System.Drawing.Point(842, 235);
            this.comboAnt8.Name = "comboAnt8";
            this.comboAnt8.Size = new System.Drawing.Size(52, 21);
            this.comboAnt8.TabIndex = 233;
            this.comboAnt8.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt7
            // 
            this.comboAnt7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt7.Enabled = false;
            this.comboAnt7.FormattingEnabled = true;
            this.comboAnt7.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt7.Location = new System.Drawing.Point(842, 211);
            this.comboAnt7.Name = "comboAnt7";
            this.comboAnt7.Size = new System.Drawing.Size(52, 21);
            this.comboAnt7.TabIndex = 232;
            this.comboAnt7.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt6
            // 
            this.comboAnt6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt6.Enabled = false;
            this.comboAnt6.FormattingEnabled = true;
            this.comboAnt6.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt6.Location = new System.Drawing.Point(842, 187);
            this.comboAnt6.Name = "comboAnt6";
            this.comboAnt6.Size = new System.Drawing.Size(52, 21);
            this.comboAnt6.TabIndex = 231;
            this.comboAnt6.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt5
            // 
            this.comboAnt5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt5.Enabled = false;
            this.comboAnt5.FormattingEnabled = true;
            this.comboAnt5.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt5.Location = new System.Drawing.Point(842, 163);
            this.comboAnt5.Name = "comboAnt5";
            this.comboAnt5.Size = new System.Drawing.Size(52, 21);
            this.comboAnt5.TabIndex = 230;
            this.comboAnt5.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt4
            // 
            this.comboAnt4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt4.Enabled = false;
            this.comboAnt4.FormattingEnabled = true;
            this.comboAnt4.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt4.Location = new System.Drawing.Point(842, 139);
            this.comboAnt4.Name = "comboAnt4";
            this.comboAnt4.Size = new System.Drawing.Size(52, 21);
            this.comboAnt4.TabIndex = 229;
            this.comboAnt4.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt3
            // 
            this.comboAnt3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt3.Enabled = false;
            this.comboAnt3.FormattingEnabled = true;
            this.comboAnt3.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt3.Location = new System.Drawing.Point(842, 115);
            this.comboAnt3.Name = "comboAnt3";
            this.comboAnt3.Size = new System.Drawing.Size(52, 21);
            this.comboAnt3.TabIndex = 228;
            this.comboAnt3.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt2
            // 
            this.comboAnt2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt2.Enabled = false;
            this.comboAnt2.FormattingEnabled = true;
            this.comboAnt2.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt2.Location = new System.Drawing.Point(842, 91);
            this.comboAnt2.Name = "comboAnt2";
            this.comboAnt2.Size = new System.Drawing.Size(52, 21);
            this.comboAnt2.TabIndex = 227;
            this.comboAnt2.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt1
            // 
            this.comboAnt1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt1.Enabled = false;
            this.comboAnt1.FormattingEnabled = true;
            this.comboAnt1.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt1.Location = new System.Drawing.Point(842, 67);
            this.comboAnt1.Name = "comboAnt1";
            this.comboAnt1.Size = new System.Drawing.Size(52, 21);
            this.comboAnt1.TabIndex = 226;
            this.comboAnt1.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // comboAnt0
            // 
            this.comboAnt0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnt0.Enabled = false;
            this.comboAnt0.FormattingEnabled = true;
            this.comboAnt0.Items.AddRange(new object[] {
            "def",
            "1",
            "2",
            "3",
            "Alt Rx"});
            this.comboAnt0.Location = new System.Drawing.Point(842, 43);
            this.comboAnt0.Name = "comboAnt0";
            this.comboAnt0.Size = new System.Drawing.Size(52, 21);
            this.comboAnt0.TabIndex = 225;
            this.comboAnt0.SelectedIndexChanged += new System.EventHandler(this.comboAnt0_SelectedIndexChanged);
            // 
            // labelTS1
            // 
            this.labelTS1.Image = null;
            this.labelTS1.Location = new System.Drawing.Point(856, 16);
            this.labelTS1.Name = "labelTS1";
            this.labelTS1.Size = new System.Drawing.Size(42, 31);
            this.labelTS1.TabIndex = 224;
            this.labelTS1.Text = "RX1 Ant";
            // 
            // chkDisablePA15
            // 
            this.chkDisablePA15.Checked = true;
            this.chkDisablePA15.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA15.Enabled = false;
            this.chkDisablePA15.Image = null;
            this.chkDisablePA15.Location = new System.Drawing.Point(820, 408);
            this.chkDisablePA15.Name = "chkDisablePA15";
            this.chkDisablePA15.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA15.TabIndex = 223;
            // 
            // chkDisablePA14
            // 
            this.chkDisablePA14.Checked = true;
            this.chkDisablePA14.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA14.Enabled = false;
            this.chkDisablePA14.Image = null;
            this.chkDisablePA14.Location = new System.Drawing.Point(820, 384);
            this.chkDisablePA14.Name = "chkDisablePA14";
            this.chkDisablePA14.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA14.TabIndex = 222;
            // 
            // chkDisablePA13
            // 
            this.chkDisablePA13.Checked = true;
            this.chkDisablePA13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA13.Enabled = false;
            this.chkDisablePA13.Image = null;
            this.chkDisablePA13.Location = new System.Drawing.Point(820, 360);
            this.chkDisablePA13.Name = "chkDisablePA13";
            this.chkDisablePA13.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA13.TabIndex = 220;
            // 
            // chkDisablePA12
            // 
            this.chkDisablePA12.Checked = true;
            this.chkDisablePA12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA12.Enabled = false;
            this.chkDisablePA12.Image = null;
            this.chkDisablePA12.Location = new System.Drawing.Point(820, 336);
            this.chkDisablePA12.Name = "chkDisablePA12";
            this.chkDisablePA12.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA12.TabIndex = 219;
            // 
            // chkDisablePA11
            // 
            this.chkDisablePA11.Checked = true;
            this.chkDisablePA11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA11.Enabled = false;
            this.chkDisablePA11.Image = null;
            this.chkDisablePA11.Location = new System.Drawing.Point(820, 312);
            this.chkDisablePA11.Name = "chkDisablePA11";
            this.chkDisablePA11.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA11.TabIndex = 218;
            // 
            // chkDisablePA10
            // 
            this.chkDisablePA10.Checked = true;
            this.chkDisablePA10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA10.Enabled = false;
            this.chkDisablePA10.Image = null;
            this.chkDisablePA10.Location = new System.Drawing.Point(820, 288);
            this.chkDisablePA10.Name = "chkDisablePA10";
            this.chkDisablePA10.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA10.TabIndex = 217;
            // 
            // chkDisablePA9
            // 
            this.chkDisablePA9.Checked = true;
            this.chkDisablePA9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA9.Enabled = false;
            this.chkDisablePA9.Image = null;
            this.chkDisablePA9.Location = new System.Drawing.Point(820, 264);
            this.chkDisablePA9.Name = "chkDisablePA9";
            this.chkDisablePA9.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA9.TabIndex = 216;
            // 
            // chkDisablePA8
            // 
            this.chkDisablePA8.Checked = true;
            this.chkDisablePA8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA8.Enabled = false;
            this.chkDisablePA8.Image = null;
            this.chkDisablePA8.Location = new System.Drawing.Point(820, 240);
            this.chkDisablePA8.Name = "chkDisablePA8";
            this.chkDisablePA8.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA8.TabIndex = 215;
            // 
            // chkDisablePA7
            // 
            this.chkDisablePA7.Checked = true;
            this.chkDisablePA7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA7.Enabled = false;
            this.chkDisablePA7.Image = null;
            this.chkDisablePA7.Location = new System.Drawing.Point(820, 216);
            this.chkDisablePA7.Name = "chkDisablePA7";
            this.chkDisablePA7.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA7.TabIndex = 214;
            // 
            // chkDisablePA6
            // 
            this.chkDisablePA6.Checked = true;
            this.chkDisablePA6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA6.Enabled = false;
            this.chkDisablePA6.Image = null;
            this.chkDisablePA6.Location = new System.Drawing.Point(820, 192);
            this.chkDisablePA6.Name = "chkDisablePA6";
            this.chkDisablePA6.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA6.TabIndex = 213;
            // 
            // chkDisablePA5
            // 
            this.chkDisablePA5.Checked = true;
            this.chkDisablePA5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA5.Enabled = false;
            this.chkDisablePA5.Image = null;
            this.chkDisablePA5.Location = new System.Drawing.Point(820, 168);
            this.chkDisablePA5.Name = "chkDisablePA5";
            this.chkDisablePA5.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA5.TabIndex = 212;
            // 
            // chkDisablePA4
            // 
            this.chkDisablePA4.Checked = true;
            this.chkDisablePA4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA4.Enabled = false;
            this.chkDisablePA4.Image = null;
            this.chkDisablePA4.Location = new System.Drawing.Point(820, 144);
            this.chkDisablePA4.Name = "chkDisablePA4";
            this.chkDisablePA4.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA4.TabIndex = 211;
            // 
            // chkDisablePA3
            // 
            this.chkDisablePA3.Checked = true;
            this.chkDisablePA3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA3.Enabled = false;
            this.chkDisablePA3.Image = null;
            this.chkDisablePA3.Location = new System.Drawing.Point(820, 120);
            this.chkDisablePA3.Name = "chkDisablePA3";
            this.chkDisablePA3.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA3.TabIndex = 210;
            // 
            // chkDisablePA2
            // 
            this.chkDisablePA2.Checked = true;
            this.chkDisablePA2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA2.Enabled = false;
            this.chkDisablePA2.Image = null;
            this.chkDisablePA2.Location = new System.Drawing.Point(820, 96);
            this.chkDisablePA2.Name = "chkDisablePA2";
            this.chkDisablePA2.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA2.TabIndex = 209;
            // 
            // chkDisablePA1
            // 
            this.chkDisablePA1.Checked = true;
            this.chkDisablePA1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA1.Enabled = false;
            this.chkDisablePA1.Image = null;
            this.chkDisablePA1.Location = new System.Drawing.Point(820, 72);
            this.chkDisablePA1.Name = "chkDisablePA1";
            this.chkDisablePA1.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA1.TabIndex = 208;
            // 
            // chkDisablePA0
            // 
            this.chkDisablePA0.Checked = true;
            this.chkDisablePA0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisablePA0.Enabled = false;
            this.chkDisablePA0.Image = null;
            this.chkDisablePA0.Location = new System.Drawing.Point(820, 48);
            this.chkDisablePA0.Name = "chkDisablePA0";
            this.chkDisablePA0.Size = new System.Drawing.Size(16, 16);
            this.chkDisablePA0.TabIndex = 207;
            // 
            // lblDisablePA
            // 
            this.lblDisablePA.Image = null;
            this.lblDisablePA.Location = new System.Drawing.Point(812, 16);
            this.lblDisablePA.Name = "lblDisablePA";
            this.lblDisablePA.Size = new System.Drawing.Size(42, 32);
            this.lblDisablePA.TabIndex = 221;
            this.lblDisablePA.Text = "Disable PA";
            // 
            // chkAlexTRRelay
            // 
            this.chkAlexTRRelay.AutoSize = true;
            this.chkAlexTRRelay.Image = null;
            this.chkAlexTRRelay.Location = new System.Drawing.Point(285, 436);
            this.chkAlexTRRelay.Name = "chkAlexTRRelay";
            this.chkAlexTRRelay.Size = new System.Drawing.Size(114, 17);
            this.chkAlexTRRelay.TabIndex = 206;
            this.chkAlexTRRelay.Text = "Disable ANAN PA ";
            this.chkAlexTRRelay.UseVisualStyleBackColor = true;
            this.chkAlexTRRelay.Visible = false;
            this.chkAlexTRRelay.CheckedChanged += new System.EventHandler(this.chkAlexTRRelay_CheckedChanged);
            // 
            // chkUseXVTRTUNPWR
            // 
            this.chkUseXVTRTUNPWR.Image = null;
            this.chkUseXVTRTUNPWR.Location = new System.Drawing.Point(80, 432);
            this.chkUseXVTRTUNPWR.Name = "chkUseXVTRTUNPWR";
            this.chkUseXVTRTUNPWR.Size = new System.Drawing.Size(152, 24);
            this.chkUseXVTRTUNPWR.TabIndex = 204;
            this.chkUseXVTRTUNPWR.Text = "Use XVTR PWR for Tune";
            this.chkUseXVTRTUNPWR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkUseXVTRTUNPWR.CheckedChanged += new System.EventHandler(this.chkUseXVTRTUNPWR_CheckedChanged);
            // 
            // udRXGain15
            // 
            this.udRXGain15.DecimalPlaces = 1;
            this.udRXGain15.Enabled = false;
            this.udRXGain15.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain15.Location = new System.Drawing.Point(590, 408);
            this.udRXGain15.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain15.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain15.Name = "udRXGain15";
            this.udRXGain15.Size = new System.Drawing.Size(56, 20);
            this.udRXGain15.TabIndex = 188;
            this.udRXGain15.TinyStep = false;
            this.udRXGain15.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain15.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain14
            // 
            this.udRXGain14.DecimalPlaces = 1;
            this.udRXGain14.Enabled = false;
            this.udRXGain14.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain14.Location = new System.Drawing.Point(590, 384);
            this.udRXGain14.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain14.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain14.Name = "udRXGain14";
            this.udRXGain14.Size = new System.Drawing.Size(56, 20);
            this.udRXGain14.TabIndex = 176;
            this.udRXGain14.TinyStep = false;
            this.udRXGain14.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain14.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain13
            // 
            this.udRXGain13.DecimalPlaces = 1;
            this.udRXGain13.Enabled = false;
            this.udRXGain13.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain13.Location = new System.Drawing.Point(590, 360);
            this.udRXGain13.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain13.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain13.Name = "udRXGain13";
            this.udRXGain13.Size = new System.Drawing.Size(56, 20);
            this.udRXGain13.TabIndex = 164;
            this.udRXGain13.TinyStep = false;
            this.udRXGain13.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain13.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain12
            // 
            this.udRXGain12.DecimalPlaces = 1;
            this.udRXGain12.Enabled = false;
            this.udRXGain12.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain12.Location = new System.Drawing.Point(590, 336);
            this.udRXGain12.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain12.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain12.Name = "udRXGain12";
            this.udRXGain12.Size = new System.Drawing.Size(56, 20);
            this.udRXGain12.TabIndex = 152;
            this.udRXGain12.TinyStep = false;
            this.udRXGain12.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain12.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain11
            // 
            this.udRXGain11.DecimalPlaces = 1;
            this.udRXGain11.Enabled = false;
            this.udRXGain11.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain11.Location = new System.Drawing.Point(590, 312);
            this.udRXGain11.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain11.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain11.Name = "udRXGain11";
            this.udRXGain11.Size = new System.Drawing.Size(56, 20);
            this.udRXGain11.TabIndex = 140;
            this.udRXGain11.TinyStep = false;
            this.udRXGain11.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain11.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain10
            // 
            this.udRXGain10.DecimalPlaces = 1;
            this.udRXGain10.Enabled = false;
            this.udRXGain10.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain10.Location = new System.Drawing.Point(590, 288);
            this.udRXGain10.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain10.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain10.Name = "udRXGain10";
            this.udRXGain10.Size = new System.Drawing.Size(56, 20);
            this.udRXGain10.TabIndex = 128;
            this.udRXGain10.TinyStep = false;
            this.udRXGain10.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain10.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain9
            // 
            this.udRXGain9.DecimalPlaces = 1;
            this.udRXGain9.Enabled = false;
            this.udRXGain9.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain9.Location = new System.Drawing.Point(590, 264);
            this.udRXGain9.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain9.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain9.Name = "udRXGain9";
            this.udRXGain9.Size = new System.Drawing.Size(56, 20);
            this.udRXGain9.TabIndex = 116;
            this.udRXGain9.TinyStep = false;
            this.udRXGain9.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain9.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain8
            // 
            this.udRXGain8.DecimalPlaces = 1;
            this.udRXGain8.Enabled = false;
            this.udRXGain8.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain8.Location = new System.Drawing.Point(590, 240);
            this.udRXGain8.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain8.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain8.Name = "udRXGain8";
            this.udRXGain8.Size = new System.Drawing.Size(56, 20);
            this.udRXGain8.TabIndex = 104;
            this.udRXGain8.TinyStep = false;
            this.udRXGain8.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain8.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain7
            // 
            this.udRXGain7.DecimalPlaces = 1;
            this.udRXGain7.Enabled = false;
            this.udRXGain7.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain7.Location = new System.Drawing.Point(590, 216);
            this.udRXGain7.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain7.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain7.Name = "udRXGain7";
            this.udRXGain7.Size = new System.Drawing.Size(56, 20);
            this.udRXGain7.TabIndex = 92;
            this.udRXGain7.TinyStep = false;
            this.udRXGain7.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain7.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain6
            // 
            this.udRXGain6.DecimalPlaces = 1;
            this.udRXGain6.Enabled = false;
            this.udRXGain6.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain6.Location = new System.Drawing.Point(590, 192);
            this.udRXGain6.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain6.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain6.Name = "udRXGain6";
            this.udRXGain6.Size = new System.Drawing.Size(56, 20);
            this.udRXGain6.TabIndex = 80;
            this.udRXGain6.TinyStep = false;
            this.udRXGain6.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain6.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain5
            // 
            this.udRXGain5.DecimalPlaces = 1;
            this.udRXGain5.Enabled = false;
            this.udRXGain5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain5.Location = new System.Drawing.Point(590, 168);
            this.udRXGain5.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain5.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain5.Name = "udRXGain5";
            this.udRXGain5.Size = new System.Drawing.Size(56, 20);
            this.udRXGain5.TabIndex = 68;
            this.udRXGain5.TinyStep = false;
            this.udRXGain5.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain5.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain4
            // 
            this.udRXGain4.DecimalPlaces = 1;
            this.udRXGain4.Enabled = false;
            this.udRXGain4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain4.Location = new System.Drawing.Point(590, 144);
            this.udRXGain4.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain4.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain4.Name = "udRXGain4";
            this.udRXGain4.Size = new System.Drawing.Size(56, 20);
            this.udRXGain4.TabIndex = 56;
            this.udRXGain4.TinyStep = false;
            this.udRXGain4.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain4.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain3
            // 
            this.udRXGain3.DecimalPlaces = 1;
            this.udRXGain3.Enabled = false;
            this.udRXGain3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain3.Location = new System.Drawing.Point(590, 120);
            this.udRXGain3.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain3.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain3.Name = "udRXGain3";
            this.udRXGain3.Size = new System.Drawing.Size(56, 20);
            this.udRXGain3.TabIndex = 44;
            this.udRXGain3.TinyStep = false;
            this.udRXGain3.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain3.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain2
            // 
            this.udRXGain2.DecimalPlaces = 1;
            this.udRXGain2.Enabled = false;
            this.udRXGain2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain2.Location = new System.Drawing.Point(590, 96);
            this.udRXGain2.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain2.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain2.Name = "udRXGain2";
            this.udRXGain2.Size = new System.Drawing.Size(56, 20);
            this.udRXGain2.TabIndex = 32;
            this.udRXGain2.TinyStep = false;
            this.udRXGain2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain2.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain1
            // 
            this.udRXGain1.DecimalPlaces = 1;
            this.udRXGain1.Enabled = false;
            this.udRXGain1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain1.Location = new System.Drawing.Point(590, 72);
            this.udRXGain1.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain1.Name = "udRXGain1";
            this.udRXGain1.Size = new System.Drawing.Size(56, 20);
            this.udRXGain1.TabIndex = 20;
            this.udRXGain1.TinyStep = false;
            this.udRXGain1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain1.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // udRXGain0
            // 
            this.udRXGain0.DecimalPlaces = 1;
            this.udRXGain0.Enabled = false;
            this.udRXGain0.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udRXGain0.Location = new System.Drawing.Point(590, 48);
            this.udRXGain0.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udRXGain0.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.udRXGain0.Name = "udRXGain0";
            this.udRXGain0.Size = new System.Drawing.Size(56, 20);
            this.udRXGain0.TabIndex = 8;
            this.udRXGain0.TinyStep = false;
            this.udRXGain0.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udRXGain0.ValueChanged += new System.EventHandler(this.udRXGain_ValueChanged);
            // 
            // lblRXGain
            // 
            this.lblRXGain.Image = null;
            this.lblRXGain.Location = new System.Drawing.Point(590, 16);
            this.lblRXGain.Name = "lblRXGain";
            this.lblRXGain.Size = new System.Drawing.Size(56, 32);
            this.lblRXGain.TabIndex = 187;
            this.lblRXGain.Text = "RX Gain (dB)";
            // 
            // chkXVTRRF15
            // 
            this.chkXVTRRF15.Checked = true;
            this.chkXVTRRF15.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF15.Enabled = false;
            this.chkXVTRRF15.Image = null;
            this.chkXVTRRF15.Location = new System.Drawing.Point(774, 408);
            this.chkXVTRRF15.Name = "chkXVTRRF15";
            this.chkXVTRRF15.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF15.TabIndex = 191;
            this.chkXVTRRF15.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF14
            // 
            this.chkXVTRRF14.Checked = true;
            this.chkXVTRRF14.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF14.Enabled = false;
            this.chkXVTRRF14.Image = null;
            this.chkXVTRRF14.Location = new System.Drawing.Point(774, 384);
            this.chkXVTRRF14.Name = "chkXVTRRF14";
            this.chkXVTRRF14.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF14.TabIndex = 179;
            this.chkXVTRRF14.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF13
            // 
            this.chkXVTRRF13.Checked = true;
            this.chkXVTRRF13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF13.Enabled = false;
            this.chkXVTRRF13.Image = null;
            this.chkXVTRRF13.Location = new System.Drawing.Point(774, 360);
            this.chkXVTRRF13.Name = "chkXVTRRF13";
            this.chkXVTRRF13.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF13.TabIndex = 167;
            this.chkXVTRRF13.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF12
            // 
            this.chkXVTRRF12.Checked = true;
            this.chkXVTRRF12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF12.Enabled = false;
            this.chkXVTRRF12.Image = null;
            this.chkXVTRRF12.Location = new System.Drawing.Point(774, 336);
            this.chkXVTRRF12.Name = "chkXVTRRF12";
            this.chkXVTRRF12.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF12.TabIndex = 155;
            this.chkXVTRRF12.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF11
            // 
            this.chkXVTRRF11.Checked = true;
            this.chkXVTRRF11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF11.Enabled = false;
            this.chkXVTRRF11.Image = null;
            this.chkXVTRRF11.Location = new System.Drawing.Point(774, 312);
            this.chkXVTRRF11.Name = "chkXVTRRF11";
            this.chkXVTRRF11.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF11.TabIndex = 143;
            this.chkXVTRRF11.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF10
            // 
            this.chkXVTRRF10.Checked = true;
            this.chkXVTRRF10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF10.Enabled = false;
            this.chkXVTRRF10.Image = null;
            this.chkXVTRRF10.Location = new System.Drawing.Point(774, 288);
            this.chkXVTRRF10.Name = "chkXVTRRF10";
            this.chkXVTRRF10.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF10.TabIndex = 131;
            this.chkXVTRRF10.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF9
            // 
            this.chkXVTRRF9.Checked = true;
            this.chkXVTRRF9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF9.Enabled = false;
            this.chkXVTRRF9.Image = null;
            this.chkXVTRRF9.Location = new System.Drawing.Point(774, 264);
            this.chkXVTRRF9.Name = "chkXVTRRF9";
            this.chkXVTRRF9.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF9.TabIndex = 119;
            this.chkXVTRRF9.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF8
            // 
            this.chkXVTRRF8.Checked = true;
            this.chkXVTRRF8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF8.Enabled = false;
            this.chkXVTRRF8.Image = null;
            this.chkXVTRRF8.Location = new System.Drawing.Point(774, 240);
            this.chkXVTRRF8.Name = "chkXVTRRF8";
            this.chkXVTRRF8.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF8.TabIndex = 107;
            this.chkXVTRRF8.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF7
            // 
            this.chkXVTRRF7.Checked = true;
            this.chkXVTRRF7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF7.Enabled = false;
            this.chkXVTRRF7.Image = null;
            this.chkXVTRRF7.Location = new System.Drawing.Point(774, 216);
            this.chkXVTRRF7.Name = "chkXVTRRF7";
            this.chkXVTRRF7.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF7.TabIndex = 95;
            this.chkXVTRRF7.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF6
            // 
            this.chkXVTRRF6.Checked = true;
            this.chkXVTRRF6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF6.Enabled = false;
            this.chkXVTRRF6.Image = null;
            this.chkXVTRRF6.Location = new System.Drawing.Point(774, 192);
            this.chkXVTRRF6.Name = "chkXVTRRF6";
            this.chkXVTRRF6.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF6.TabIndex = 83;
            this.chkXVTRRF6.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF5
            // 
            this.chkXVTRRF5.Checked = true;
            this.chkXVTRRF5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF5.Enabled = false;
            this.chkXVTRRF5.Image = null;
            this.chkXVTRRF5.Location = new System.Drawing.Point(774, 168);
            this.chkXVTRRF5.Name = "chkXVTRRF5";
            this.chkXVTRRF5.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF5.TabIndex = 71;
            this.chkXVTRRF5.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF4
            // 
            this.chkXVTRRF4.Checked = true;
            this.chkXVTRRF4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF4.Enabled = false;
            this.chkXVTRRF4.Image = null;
            this.chkXVTRRF4.Location = new System.Drawing.Point(774, 144);
            this.chkXVTRRF4.Name = "chkXVTRRF4";
            this.chkXVTRRF4.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF4.TabIndex = 59;
            this.chkXVTRRF4.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF3
            // 
            this.chkXVTRRF3.Checked = true;
            this.chkXVTRRF3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF3.Enabled = false;
            this.chkXVTRRF3.Image = null;
            this.chkXVTRRF3.Location = new System.Drawing.Point(774, 120);
            this.chkXVTRRF3.Name = "chkXVTRRF3";
            this.chkXVTRRF3.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF3.TabIndex = 47;
            this.chkXVTRRF3.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF2
            // 
            this.chkXVTRRF2.Checked = true;
            this.chkXVTRRF2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF2.Enabled = false;
            this.chkXVTRRF2.Image = null;
            this.chkXVTRRF2.Location = new System.Drawing.Point(774, 96);
            this.chkXVTRRF2.Name = "chkXVTRRF2";
            this.chkXVTRRF2.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF2.TabIndex = 35;
            this.chkXVTRRF2.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF1
            // 
            this.chkXVTRRF1.Checked = true;
            this.chkXVTRRF1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF1.Enabled = false;
            this.chkXVTRRF1.Image = null;
            this.chkXVTRRF1.Location = new System.Drawing.Point(774, 72);
            this.chkXVTRRF1.Name = "chkXVTRRF1";
            this.chkXVTRRF1.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF1.TabIndex = 23;
            this.chkXVTRRF1.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // chkXVTRRF0
            // 
            this.chkXVTRRF0.Checked = true;
            this.chkXVTRRF0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXVTRRF0.Enabled = false;
            this.chkXVTRRF0.Image = null;
            this.chkXVTRRF0.Location = new System.Drawing.Point(774, 48);
            this.chkXVTRRF0.Name = "chkXVTRRF0";
            this.chkXVTRRF0.Size = new System.Drawing.Size(16, 16);
            this.chkXVTRRF0.TabIndex = 11;
            this.chkXVTRRF0.CheckedChanged += new System.EventHandler(this.chkXVTRRF_CheckedChanged);
            // 
            // lblXVTRRF
            // 
            this.lblXVTRRF.Image = null;
            this.lblXVTRRF.Location = new System.Drawing.Point(766, 16);
            this.lblXVTRRF.Name = "lblXVTRRF";
            this.lblXVTRRF.Size = new System.Drawing.Size(40, 32);
            this.lblXVTRRF.TabIndex = 170;
            this.lblXVTRRF.Text = "XVTR RF TX";
            // 
            // udPower15
            // 
            this.udPower15.Enabled = false;
            this.udPower15.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower15.Location = new System.Drawing.Point(710, 408);
            this.udPower15.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower15.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower15.Name = "udPower15";
            this.udPower15.Size = new System.Drawing.Size(45, 20);
            this.udPower15.TabIndex = 190;
            this.udPower15.TinyStep = false;
            this.udPower15.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower15.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower14
            // 
            this.udPower14.Enabled = false;
            this.udPower14.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower14.Location = new System.Drawing.Point(710, 384);
            this.udPower14.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower14.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower14.Name = "udPower14";
            this.udPower14.Size = new System.Drawing.Size(45, 20);
            this.udPower14.TabIndex = 178;
            this.udPower14.TinyStep = false;
            this.udPower14.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower14.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower13
            // 
            this.udPower13.Enabled = false;
            this.udPower13.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower13.Location = new System.Drawing.Point(710, 360);
            this.udPower13.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower13.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower13.Name = "udPower13";
            this.udPower13.Size = new System.Drawing.Size(45, 20);
            this.udPower13.TabIndex = 166;
            this.udPower13.TinyStep = false;
            this.udPower13.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower13.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower12
            // 
            this.udPower12.Enabled = false;
            this.udPower12.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower12.Location = new System.Drawing.Point(710, 336);
            this.udPower12.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower12.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower12.Name = "udPower12";
            this.udPower12.Size = new System.Drawing.Size(45, 20);
            this.udPower12.TabIndex = 154;
            this.udPower12.TinyStep = false;
            this.udPower12.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower12.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower11
            // 
            this.udPower11.Enabled = false;
            this.udPower11.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower11.Location = new System.Drawing.Point(710, 312);
            this.udPower11.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower11.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower11.Name = "udPower11";
            this.udPower11.Size = new System.Drawing.Size(45, 20);
            this.udPower11.TabIndex = 142;
            this.udPower11.TinyStep = false;
            this.udPower11.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower11.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower10
            // 
            this.udPower10.Enabled = false;
            this.udPower10.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower10.Location = new System.Drawing.Point(710, 288);
            this.udPower10.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower10.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower10.Name = "udPower10";
            this.udPower10.Size = new System.Drawing.Size(45, 20);
            this.udPower10.TabIndex = 130;
            this.udPower10.TinyStep = false;
            this.udPower10.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower10.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower9
            // 
            this.udPower9.Enabled = false;
            this.udPower9.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower9.Location = new System.Drawing.Point(710, 264);
            this.udPower9.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower9.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower9.Name = "udPower9";
            this.udPower9.Size = new System.Drawing.Size(45, 20);
            this.udPower9.TabIndex = 118;
            this.udPower9.TinyStep = false;
            this.udPower9.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower9.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower8
            // 
            this.udPower8.Enabled = false;
            this.udPower8.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower8.Location = new System.Drawing.Point(710, 240);
            this.udPower8.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower8.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower8.Name = "udPower8";
            this.udPower8.Size = new System.Drawing.Size(45, 20);
            this.udPower8.TabIndex = 106;
            this.udPower8.TinyStep = false;
            this.udPower8.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower8.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower7
            // 
            this.udPower7.Enabled = false;
            this.udPower7.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower7.Location = new System.Drawing.Point(710, 216);
            this.udPower7.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower7.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower7.Name = "udPower7";
            this.udPower7.Size = new System.Drawing.Size(45, 20);
            this.udPower7.TabIndex = 94;
            this.udPower7.TinyStep = false;
            this.udPower7.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower7.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower6
            // 
            this.udPower6.Enabled = false;
            this.udPower6.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower6.Location = new System.Drawing.Point(710, 192);
            this.udPower6.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower6.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower6.Name = "udPower6";
            this.udPower6.Size = new System.Drawing.Size(45, 20);
            this.udPower6.TabIndex = 82;
            this.udPower6.TinyStep = false;
            this.udPower6.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower6.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower5
            // 
            this.udPower5.Enabled = false;
            this.udPower5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower5.Location = new System.Drawing.Point(710, 168);
            this.udPower5.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower5.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower5.Name = "udPower5";
            this.udPower5.Size = new System.Drawing.Size(45, 20);
            this.udPower5.TabIndex = 70;
            this.udPower5.TinyStep = false;
            this.udPower5.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower5.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower4
            // 
            this.udPower4.Enabled = false;
            this.udPower4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower4.Location = new System.Drawing.Point(710, 144);
            this.udPower4.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower4.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower4.Name = "udPower4";
            this.udPower4.Size = new System.Drawing.Size(45, 20);
            this.udPower4.TabIndex = 58;
            this.udPower4.TinyStep = false;
            this.udPower4.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower4.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower3
            // 
            this.udPower3.Enabled = false;
            this.udPower3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower3.Location = new System.Drawing.Point(710, 120);
            this.udPower3.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower3.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower3.Name = "udPower3";
            this.udPower3.Size = new System.Drawing.Size(45, 20);
            this.udPower3.TabIndex = 46;
            this.udPower3.TinyStep = false;
            this.udPower3.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower3.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower2
            // 
            this.udPower2.Enabled = false;
            this.udPower2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower2.Location = new System.Drawing.Point(710, 96);
            this.udPower2.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower2.Name = "udPower2";
            this.udPower2.Size = new System.Drawing.Size(45, 20);
            this.udPower2.TabIndex = 34;
            this.udPower2.TinyStep = false;
            this.udPower2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower2.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower1
            // 
            this.udPower1.Enabled = false;
            this.udPower1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower1.Location = new System.Drawing.Point(710, 72);
            this.udPower1.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower1.Name = "udPower1";
            this.udPower1.Size = new System.Drawing.Size(45, 20);
            this.udPower1.TabIndex = 22;
            this.udPower1.TinyStep = false;
            this.udPower1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower1.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // udPower0
            // 
            this.udPower0.Enabled = false;
            this.udPower0.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPower0.Location = new System.Drawing.Point(710, 48);
            this.udPower0.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower0.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udPower0.Name = "udPower0";
            this.udPower0.Size = new System.Drawing.Size(45, 20);
            this.udPower0.TabIndex = 10;
            this.udPower0.TinyStep = false;
            this.udPower0.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udPower0.ValueChanged += new System.EventHandler(this.udPower_ValueChanged);
            // 
            // lblPower
            // 
            this.lblPower.Image = null;
            this.lblPower.Location = new System.Drawing.Point(710, 24);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(40, 16);
            this.lblPower.TabIndex = 153;
            this.lblPower.Text = "Power";
            // 
            // udLOError15
            // 
            this.udLOError15.DecimalPlaces = 3;
            this.udLOError15.Enabled = false;
            this.udLOError15.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError15.Location = new System.Drawing.Point(318, 408);
            this.udLOError15.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError15.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError15.Name = "udLOError15";
            this.udLOError15.Size = new System.Drawing.Size(56, 20);
            this.udLOError15.TabIndex = 185;
            this.udLOError15.TinyStep = false;
            this.udLOError15.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError14
            // 
            this.udLOError14.DecimalPlaces = 3;
            this.udLOError14.Enabled = false;
            this.udLOError14.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError14.Location = new System.Drawing.Point(318, 384);
            this.udLOError14.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError14.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError14.Name = "udLOError14";
            this.udLOError14.Size = new System.Drawing.Size(56, 20);
            this.udLOError14.TabIndex = 173;
            this.udLOError14.TinyStep = false;
            this.udLOError14.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError13
            // 
            this.udLOError13.DecimalPlaces = 3;
            this.udLOError13.Enabled = false;
            this.udLOError13.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError13.Location = new System.Drawing.Point(318, 360);
            this.udLOError13.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError13.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError13.Name = "udLOError13";
            this.udLOError13.Size = new System.Drawing.Size(56, 20);
            this.udLOError13.TabIndex = 161;
            this.udLOError13.TinyStep = false;
            this.udLOError13.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError12
            // 
            this.udLOError12.DecimalPlaces = 3;
            this.udLOError12.Enabled = false;
            this.udLOError12.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError12.Location = new System.Drawing.Point(318, 336);
            this.udLOError12.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError12.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError12.Name = "udLOError12";
            this.udLOError12.Size = new System.Drawing.Size(56, 20);
            this.udLOError12.TabIndex = 149;
            this.udLOError12.TinyStep = false;
            this.udLOError12.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError11
            // 
            this.udLOError11.DecimalPlaces = 3;
            this.udLOError11.Enabled = false;
            this.udLOError11.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError11.Location = new System.Drawing.Point(318, 312);
            this.udLOError11.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError11.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError11.Name = "udLOError11";
            this.udLOError11.Size = new System.Drawing.Size(56, 20);
            this.udLOError11.TabIndex = 137;
            this.udLOError11.TinyStep = false;
            this.udLOError11.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError10
            // 
            this.udLOError10.DecimalPlaces = 3;
            this.udLOError10.Enabled = false;
            this.udLOError10.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError10.Location = new System.Drawing.Point(318, 288);
            this.udLOError10.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError10.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError10.Name = "udLOError10";
            this.udLOError10.Size = new System.Drawing.Size(56, 20);
            this.udLOError10.TabIndex = 125;
            this.udLOError10.TinyStep = false;
            this.udLOError10.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError9
            // 
            this.udLOError9.DecimalPlaces = 3;
            this.udLOError9.Enabled = false;
            this.udLOError9.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError9.Location = new System.Drawing.Point(318, 264);
            this.udLOError9.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError9.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError9.Name = "udLOError9";
            this.udLOError9.Size = new System.Drawing.Size(56, 20);
            this.udLOError9.TabIndex = 113;
            this.udLOError9.TinyStep = false;
            this.udLOError9.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError8
            // 
            this.udLOError8.DecimalPlaces = 3;
            this.udLOError8.Enabled = false;
            this.udLOError8.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError8.Location = new System.Drawing.Point(318, 240);
            this.udLOError8.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError8.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError8.Name = "udLOError8";
            this.udLOError8.Size = new System.Drawing.Size(56, 20);
            this.udLOError8.TabIndex = 101;
            this.udLOError8.TinyStep = false;
            this.udLOError8.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError7
            // 
            this.udLOError7.DecimalPlaces = 3;
            this.udLOError7.Enabled = false;
            this.udLOError7.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError7.Location = new System.Drawing.Point(318, 216);
            this.udLOError7.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError7.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError7.Name = "udLOError7";
            this.udLOError7.Size = new System.Drawing.Size(56, 20);
            this.udLOError7.TabIndex = 89;
            this.udLOError7.TinyStep = false;
            this.udLOError7.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError6
            // 
            this.udLOError6.DecimalPlaces = 3;
            this.udLOError6.Enabled = false;
            this.udLOError6.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError6.Location = new System.Drawing.Point(318, 192);
            this.udLOError6.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError6.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError6.Name = "udLOError6";
            this.udLOError6.Size = new System.Drawing.Size(56, 20);
            this.udLOError6.TabIndex = 77;
            this.udLOError6.TinyStep = false;
            this.udLOError6.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError5
            // 
            this.udLOError5.DecimalPlaces = 3;
            this.udLOError5.Enabled = false;
            this.udLOError5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError5.Location = new System.Drawing.Point(318, 168);
            this.udLOError5.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError5.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError5.Name = "udLOError5";
            this.udLOError5.Size = new System.Drawing.Size(56, 20);
            this.udLOError5.TabIndex = 65;
            this.udLOError5.TinyStep = false;
            this.udLOError5.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError4
            // 
            this.udLOError4.DecimalPlaces = 3;
            this.udLOError4.Enabled = false;
            this.udLOError4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError4.Location = new System.Drawing.Point(318, 144);
            this.udLOError4.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError4.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError4.Name = "udLOError4";
            this.udLOError4.Size = new System.Drawing.Size(56, 20);
            this.udLOError4.TabIndex = 53;
            this.udLOError4.TinyStep = false;
            this.udLOError4.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError3
            // 
            this.udLOError3.DecimalPlaces = 3;
            this.udLOError3.Enabled = false;
            this.udLOError3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError3.Location = new System.Drawing.Point(318, 120);
            this.udLOError3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError3.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError3.Name = "udLOError3";
            this.udLOError3.Size = new System.Drawing.Size(56, 20);
            this.udLOError3.TabIndex = 41;
            this.udLOError3.TinyStep = false;
            this.udLOError3.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError2
            // 
            this.udLOError2.DecimalPlaces = 3;
            this.udLOError2.Enabled = false;
            this.udLOError2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError2.Location = new System.Drawing.Point(318, 96);
            this.udLOError2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError2.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError2.Name = "udLOError2";
            this.udLOError2.Size = new System.Drawing.Size(56, 20);
            this.udLOError2.TabIndex = 29;
            this.udLOError2.TinyStep = false;
            this.udLOError2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError1
            // 
            this.udLOError1.DecimalPlaces = 3;
            this.udLOError1.Enabled = false;
            this.udLOError1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError1.Location = new System.Drawing.Point(318, 72);
            this.udLOError1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError1.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError1.Name = "udLOError1";
            this.udLOError1.Size = new System.Drawing.Size(56, 20);
            this.udLOError1.TabIndex = 17;
            this.udLOError1.TinyStep = false;
            this.udLOError1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOError0
            // 
            this.udLOError0.DecimalPlaces = 3;
            this.udLOError0.Enabled = false;
            this.udLOError0.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOError0.Location = new System.Drawing.Point(318, 48);
            this.udLOError0.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udLOError0.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.udLOError0.Name = "udLOError0";
            this.udLOError0.Size = new System.Drawing.Size(56, 20);
            this.udLOError0.TabIndex = 5;
            this.udLOError0.TinyStep = false;
            this.udLOError0.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblLOError
            // 
            this.lblLOError.Image = null;
            this.lblLOError.Location = new System.Drawing.Point(318, 16);
            this.lblLOError.Name = "lblLOError";
            this.lblLOError.Size = new System.Drawing.Size(56, 32);
            this.lblLOError.TabIndex = 136;
            this.lblLOError.Text = "LO Error (kHz)";
            // 
            // chkRXOnly15
            // 
            this.chkRXOnly15.Enabled = false;
            this.chkRXOnly15.Image = null;
            this.chkRXOnly15.Location = new System.Drawing.Point(670, 408);
            this.chkRXOnly15.Name = "chkRXOnly15";
            this.chkRXOnly15.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly15.TabIndex = 189;
            // 
            // chkRXOnly14
            // 
            this.chkRXOnly14.Enabled = false;
            this.chkRXOnly14.Image = null;
            this.chkRXOnly14.Location = new System.Drawing.Point(670, 384);
            this.chkRXOnly14.Name = "chkRXOnly14";
            this.chkRXOnly14.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly14.TabIndex = 177;
            // 
            // chkRXOnly13
            // 
            this.chkRXOnly13.Enabled = false;
            this.chkRXOnly13.Image = null;
            this.chkRXOnly13.Location = new System.Drawing.Point(670, 360);
            this.chkRXOnly13.Name = "chkRXOnly13";
            this.chkRXOnly13.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly13.TabIndex = 165;
            // 
            // chkRXOnly12
            // 
            this.chkRXOnly12.Enabled = false;
            this.chkRXOnly12.Image = null;
            this.chkRXOnly12.Location = new System.Drawing.Point(670, 336);
            this.chkRXOnly12.Name = "chkRXOnly12";
            this.chkRXOnly12.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly12.TabIndex = 153;
            // 
            // chkRXOnly11
            // 
            this.chkRXOnly11.Enabled = false;
            this.chkRXOnly11.Image = null;
            this.chkRXOnly11.Location = new System.Drawing.Point(670, 312);
            this.chkRXOnly11.Name = "chkRXOnly11";
            this.chkRXOnly11.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly11.TabIndex = 141;
            // 
            // chkRXOnly10
            // 
            this.chkRXOnly10.Enabled = false;
            this.chkRXOnly10.Image = null;
            this.chkRXOnly10.Location = new System.Drawing.Point(670, 288);
            this.chkRXOnly10.Name = "chkRXOnly10";
            this.chkRXOnly10.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly10.TabIndex = 129;
            // 
            // chkRXOnly9
            // 
            this.chkRXOnly9.Enabled = false;
            this.chkRXOnly9.Image = null;
            this.chkRXOnly9.Location = new System.Drawing.Point(670, 264);
            this.chkRXOnly9.Name = "chkRXOnly9";
            this.chkRXOnly9.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly9.TabIndex = 117;
            // 
            // chkRXOnly8
            // 
            this.chkRXOnly8.Enabled = false;
            this.chkRXOnly8.Image = null;
            this.chkRXOnly8.Location = new System.Drawing.Point(670, 240);
            this.chkRXOnly8.Name = "chkRXOnly8";
            this.chkRXOnly8.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly8.TabIndex = 105;
            // 
            // chkRXOnly7
            // 
            this.chkRXOnly7.Enabled = false;
            this.chkRXOnly7.Image = null;
            this.chkRXOnly7.Location = new System.Drawing.Point(670, 216);
            this.chkRXOnly7.Name = "chkRXOnly7";
            this.chkRXOnly7.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly7.TabIndex = 93;
            // 
            // chkRXOnly6
            // 
            this.chkRXOnly6.Enabled = false;
            this.chkRXOnly6.Image = null;
            this.chkRXOnly6.Location = new System.Drawing.Point(670, 192);
            this.chkRXOnly6.Name = "chkRXOnly6";
            this.chkRXOnly6.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly6.TabIndex = 81;
            // 
            // chkRXOnly5
            // 
            this.chkRXOnly5.Enabled = false;
            this.chkRXOnly5.Image = null;
            this.chkRXOnly5.Location = new System.Drawing.Point(670, 168);
            this.chkRXOnly5.Name = "chkRXOnly5";
            this.chkRXOnly5.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly5.TabIndex = 69;
            // 
            // chkRXOnly4
            // 
            this.chkRXOnly4.Enabled = false;
            this.chkRXOnly4.Image = null;
            this.chkRXOnly4.Location = new System.Drawing.Point(670, 144);
            this.chkRXOnly4.Name = "chkRXOnly4";
            this.chkRXOnly4.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly4.TabIndex = 57;
            // 
            // chkRXOnly3
            // 
            this.chkRXOnly3.Enabled = false;
            this.chkRXOnly3.Image = null;
            this.chkRXOnly3.Location = new System.Drawing.Point(670, 120);
            this.chkRXOnly3.Name = "chkRXOnly3";
            this.chkRXOnly3.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly3.TabIndex = 45;
            // 
            // chkRXOnly2
            // 
            this.chkRXOnly2.Enabled = false;
            this.chkRXOnly2.Image = null;
            this.chkRXOnly2.Location = new System.Drawing.Point(670, 96);
            this.chkRXOnly2.Name = "chkRXOnly2";
            this.chkRXOnly2.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly2.TabIndex = 33;
            // 
            // chkRXOnly1
            // 
            this.chkRXOnly1.Enabled = false;
            this.chkRXOnly1.Image = null;
            this.chkRXOnly1.Location = new System.Drawing.Point(670, 72);
            this.chkRXOnly1.Name = "chkRXOnly1";
            this.chkRXOnly1.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly1.TabIndex = 21;
            // 
            // chkRXOnly0
            // 
            this.chkRXOnly0.Enabled = false;
            this.chkRXOnly0.Image = null;
            this.chkRXOnly0.Location = new System.Drawing.Point(670, 48);
            this.chkRXOnly0.Name = "chkRXOnly0";
            this.chkRXOnly0.Size = new System.Drawing.Size(16, 16);
            this.chkRXOnly0.TabIndex = 9;
            // 
            // lblRXOnly
            // 
            this.lblRXOnly.Image = null;
            this.lblRXOnly.Location = new System.Drawing.Point(654, 24);
            this.lblRXOnly.Name = "lblRXOnly";
            this.lblRXOnly.Size = new System.Drawing.Size(48, 16);
            this.lblRXOnly.TabIndex = 119;
            this.lblRXOnly.Text = "RX Only";
            // 
            // udFreqEnd15
            // 
            this.udFreqEnd15.DecimalPlaces = 6;
            this.udFreqEnd15.Enabled = false;
            this.udFreqEnd15.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd15.Location = new System.Drawing.Point(486, 408);
            this.udFreqEnd15.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd15.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd15.Name = "udFreqEnd15";
            this.udFreqEnd15.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd15.TabIndex = 187;
            this.udFreqEnd15.TinyStep = false;
            this.udFreqEnd15.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd14
            // 
            this.udFreqEnd14.DecimalPlaces = 6;
            this.udFreqEnd14.Enabled = false;
            this.udFreqEnd14.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd14.Location = new System.Drawing.Point(486, 384);
            this.udFreqEnd14.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd14.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd14.Name = "udFreqEnd14";
            this.udFreqEnd14.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd14.TabIndex = 175;
            this.udFreqEnd14.TinyStep = false;
            this.udFreqEnd14.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd13
            // 
            this.udFreqEnd13.DecimalPlaces = 6;
            this.udFreqEnd13.Enabled = false;
            this.udFreqEnd13.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd13.Location = new System.Drawing.Point(486, 360);
            this.udFreqEnd13.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd13.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd13.Name = "udFreqEnd13";
            this.udFreqEnd13.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd13.TabIndex = 163;
            this.udFreqEnd13.TinyStep = false;
            this.udFreqEnd13.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd12
            // 
            this.udFreqEnd12.DecimalPlaces = 6;
            this.udFreqEnd12.Enabled = false;
            this.udFreqEnd12.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd12.Location = new System.Drawing.Point(486, 336);
            this.udFreqEnd12.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd12.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd12.Name = "udFreqEnd12";
            this.udFreqEnd12.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd12.TabIndex = 151;
            this.udFreqEnd12.TinyStep = false;
            this.udFreqEnd12.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd11
            // 
            this.udFreqEnd11.DecimalPlaces = 6;
            this.udFreqEnd11.Enabled = false;
            this.udFreqEnd11.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd11.Location = new System.Drawing.Point(486, 312);
            this.udFreqEnd11.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd11.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd11.Name = "udFreqEnd11";
            this.udFreqEnd11.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd11.TabIndex = 139;
            this.udFreqEnd11.TinyStep = false;
            this.udFreqEnd11.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd10
            // 
            this.udFreqEnd10.DecimalPlaces = 6;
            this.udFreqEnd10.Enabled = false;
            this.udFreqEnd10.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd10.Location = new System.Drawing.Point(486, 288);
            this.udFreqEnd10.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd10.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd10.Name = "udFreqEnd10";
            this.udFreqEnd10.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd10.TabIndex = 127;
            this.udFreqEnd10.TinyStep = false;
            this.udFreqEnd10.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd9
            // 
            this.udFreqEnd9.DecimalPlaces = 6;
            this.udFreqEnd9.Enabled = false;
            this.udFreqEnd9.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd9.Location = new System.Drawing.Point(486, 264);
            this.udFreqEnd9.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd9.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd9.Name = "udFreqEnd9";
            this.udFreqEnd9.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd9.TabIndex = 115;
            this.udFreqEnd9.TinyStep = false;
            this.udFreqEnd9.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd8
            // 
            this.udFreqEnd8.DecimalPlaces = 6;
            this.udFreqEnd8.Enabled = false;
            this.udFreqEnd8.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd8.Location = new System.Drawing.Point(486, 240);
            this.udFreqEnd8.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd8.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd8.Name = "udFreqEnd8";
            this.udFreqEnd8.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd8.TabIndex = 103;
            this.udFreqEnd8.TinyStep = false;
            this.udFreqEnd8.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd7
            // 
            this.udFreqEnd7.DecimalPlaces = 6;
            this.udFreqEnd7.Enabled = false;
            this.udFreqEnd7.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd7.Location = new System.Drawing.Point(486, 216);
            this.udFreqEnd7.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd7.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd7.Name = "udFreqEnd7";
            this.udFreqEnd7.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd7.TabIndex = 91;
            this.udFreqEnd7.TinyStep = false;
            this.udFreqEnd7.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd6
            // 
            this.udFreqEnd6.DecimalPlaces = 6;
            this.udFreqEnd6.Enabled = false;
            this.udFreqEnd6.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd6.Location = new System.Drawing.Point(486, 192);
            this.udFreqEnd6.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd6.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd6.Name = "udFreqEnd6";
            this.udFreqEnd6.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd6.TabIndex = 79;
            this.udFreqEnd6.TinyStep = false;
            this.udFreqEnd6.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd5
            // 
            this.udFreqEnd5.DecimalPlaces = 6;
            this.udFreqEnd5.Enabled = false;
            this.udFreqEnd5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd5.Location = new System.Drawing.Point(486, 168);
            this.udFreqEnd5.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd5.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd5.Name = "udFreqEnd5";
            this.udFreqEnd5.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd5.TabIndex = 67;
            this.udFreqEnd5.TinyStep = false;
            this.udFreqEnd5.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd4
            // 
            this.udFreqEnd4.DecimalPlaces = 6;
            this.udFreqEnd4.Enabled = false;
            this.udFreqEnd4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd4.Location = new System.Drawing.Point(486, 144);
            this.udFreqEnd4.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd4.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd4.Name = "udFreqEnd4";
            this.udFreqEnd4.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd4.TabIndex = 55;
            this.udFreqEnd4.TinyStep = false;
            this.udFreqEnd4.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd3
            // 
            this.udFreqEnd3.DecimalPlaces = 6;
            this.udFreqEnd3.Enabled = false;
            this.udFreqEnd3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd3.Location = new System.Drawing.Point(486, 120);
            this.udFreqEnd3.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd3.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd3.Name = "udFreqEnd3";
            this.udFreqEnd3.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd3.TabIndex = 43;
            this.udFreqEnd3.TinyStep = false;
            this.udFreqEnd3.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd2
            // 
            this.udFreqEnd2.DecimalPlaces = 6;
            this.udFreqEnd2.Enabled = false;
            this.udFreqEnd2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd2.Location = new System.Drawing.Point(486, 96);
            this.udFreqEnd2.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd2.Name = "udFreqEnd2";
            this.udFreqEnd2.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd2.TabIndex = 31;
            this.udFreqEnd2.TinyStep = false;
            this.udFreqEnd2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd1
            // 
            this.udFreqEnd1.DecimalPlaces = 6;
            this.udFreqEnd1.Enabled = false;
            this.udFreqEnd1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd1.Location = new System.Drawing.Point(486, 72);
            this.udFreqEnd1.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd1.Name = "udFreqEnd1";
            this.udFreqEnd1.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd1.TabIndex = 19;
            this.udFreqEnd1.TinyStep = false;
            this.udFreqEnd1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqEnd0
            // 
            this.udFreqEnd0.DecimalPlaces = 6;
            this.udFreqEnd0.Enabled = false;
            this.udFreqEnd0.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqEnd0.Location = new System.Drawing.Point(486, 48);
            this.udFreqEnd0.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqEnd0.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqEnd0.Name = "udFreqEnd0";
            this.udFreqEnd0.Size = new System.Drawing.Size(96, 20);
            this.udFreqEnd0.TabIndex = 7;
            this.udFreqEnd0.TinyStep = false;
            this.udFreqEnd0.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblFreqEnd
            // 
            this.lblFreqEnd.Image = null;
            this.lblFreqEnd.Location = new System.Drawing.Point(494, 24);
            this.lblFreqEnd.Name = "lblFreqEnd";
            this.lblFreqEnd.Size = new System.Drawing.Size(88, 16);
            this.lblFreqEnd.TabIndex = 102;
            this.lblFreqEnd.Text = "End Freq (MHz)";
            // 
            // udFreqBegin15
            // 
            this.udFreqBegin15.DecimalPlaces = 6;
            this.udFreqBegin15.Enabled = false;
            this.udFreqBegin15.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin15.Location = new System.Drawing.Point(382, 408);
            this.udFreqBegin15.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin15.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin15.Name = "udFreqBegin15";
            this.udFreqBegin15.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin15.TabIndex = 186;
            this.udFreqBegin15.TinyStep = false;
            this.udFreqBegin15.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin14
            // 
            this.udFreqBegin14.DecimalPlaces = 6;
            this.udFreqBegin14.Enabled = false;
            this.udFreqBegin14.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin14.Location = new System.Drawing.Point(382, 384);
            this.udFreqBegin14.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin14.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin14.Name = "udFreqBegin14";
            this.udFreqBegin14.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin14.TabIndex = 174;
            this.udFreqBegin14.TinyStep = false;
            this.udFreqBegin14.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin13
            // 
            this.udFreqBegin13.DecimalPlaces = 6;
            this.udFreqBegin13.Enabled = false;
            this.udFreqBegin13.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin13.Location = new System.Drawing.Point(382, 360);
            this.udFreqBegin13.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin13.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin13.Name = "udFreqBegin13";
            this.udFreqBegin13.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin13.TabIndex = 162;
            this.udFreqBegin13.TinyStep = false;
            this.udFreqBegin13.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin12
            // 
            this.udFreqBegin12.DecimalPlaces = 6;
            this.udFreqBegin12.Enabled = false;
            this.udFreqBegin12.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin12.Location = new System.Drawing.Point(382, 336);
            this.udFreqBegin12.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin12.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin12.Name = "udFreqBegin12";
            this.udFreqBegin12.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin12.TabIndex = 150;
            this.udFreqBegin12.TinyStep = false;
            this.udFreqBegin12.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin11
            // 
            this.udFreqBegin11.DecimalPlaces = 6;
            this.udFreqBegin11.Enabled = false;
            this.udFreqBegin11.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin11.Location = new System.Drawing.Point(382, 312);
            this.udFreqBegin11.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin11.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin11.Name = "udFreqBegin11";
            this.udFreqBegin11.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin11.TabIndex = 138;
            this.udFreqBegin11.TinyStep = false;
            this.udFreqBegin11.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin10
            // 
            this.udFreqBegin10.DecimalPlaces = 6;
            this.udFreqBegin10.Enabled = false;
            this.udFreqBegin10.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin10.Location = new System.Drawing.Point(382, 288);
            this.udFreqBegin10.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin10.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin10.Name = "udFreqBegin10";
            this.udFreqBegin10.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin10.TabIndex = 126;
            this.udFreqBegin10.TinyStep = false;
            this.udFreqBegin10.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin9
            // 
            this.udFreqBegin9.DecimalPlaces = 6;
            this.udFreqBegin9.Enabled = false;
            this.udFreqBegin9.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin9.Location = new System.Drawing.Point(382, 264);
            this.udFreqBegin9.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin9.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin9.Name = "udFreqBegin9";
            this.udFreqBegin9.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin9.TabIndex = 114;
            this.udFreqBegin9.TinyStep = false;
            this.udFreqBegin9.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin8
            // 
            this.udFreqBegin8.DecimalPlaces = 6;
            this.udFreqBegin8.Enabled = false;
            this.udFreqBegin8.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin8.Location = new System.Drawing.Point(382, 240);
            this.udFreqBegin8.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin8.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin8.Name = "udFreqBegin8";
            this.udFreqBegin8.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin8.TabIndex = 102;
            this.udFreqBegin8.TinyStep = false;
            this.udFreqBegin8.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin7
            // 
            this.udFreqBegin7.DecimalPlaces = 6;
            this.udFreqBegin7.Enabled = false;
            this.udFreqBegin7.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin7.Location = new System.Drawing.Point(382, 216);
            this.udFreqBegin7.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin7.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin7.Name = "udFreqBegin7";
            this.udFreqBegin7.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin7.TabIndex = 90;
            this.udFreqBegin7.TinyStep = false;
            this.udFreqBegin7.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin6
            // 
            this.udFreqBegin6.DecimalPlaces = 6;
            this.udFreqBegin6.Enabled = false;
            this.udFreqBegin6.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin6.Location = new System.Drawing.Point(382, 192);
            this.udFreqBegin6.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin6.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin6.Name = "udFreqBegin6";
            this.udFreqBegin6.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin6.TabIndex = 78;
            this.udFreqBegin6.TinyStep = false;
            this.udFreqBegin6.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin5
            // 
            this.udFreqBegin5.DecimalPlaces = 6;
            this.udFreqBegin5.Enabled = false;
            this.udFreqBegin5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin5.Location = new System.Drawing.Point(382, 168);
            this.udFreqBegin5.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin5.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin5.Name = "udFreqBegin5";
            this.udFreqBegin5.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin5.TabIndex = 66;
            this.udFreqBegin5.TinyStep = false;
            this.udFreqBegin5.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin4
            // 
            this.udFreqBegin4.DecimalPlaces = 6;
            this.udFreqBegin4.Enabled = false;
            this.udFreqBegin4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin4.Location = new System.Drawing.Point(382, 144);
            this.udFreqBegin4.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin4.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin4.Name = "udFreqBegin4";
            this.udFreqBegin4.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin4.TabIndex = 54;
            this.udFreqBegin4.TinyStep = false;
            this.udFreqBegin4.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin3
            // 
            this.udFreqBegin3.DecimalPlaces = 6;
            this.udFreqBegin3.Enabled = false;
            this.udFreqBegin3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin3.Location = new System.Drawing.Point(382, 120);
            this.udFreqBegin3.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin3.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin3.Name = "udFreqBegin3";
            this.udFreqBegin3.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin3.TabIndex = 42;
            this.udFreqBegin3.TinyStep = false;
            this.udFreqBegin3.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin2
            // 
            this.udFreqBegin2.DecimalPlaces = 6;
            this.udFreqBegin2.Enabled = false;
            this.udFreqBegin2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin2.Location = new System.Drawing.Point(382, 96);
            this.udFreqBegin2.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin2.Name = "udFreqBegin2";
            this.udFreqBegin2.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin2.TabIndex = 30;
            this.udFreqBegin2.TinyStep = false;
            this.udFreqBegin2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin1
            // 
            this.udFreqBegin1.DecimalPlaces = 6;
            this.udFreqBegin1.Enabled = false;
            this.udFreqBegin1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin1.Location = new System.Drawing.Point(382, 72);
            this.udFreqBegin1.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin1.Name = "udFreqBegin1";
            this.udFreqBegin1.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin1.TabIndex = 18;
            this.udFreqBegin1.TinyStep = false;
            this.udFreqBegin1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udFreqBegin0
            // 
            this.udFreqBegin0.DecimalPlaces = 6;
            this.udFreqBegin0.Enabled = false;
            this.udFreqBegin0.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udFreqBegin0.Location = new System.Drawing.Point(382, 48);
            this.udFreqBegin0.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udFreqBegin0.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.udFreqBegin0.Name = "udFreqBegin0";
            this.udFreqBegin0.Size = new System.Drawing.Size(96, 20);
            this.udFreqBegin0.TabIndex = 6;
            this.udFreqBegin0.TinyStep = false;
            this.udFreqBegin0.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblFreqBegin
            // 
            this.lblFreqBegin.Image = null;
            this.lblFreqBegin.Location = new System.Drawing.Point(382, 24);
            this.lblFreqBegin.Name = "lblFreqBegin";
            this.lblFreqBegin.Size = new System.Drawing.Size(96, 16);
            this.lblFreqBegin.TabIndex = 85;
            this.lblFreqBegin.Text = "Begin Freq (MHz)";
            // 
            // udLOOffset15
            // 
            this.udLOOffset15.DecimalPlaces = 1;
            this.udLOOffset15.Enabled = false;
            this.udLOOffset15.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset15.Location = new System.Drawing.Point(230, 408);
            this.udLOOffset15.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset15.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset15.Name = "udLOOffset15";
            this.udLOOffset15.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset15.TabIndex = 184;
            this.udLOOffset15.TinyStep = false;
            this.udLOOffset15.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset14
            // 
            this.udLOOffset14.DecimalPlaces = 1;
            this.udLOOffset14.Enabled = false;
            this.udLOOffset14.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset14.Location = new System.Drawing.Point(230, 384);
            this.udLOOffset14.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset14.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset14.Name = "udLOOffset14";
            this.udLOOffset14.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset14.TabIndex = 172;
            this.udLOOffset14.TinyStep = false;
            this.udLOOffset14.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset13
            // 
            this.udLOOffset13.DecimalPlaces = 1;
            this.udLOOffset13.Enabled = false;
            this.udLOOffset13.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset13.Location = new System.Drawing.Point(230, 360);
            this.udLOOffset13.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset13.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset13.Name = "udLOOffset13";
            this.udLOOffset13.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset13.TabIndex = 160;
            this.udLOOffset13.TinyStep = false;
            this.udLOOffset13.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset12
            // 
            this.udLOOffset12.DecimalPlaces = 1;
            this.udLOOffset12.Enabled = false;
            this.udLOOffset12.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset12.Location = new System.Drawing.Point(230, 336);
            this.udLOOffset12.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset12.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset12.Name = "udLOOffset12";
            this.udLOOffset12.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset12.TabIndex = 148;
            this.udLOOffset12.TinyStep = false;
            this.udLOOffset12.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset11
            // 
            this.udLOOffset11.DecimalPlaces = 1;
            this.udLOOffset11.Enabled = false;
            this.udLOOffset11.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset11.Location = new System.Drawing.Point(230, 312);
            this.udLOOffset11.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset11.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset11.Name = "udLOOffset11";
            this.udLOOffset11.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset11.TabIndex = 136;
            this.udLOOffset11.TinyStep = false;
            this.udLOOffset11.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset10
            // 
            this.udLOOffset10.DecimalPlaces = 1;
            this.udLOOffset10.Enabled = false;
            this.udLOOffset10.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset10.Location = new System.Drawing.Point(230, 288);
            this.udLOOffset10.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset10.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset10.Name = "udLOOffset10";
            this.udLOOffset10.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset10.TabIndex = 124;
            this.udLOOffset10.TinyStep = false;
            this.udLOOffset10.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset9
            // 
            this.udLOOffset9.DecimalPlaces = 1;
            this.udLOOffset9.Enabled = false;
            this.udLOOffset9.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset9.Location = new System.Drawing.Point(230, 264);
            this.udLOOffset9.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset9.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset9.Name = "udLOOffset9";
            this.udLOOffset9.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset9.TabIndex = 112;
            this.udLOOffset9.TinyStep = false;
            this.udLOOffset9.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset8
            // 
            this.udLOOffset8.DecimalPlaces = 1;
            this.udLOOffset8.Enabled = false;
            this.udLOOffset8.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset8.Location = new System.Drawing.Point(230, 240);
            this.udLOOffset8.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset8.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset8.Name = "udLOOffset8";
            this.udLOOffset8.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset8.TabIndex = 100;
            this.udLOOffset8.TinyStep = false;
            this.udLOOffset8.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset7
            // 
            this.udLOOffset7.DecimalPlaces = 1;
            this.udLOOffset7.Enabled = false;
            this.udLOOffset7.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset7.Location = new System.Drawing.Point(230, 216);
            this.udLOOffset7.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset7.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset7.Name = "udLOOffset7";
            this.udLOOffset7.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset7.TabIndex = 88;
            this.udLOOffset7.TinyStep = false;
            this.udLOOffset7.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset6
            // 
            this.udLOOffset6.DecimalPlaces = 1;
            this.udLOOffset6.Enabled = false;
            this.udLOOffset6.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset6.Location = new System.Drawing.Point(230, 192);
            this.udLOOffset6.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset6.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset6.Name = "udLOOffset6";
            this.udLOOffset6.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset6.TabIndex = 76;
            this.udLOOffset6.TinyStep = false;
            this.udLOOffset6.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset5
            // 
            this.udLOOffset5.DecimalPlaces = 1;
            this.udLOOffset5.Enabled = false;
            this.udLOOffset5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset5.Location = new System.Drawing.Point(230, 168);
            this.udLOOffset5.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset5.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset5.Name = "udLOOffset5";
            this.udLOOffset5.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset5.TabIndex = 64;
            this.udLOOffset5.TinyStep = false;
            this.udLOOffset5.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset4
            // 
            this.udLOOffset4.DecimalPlaces = 1;
            this.udLOOffset4.Enabled = false;
            this.udLOOffset4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset4.Location = new System.Drawing.Point(230, 144);
            this.udLOOffset4.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset4.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset4.Name = "udLOOffset4";
            this.udLOOffset4.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset4.TabIndex = 52;
            this.udLOOffset4.TinyStep = false;
            this.udLOOffset4.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset3
            // 
            this.udLOOffset3.DecimalPlaces = 1;
            this.udLOOffset3.Enabled = false;
            this.udLOOffset3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset3.Location = new System.Drawing.Point(230, 120);
            this.udLOOffset3.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset3.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset3.Name = "udLOOffset3";
            this.udLOOffset3.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset3.TabIndex = 40;
            this.udLOOffset3.TinyStep = false;
            this.udLOOffset3.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset2
            // 
            this.udLOOffset2.DecimalPlaces = 1;
            this.udLOOffset2.Enabled = false;
            this.udLOOffset2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset2.Location = new System.Drawing.Point(230, 96);
            this.udLOOffset2.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset2.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset2.Name = "udLOOffset2";
            this.udLOOffset2.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset2.TabIndex = 28;
            this.udLOOffset2.TinyStep = false;
            this.udLOOffset2.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset1
            // 
            this.udLOOffset1.DecimalPlaces = 1;
            this.udLOOffset1.Enabled = false;
            this.udLOOffset1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset1.Location = new System.Drawing.Point(230, 72);
            this.udLOOffset1.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset1.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset1.Name = "udLOOffset1";
            this.udLOOffset1.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset1.TabIndex = 16;
            this.udLOOffset1.TinyStep = false;
            this.udLOOffset1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // udLOOffset0
            // 
            this.udLOOffset0.DecimalPlaces = 1;
            this.udLOOffset0.Enabled = false;
            this.udLOOffset0.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udLOOffset0.Location = new System.Drawing.Point(230, 48);
            this.udLOOffset0.Maximum = new decimal(new int[] {
            99000,
            0,
            0,
            0});
            this.udLOOffset0.Minimum = new decimal(new int[] {
            144,
            0,
            0,
            -2147483648});
            this.udLOOffset0.Name = "udLOOffset0";
            this.udLOOffset0.Size = new System.Drawing.Size(80, 20);
            this.udLOOffset0.TabIndex = 4;
            this.udLOOffset0.TinyStep = false;
            this.udLOOffset0.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblLOOffset
            // 
            this.lblLOOffset.Image = null;
            this.lblLOOffset.Location = new System.Drawing.Point(230, 16);
            this.lblLOOffset.Name = "lblLOOffset";
            this.lblLOOffset.Size = new System.Drawing.Size(72, 32);
            this.lblLOOffset.TabIndex = 68;
            this.lblLOOffset.Text = "LO Offset (MHz)";
            // 
            // txtButtonText15
            // 
            this.txtButtonText15.Enabled = false;
            this.txtButtonText15.Location = new System.Drawing.Point(150, 408);
            this.txtButtonText15.MaxLength = 5;
            this.txtButtonText15.Name = "txtButtonText15";
            this.txtButtonText15.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText15.TabIndex = 183;
            this.txtButtonText15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText15.Visible = false;
            this.txtButtonText15.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText14
            // 
            this.txtButtonText14.Enabled = false;
            this.txtButtonText14.Location = new System.Drawing.Point(150, 384);
            this.txtButtonText14.MaxLength = 5;
            this.txtButtonText14.Name = "txtButtonText14";
            this.txtButtonText14.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText14.TabIndex = 171;
            this.txtButtonText14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText14.Visible = false;
            this.txtButtonText14.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText13
            // 
            this.txtButtonText13.Enabled = false;
            this.txtButtonText13.Location = new System.Drawing.Point(150, 360);
            this.txtButtonText13.MaxLength = 5;
            this.txtButtonText13.Name = "txtButtonText13";
            this.txtButtonText13.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText13.TabIndex = 159;
            this.txtButtonText13.Text = "13";
            this.txtButtonText13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText13.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText12
            // 
            this.txtButtonText12.Enabled = false;
            this.txtButtonText12.Location = new System.Drawing.Point(150, 336);
            this.txtButtonText12.MaxLength = 5;
            this.txtButtonText12.Name = "txtButtonText12";
            this.txtButtonText12.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText12.TabIndex = 147;
            this.txtButtonText12.Text = "12";
            this.txtButtonText12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText12.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText11
            // 
            this.txtButtonText11.Enabled = false;
            this.txtButtonText11.Location = new System.Drawing.Point(150, 312);
            this.txtButtonText11.MaxLength = 5;
            this.txtButtonText11.Name = "txtButtonText11";
            this.txtButtonText11.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText11.TabIndex = 135;
            this.txtButtonText11.Text = "11";
            this.txtButtonText11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText11.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText10
            // 
            this.txtButtonText10.Enabled = false;
            this.txtButtonText10.Location = new System.Drawing.Point(150, 288);
            this.txtButtonText10.MaxLength = 5;
            this.txtButtonText10.Name = "txtButtonText10";
            this.txtButtonText10.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText10.TabIndex = 123;
            this.txtButtonText10.Text = "10";
            this.txtButtonText10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText10.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText9
            // 
            this.txtButtonText9.Enabled = false;
            this.txtButtonText9.Location = new System.Drawing.Point(150, 264);
            this.txtButtonText9.MaxLength = 5;
            this.txtButtonText9.Name = "txtButtonText9";
            this.txtButtonText9.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText9.TabIndex = 111;
            this.txtButtonText9.Text = "9";
            this.txtButtonText9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText9.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText8
            // 
            this.txtButtonText8.Enabled = false;
            this.txtButtonText8.Location = new System.Drawing.Point(150, 240);
            this.txtButtonText8.MaxLength = 5;
            this.txtButtonText8.Name = "txtButtonText8";
            this.txtButtonText8.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText8.TabIndex = 99;
            this.txtButtonText8.Text = "8";
            this.txtButtonText8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText8.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText7
            // 
            this.txtButtonText7.Enabled = false;
            this.txtButtonText7.Location = new System.Drawing.Point(150, 216);
            this.txtButtonText7.MaxLength = 5;
            this.txtButtonText7.Name = "txtButtonText7";
            this.txtButtonText7.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText7.TabIndex = 87;
            this.txtButtonText7.Text = "7";
            this.txtButtonText7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText7.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText6
            // 
            this.txtButtonText6.Enabled = false;
            this.txtButtonText6.Location = new System.Drawing.Point(150, 192);
            this.txtButtonText6.MaxLength = 5;
            this.txtButtonText6.Name = "txtButtonText6";
            this.txtButtonText6.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText6.TabIndex = 75;
            this.txtButtonText6.Text = "6";
            this.txtButtonText6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText6.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText5
            // 
            this.txtButtonText5.Enabled = false;
            this.txtButtonText5.Location = new System.Drawing.Point(150, 168);
            this.txtButtonText5.MaxLength = 5;
            this.txtButtonText5.Name = "txtButtonText5";
            this.txtButtonText5.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText5.TabIndex = 63;
            this.txtButtonText5.Text = "5";
            this.txtButtonText5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText5.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText4
            // 
            this.txtButtonText4.Enabled = false;
            this.txtButtonText4.Location = new System.Drawing.Point(150, 144);
            this.txtButtonText4.MaxLength = 5;
            this.txtButtonText4.Name = "txtButtonText4";
            this.txtButtonText4.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText4.TabIndex = 51;
            this.txtButtonText4.Text = "4";
            this.txtButtonText4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText4.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText3
            // 
            this.txtButtonText3.Enabled = false;
            this.txtButtonText3.Location = new System.Drawing.Point(150, 120);
            this.txtButtonText3.MaxLength = 5;
            this.txtButtonText3.Name = "txtButtonText3";
            this.txtButtonText3.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText3.TabIndex = 39;
            this.txtButtonText3.Text = "3";
            this.txtButtonText3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText3.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText2
            // 
            this.txtButtonText2.Enabled = false;
            this.txtButtonText2.Location = new System.Drawing.Point(150, 96);
            this.txtButtonText2.MaxLength = 5;
            this.txtButtonText2.Name = "txtButtonText2";
            this.txtButtonText2.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText2.TabIndex = 27;
            this.txtButtonText2.Text = "2";
            this.txtButtonText2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText2.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText1
            // 
            this.txtButtonText1.Enabled = false;
            this.txtButtonText1.Location = new System.Drawing.Point(150, 72);
            this.txtButtonText1.MaxLength = 5;
            this.txtButtonText1.Name = "txtButtonText1";
            this.txtButtonText1.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText1.TabIndex = 15;
            this.txtButtonText1.Text = "1";
            this.txtButtonText1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText1.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtButtonText0
            // 
            this.txtButtonText0.Enabled = false;
            this.txtButtonText0.Location = new System.Drawing.Point(150, 48);
            this.txtButtonText0.MaxLength = 5;
            this.txtButtonText0.Name = "txtButtonText0";
            this.txtButtonText0.Size = new System.Drawing.Size(64, 20);
            this.txtButtonText0.TabIndex = 3;
            this.txtButtonText0.Text = "0";
            this.txtButtonText0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtButtonText0.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // txtBandButton15
            // 
            this.txtBandButton15.Location = new System.Drawing.Point(72, 408);
            this.txtBandButton15.Name = "txtBandButton15";
            this.txtBandButton15.ReadOnly = true;
            this.txtBandButton15.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton15.TabIndex = 181;
            this.txtBandButton15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBandButton15.Visible = false;
            // 
            // txtBandButton14
            // 
            this.txtBandButton14.Location = new System.Drawing.Point(72, 384);
            this.txtBandButton14.Name = "txtBandButton14";
            this.txtBandButton14.ReadOnly = true;
            this.txtBandButton14.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton14.TabIndex = 169;
            this.txtBandButton14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBandButton14.Visible = false;
            // 
            // txtBandButton13
            // 
            this.txtBandButton13.Location = new System.Drawing.Point(72, 360);
            this.txtBandButton13.Name = "txtBandButton13";
            this.txtBandButton13.ReadOnly = true;
            this.txtBandButton13.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton13.TabIndex = 157;
            this.txtBandButton13.Text = "13";
            this.txtBandButton13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBandButton12
            // 
            this.txtBandButton12.Location = new System.Drawing.Point(72, 336);
            this.txtBandButton12.Name = "txtBandButton12";
            this.txtBandButton12.ReadOnly = true;
            this.txtBandButton12.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton12.TabIndex = 145;
            this.txtBandButton12.Text = "12";
            this.txtBandButton12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBandButton11
            // 
            this.txtBandButton11.Location = new System.Drawing.Point(72, 312);
            this.txtBandButton11.Name = "txtBandButton11";
            this.txtBandButton11.ReadOnly = true;
            this.txtBandButton11.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton11.TabIndex = 133;
            this.txtBandButton11.Text = "11";
            this.txtBandButton11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBandButton10
            // 
            this.txtBandButton10.Location = new System.Drawing.Point(72, 288);
            this.txtBandButton10.Name = "txtBandButton10";
            this.txtBandButton10.ReadOnly = true;
            this.txtBandButton10.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton10.TabIndex = 121;
            this.txtBandButton10.Text = "10";
            this.txtBandButton10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBandButton9
            // 
            this.txtBandButton9.Location = new System.Drawing.Point(72, 264);
            this.txtBandButton9.Name = "txtBandButton9";
            this.txtBandButton9.ReadOnly = true;
            this.txtBandButton9.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton9.TabIndex = 109;
            this.txtBandButton9.Text = "9";
            this.txtBandButton9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBandButton8
            // 
            this.txtBandButton8.Location = new System.Drawing.Point(72, 240);
            this.txtBandButton8.Name = "txtBandButton8";
            this.txtBandButton8.ReadOnly = true;
            this.txtBandButton8.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton8.TabIndex = 97;
            this.txtBandButton8.Text = "8";
            this.txtBandButton8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBandButton7
            // 
            this.txtBandButton7.Location = new System.Drawing.Point(72, 216);
            this.txtBandButton7.Name = "txtBandButton7";
            this.txtBandButton7.ReadOnly = true;
            this.txtBandButton7.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton7.TabIndex = 85;
            this.txtBandButton7.Text = "7";
            this.txtBandButton7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBandButton6
            // 
            this.txtBandButton6.Location = new System.Drawing.Point(72, 192);
            this.txtBandButton6.Name = "txtBandButton6";
            this.txtBandButton6.ReadOnly = true;
            this.txtBandButton6.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton6.TabIndex = 73;
            this.txtBandButton6.Text = "6";
            this.txtBandButton6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBandButton5
            // 
            this.txtBandButton5.Location = new System.Drawing.Point(72, 168);
            this.txtBandButton5.Name = "txtBandButton5";
            this.txtBandButton5.ReadOnly = true;
            this.txtBandButton5.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton5.TabIndex = 61;
            this.txtBandButton5.Text = "5";
            this.txtBandButton5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBandButton4
            // 
            this.txtBandButton4.Location = new System.Drawing.Point(72, 144);
            this.txtBandButton4.Name = "txtBandButton4";
            this.txtBandButton4.ReadOnly = true;
            this.txtBandButton4.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton4.TabIndex = 49;
            this.txtBandButton4.Text = "4";
            this.txtBandButton4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBandButton3
            // 
            this.txtBandButton3.Location = new System.Drawing.Point(72, 120);
            this.txtBandButton3.Name = "txtBandButton3";
            this.txtBandButton3.ReadOnly = true;
            this.txtBandButton3.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton3.TabIndex = 37;
            this.txtBandButton3.Text = "3";
            this.txtBandButton3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBandButton2
            // 
            this.txtBandButton2.Location = new System.Drawing.Point(72, 96);
            this.txtBandButton2.Name = "txtBandButton2";
            this.txtBandButton2.ReadOnly = true;
            this.txtBandButton2.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton2.TabIndex = 25;
            this.txtBandButton2.Text = "2";
            this.txtBandButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBandButton1
            // 
            this.txtBandButton1.Location = new System.Drawing.Point(72, 72);
            this.txtBandButton1.Name = "txtBandButton1";
            this.txtBandButton1.ReadOnly = true;
            this.txtBandButton1.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton1.TabIndex = 13;
            this.txtBandButton1.Text = "1";
            this.txtBandButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBandButton0
            // 
            this.txtBandButton0.Location = new System.Drawing.Point(72, 48);
            this.txtBandButton0.Name = "txtBandButton0";
            this.txtBandButton0.ReadOnly = true;
            this.txtBandButton0.Size = new System.Drawing.Size(64, 20);
            this.txtBandButton0.TabIndex = 1;
            this.txtBandButton0.Text = "0";
            this.txtBandButton0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblEnabled
            // 
            this.lblEnabled.Image = null;
            this.lblEnabled.Location = new System.Drawing.Point(16, 24);
            this.lblEnabled.Name = "lblEnabled";
            this.lblEnabled.Size = new System.Drawing.Size(48, 16);
            this.lblEnabled.TabIndex = 51;
            this.lblEnabled.Text = "Enabled";
            // 
            // chkEnable15
            // 
            this.chkEnable15.Image = null;
            this.chkEnable15.Location = new System.Drawing.Point(32, 408);
            this.chkEnable15.Name = "chkEnable15";
            this.chkEnable15.Size = new System.Drawing.Size(16, 16);
            this.chkEnable15.TabIndex = 180;
            this.chkEnable15.CheckedChanged += new System.EventHandler(this.chkEnable15_CheckedChanged);
            // 
            // chkEnable14
            // 
            this.chkEnable14.Image = null;
            this.chkEnable14.Location = new System.Drawing.Point(32, 384);
            this.chkEnable14.Name = "chkEnable14";
            this.chkEnable14.Size = new System.Drawing.Size(16, 16);
            this.chkEnable14.TabIndex = 168;
            this.chkEnable14.CheckedChanged += new System.EventHandler(this.chkEnable14_CheckedChanged);
            // 
            // chkEnable13
            // 
            this.chkEnable13.Image = null;
            this.chkEnable13.Location = new System.Drawing.Point(32, 360);
            this.chkEnable13.Name = "chkEnable13";
            this.chkEnable13.Size = new System.Drawing.Size(16, 16);
            this.chkEnable13.TabIndex = 156;
            this.chkEnable13.CheckedChanged += new System.EventHandler(this.chkEnable13_CheckedChanged);
            // 
            // chkEnable12
            // 
            this.chkEnable12.Image = null;
            this.chkEnable12.Location = new System.Drawing.Point(32, 336);
            this.chkEnable12.Name = "chkEnable12";
            this.chkEnable12.Size = new System.Drawing.Size(16, 16);
            this.chkEnable12.TabIndex = 144;
            this.chkEnable12.CheckedChanged += new System.EventHandler(this.chkEnable12_CheckedChanged);
            // 
            // chkEnable11
            // 
            this.chkEnable11.Image = null;
            this.chkEnable11.Location = new System.Drawing.Point(32, 312);
            this.chkEnable11.Name = "chkEnable11";
            this.chkEnable11.Size = new System.Drawing.Size(16, 16);
            this.chkEnable11.TabIndex = 132;
            this.chkEnable11.CheckedChanged += new System.EventHandler(this.chkEnable11_CheckedChanged);
            // 
            // chkEnable10
            // 
            this.chkEnable10.Image = null;
            this.chkEnable10.Location = new System.Drawing.Point(32, 288);
            this.chkEnable10.Name = "chkEnable10";
            this.chkEnable10.Size = new System.Drawing.Size(16, 16);
            this.chkEnable10.TabIndex = 120;
            this.chkEnable10.CheckedChanged += new System.EventHandler(this.chkEnable10_CheckedChanged);
            // 
            // chkEnable9
            // 
            this.chkEnable9.Image = null;
            this.chkEnable9.Location = new System.Drawing.Point(32, 264);
            this.chkEnable9.Name = "chkEnable9";
            this.chkEnable9.Size = new System.Drawing.Size(16, 16);
            this.chkEnable9.TabIndex = 108;
            this.chkEnable9.CheckedChanged += new System.EventHandler(this.chkEnable9_CheckedChanged);
            // 
            // chkEnable8
            // 
            this.chkEnable8.Image = null;
            this.chkEnable8.Location = new System.Drawing.Point(32, 240);
            this.chkEnable8.Name = "chkEnable8";
            this.chkEnable8.Size = new System.Drawing.Size(16, 16);
            this.chkEnable8.TabIndex = 96;
            this.chkEnable8.CheckedChanged += new System.EventHandler(this.chkEnable8_CheckedChanged);
            // 
            // chkEnable7
            // 
            this.chkEnable7.Image = null;
            this.chkEnable7.Location = new System.Drawing.Point(32, 216);
            this.chkEnable7.Name = "chkEnable7";
            this.chkEnable7.Size = new System.Drawing.Size(16, 16);
            this.chkEnable7.TabIndex = 84;
            this.chkEnable7.CheckedChanged += new System.EventHandler(this.chkEnable7_CheckedChanged);
            // 
            // chkEnable6
            // 
            this.chkEnable6.Image = null;
            this.chkEnable6.Location = new System.Drawing.Point(32, 192);
            this.chkEnable6.Name = "chkEnable6";
            this.chkEnable6.Size = new System.Drawing.Size(16, 16);
            this.chkEnable6.TabIndex = 72;
            this.chkEnable6.CheckedChanged += new System.EventHandler(this.chkEnable6_CheckedChanged);
            // 
            // chkEnable5
            // 
            this.chkEnable5.Image = null;
            this.chkEnable5.Location = new System.Drawing.Point(32, 168);
            this.chkEnable5.Name = "chkEnable5";
            this.chkEnable5.Size = new System.Drawing.Size(16, 16);
            this.chkEnable5.TabIndex = 60;
            this.chkEnable5.CheckedChanged += new System.EventHandler(this.chkEnable5_CheckedChanged);
            // 
            // chkEnable4
            // 
            this.chkEnable4.Image = null;
            this.chkEnable4.Location = new System.Drawing.Point(32, 144);
            this.chkEnable4.Name = "chkEnable4";
            this.chkEnable4.Size = new System.Drawing.Size(16, 16);
            this.chkEnable4.TabIndex = 48;
            this.chkEnable4.CheckedChanged += new System.EventHandler(this.chkEnable4_CheckedChanged);
            // 
            // chkEnable3
            // 
            this.chkEnable3.Image = null;
            this.chkEnable3.Location = new System.Drawing.Point(32, 120);
            this.chkEnable3.Name = "chkEnable3";
            this.chkEnable3.Size = new System.Drawing.Size(16, 16);
            this.chkEnable3.TabIndex = 36;
            this.chkEnable3.CheckedChanged += new System.EventHandler(this.chkEnable3_CheckedChanged);
            // 
            // chkEnable2
            // 
            this.chkEnable2.Image = null;
            this.chkEnable2.Location = new System.Drawing.Point(32, 96);
            this.chkEnable2.Name = "chkEnable2";
            this.chkEnable2.Size = new System.Drawing.Size(16, 16);
            this.chkEnable2.TabIndex = 24;
            this.chkEnable2.CheckedChanged += new System.EventHandler(this.chkEnable2_CheckedChanged);
            // 
            // chkEnable1
            // 
            this.chkEnable1.Image = null;
            this.chkEnable1.Location = new System.Drawing.Point(32, 72);
            this.chkEnable1.Name = "chkEnable1";
            this.chkEnable1.Size = new System.Drawing.Size(16, 16);
            this.chkEnable1.TabIndex = 12;
            this.chkEnable1.CheckedChanged += new System.EventHandler(this.chkEnable1_CheckedChanged);
            // 
            // chkEnable0
            // 
            this.chkEnable0.Image = null;
            this.chkEnable0.Location = new System.Drawing.Point(32, 48);
            this.chkEnable0.Name = "chkEnable0";
            this.chkEnable0.Size = new System.Drawing.Size(16, 16);
            this.chkEnable0.TabIndex = 0;
            this.chkEnable0.CheckedChanged += new System.EventHandler(this.chkEnable0_CheckedChanged);
            // 
            // lblButtonText
            // 
            this.lblButtonText.Image = null;
            this.lblButtonText.Location = new System.Drawing.Point(150, 24);
            this.lblButtonText.Name = "lblButtonText";
            this.lblButtonText.Size = new System.Drawing.Size(72, 16);
            this.lblButtonText.TabIndex = 2;
            this.lblButtonText.Text = "Button Text";
            // 
            // lblBandButton
            // 
            this.lblBandButton.Image = null;
            this.lblBandButton.Location = new System.Drawing.Point(72, 24);
            this.lblBandButton.Name = "lblBandButton";
            this.lblBandButton.Size = new System.Drawing.Size(72, 16);
            this.lblBandButton.TabIndex = 0;
            this.lblBandButton.Text = "Band Button";
            // 
            // XVTRForm
            // 
            this.ClientSize = new System.Drawing.Size(904, 454);
            this.Controls.Add(this.comboAnt15);
            this.Controls.Add(this.comboAnt14);
            this.Controls.Add(this.comboAnt13);
            this.Controls.Add(this.comboAnt12);
            this.Controls.Add(this.comboAnt11);
            this.Controls.Add(this.comboAnt10);
            this.Controls.Add(this.comboAnt9);
            this.Controls.Add(this.comboAnt8);
            this.Controls.Add(this.comboAnt7);
            this.Controls.Add(this.comboAnt6);
            this.Controls.Add(this.comboAnt5);
            this.Controls.Add(this.comboAnt4);
            this.Controls.Add(this.comboAnt3);
            this.Controls.Add(this.comboAnt2);
            this.Controls.Add(this.comboAnt1);
            this.Controls.Add(this.comboAnt0);
            this.Controls.Add(this.chkDisablePA15);
            this.Controls.Add(this.chkDisablePA14);
            this.Controls.Add(this.chkDisablePA13);
            this.Controls.Add(this.chkDisablePA12);
            this.Controls.Add(this.chkDisablePA11);
            this.Controls.Add(this.chkDisablePA10);
            this.Controls.Add(this.chkDisablePA9);
            this.Controls.Add(this.chkDisablePA8);
            this.Controls.Add(this.chkDisablePA7);
            this.Controls.Add(this.chkDisablePA6);
            this.Controls.Add(this.chkDisablePA5);
            this.Controls.Add(this.chkDisablePA4);
            this.Controls.Add(this.chkDisablePA3);
            this.Controls.Add(this.chkDisablePA2);
            this.Controls.Add(this.chkDisablePA1);
            this.Controls.Add(this.chkDisablePA0);
            this.Controls.Add(this.lblDisablePA);
            this.Controls.Add(this.chkAlexTRRelay);
            this.Controls.Add(this.chkUseXVTRTUNPWR);
            this.Controls.Add(this.udRXGain15);
            this.Controls.Add(this.udRXGain14);
            this.Controls.Add(this.udRXGain13);
            this.Controls.Add(this.udRXGain12);
            this.Controls.Add(this.udRXGain11);
            this.Controls.Add(this.udRXGain10);
            this.Controls.Add(this.udRXGain9);
            this.Controls.Add(this.udRXGain8);
            this.Controls.Add(this.udRXGain7);
            this.Controls.Add(this.udRXGain6);
            this.Controls.Add(this.udRXGain5);
            this.Controls.Add(this.udRXGain4);
            this.Controls.Add(this.udRXGain3);
            this.Controls.Add(this.udRXGain2);
            this.Controls.Add(this.udRXGain1);
            this.Controls.Add(this.udRXGain0);
            this.Controls.Add(this.lblRXGain);
            this.Controls.Add(this.chkXVTRRF15);
            this.Controls.Add(this.chkXVTRRF14);
            this.Controls.Add(this.chkXVTRRF13);
            this.Controls.Add(this.chkXVTRRF12);
            this.Controls.Add(this.chkXVTRRF11);
            this.Controls.Add(this.chkXVTRRF10);
            this.Controls.Add(this.chkXVTRRF9);
            this.Controls.Add(this.chkXVTRRF8);
            this.Controls.Add(this.chkXVTRRF7);
            this.Controls.Add(this.chkXVTRRF6);
            this.Controls.Add(this.chkXVTRRF5);
            this.Controls.Add(this.chkXVTRRF4);
            this.Controls.Add(this.chkXVTRRF3);
            this.Controls.Add(this.chkXVTRRF2);
            this.Controls.Add(this.chkXVTRRF1);
            this.Controls.Add(this.chkXVTRRF0);
            this.Controls.Add(this.lblXVTRRF);
            this.Controls.Add(this.udPower15);
            this.Controls.Add(this.udPower14);
            this.Controls.Add(this.udPower13);
            this.Controls.Add(this.udPower12);
            this.Controls.Add(this.udPower11);
            this.Controls.Add(this.udPower10);
            this.Controls.Add(this.udPower9);
            this.Controls.Add(this.udPower8);
            this.Controls.Add(this.udPower7);
            this.Controls.Add(this.udPower6);
            this.Controls.Add(this.udPower5);
            this.Controls.Add(this.udPower4);
            this.Controls.Add(this.udPower3);
            this.Controls.Add(this.udPower2);
            this.Controls.Add(this.udPower1);
            this.Controls.Add(this.udPower0);
            this.Controls.Add(this.lblPower);
            this.Controls.Add(this.udLOError15);
            this.Controls.Add(this.udLOError14);
            this.Controls.Add(this.udLOError13);
            this.Controls.Add(this.udLOError12);
            this.Controls.Add(this.udLOError11);
            this.Controls.Add(this.udLOError10);
            this.Controls.Add(this.udLOError9);
            this.Controls.Add(this.udLOError8);
            this.Controls.Add(this.udLOError7);
            this.Controls.Add(this.udLOError6);
            this.Controls.Add(this.udLOError5);
            this.Controls.Add(this.udLOError4);
            this.Controls.Add(this.udLOError3);
            this.Controls.Add(this.udLOError2);
            this.Controls.Add(this.udLOError1);
            this.Controls.Add(this.udLOError0);
            this.Controls.Add(this.lblLOError);
            this.Controls.Add(this.chkRXOnly15);
            this.Controls.Add(this.chkRXOnly14);
            this.Controls.Add(this.chkRXOnly13);
            this.Controls.Add(this.chkRXOnly12);
            this.Controls.Add(this.chkRXOnly11);
            this.Controls.Add(this.chkRXOnly10);
            this.Controls.Add(this.chkRXOnly9);
            this.Controls.Add(this.chkRXOnly8);
            this.Controls.Add(this.chkRXOnly7);
            this.Controls.Add(this.chkRXOnly6);
            this.Controls.Add(this.chkRXOnly5);
            this.Controls.Add(this.chkRXOnly4);
            this.Controls.Add(this.chkRXOnly3);
            this.Controls.Add(this.chkRXOnly2);
            this.Controls.Add(this.chkRXOnly1);
            this.Controls.Add(this.chkRXOnly0);
            this.Controls.Add(this.lblRXOnly);
            this.Controls.Add(this.udFreqEnd15);
            this.Controls.Add(this.udFreqEnd14);
            this.Controls.Add(this.udFreqEnd13);
            this.Controls.Add(this.udFreqEnd12);
            this.Controls.Add(this.udFreqEnd11);
            this.Controls.Add(this.udFreqEnd10);
            this.Controls.Add(this.udFreqEnd9);
            this.Controls.Add(this.udFreqEnd8);
            this.Controls.Add(this.udFreqEnd7);
            this.Controls.Add(this.udFreqEnd6);
            this.Controls.Add(this.udFreqEnd5);
            this.Controls.Add(this.udFreqEnd4);
            this.Controls.Add(this.udFreqEnd3);
            this.Controls.Add(this.udFreqEnd2);
            this.Controls.Add(this.udFreqEnd1);
            this.Controls.Add(this.udFreqEnd0);
            this.Controls.Add(this.lblFreqEnd);
            this.Controls.Add(this.udFreqBegin15);
            this.Controls.Add(this.udFreqBegin14);
            this.Controls.Add(this.udFreqBegin13);
            this.Controls.Add(this.udFreqBegin12);
            this.Controls.Add(this.udFreqBegin11);
            this.Controls.Add(this.udFreqBegin10);
            this.Controls.Add(this.udFreqBegin9);
            this.Controls.Add(this.udFreqBegin8);
            this.Controls.Add(this.udFreqBegin7);
            this.Controls.Add(this.udFreqBegin6);
            this.Controls.Add(this.udFreqBegin5);
            this.Controls.Add(this.udFreqBegin4);
            this.Controls.Add(this.udFreqBegin3);
            this.Controls.Add(this.udFreqBegin2);
            this.Controls.Add(this.udFreqBegin1);
            this.Controls.Add(this.udFreqBegin0);
            this.Controls.Add(this.lblFreqBegin);
            this.Controls.Add(this.udLOOffset15);
            this.Controls.Add(this.udLOOffset14);
            this.Controls.Add(this.udLOOffset13);
            this.Controls.Add(this.udLOOffset12);
            this.Controls.Add(this.udLOOffset11);
            this.Controls.Add(this.udLOOffset10);
            this.Controls.Add(this.udLOOffset9);
            this.Controls.Add(this.udLOOffset8);
            this.Controls.Add(this.udLOOffset7);
            this.Controls.Add(this.udLOOffset6);
            this.Controls.Add(this.udLOOffset5);
            this.Controls.Add(this.udLOOffset4);
            this.Controls.Add(this.udLOOffset3);
            this.Controls.Add(this.udLOOffset2);
            this.Controls.Add(this.udLOOffset1);
            this.Controls.Add(this.udLOOffset0);
            this.Controls.Add(this.lblLOOffset);
            this.Controls.Add(this.txtButtonText15);
            this.Controls.Add(this.txtButtonText14);
            this.Controls.Add(this.txtButtonText13);
            this.Controls.Add(this.txtButtonText12);
            this.Controls.Add(this.txtButtonText11);
            this.Controls.Add(this.txtButtonText10);
            this.Controls.Add(this.txtButtonText9);
            this.Controls.Add(this.txtButtonText8);
            this.Controls.Add(this.txtButtonText7);
            this.Controls.Add(this.txtButtonText6);
            this.Controls.Add(this.txtButtonText5);
            this.Controls.Add(this.txtButtonText4);
            this.Controls.Add(this.txtButtonText3);
            this.Controls.Add(this.txtButtonText2);
            this.Controls.Add(this.txtButtonText1);
            this.Controls.Add(this.txtButtonText0);
            this.Controls.Add(this.txtBandButton15);
            this.Controls.Add(this.txtBandButton14);
            this.Controls.Add(this.txtBandButton13);
            this.Controls.Add(this.txtBandButton12);
            this.Controls.Add(this.txtBandButton11);
            this.Controls.Add(this.txtBandButton10);
            this.Controls.Add(this.txtBandButton9);
            this.Controls.Add(this.txtBandButton8);
            this.Controls.Add(this.txtBandButton7);
            this.Controls.Add(this.txtBandButton6);
            this.Controls.Add(this.txtBandButton5);
            this.Controls.Add(this.txtBandButton4);
            this.Controls.Add(this.txtBandButton3);
            this.Controls.Add(this.txtBandButton2);
            this.Controls.Add(this.txtBandButton1);
            this.Controls.Add(this.txtBandButton0);
            this.Controls.Add(this.lblEnabled);
            this.Controls.Add(this.chkEnable15);
            this.Controls.Add(this.chkEnable14);
            this.Controls.Add(this.chkEnable13);
            this.Controls.Add(this.chkEnable12);
            this.Controls.Add(this.chkEnable11);
            this.Controls.Add(this.chkEnable10);
            this.Controls.Add(this.chkEnable9);
            this.Controls.Add(this.chkEnable8);
            this.Controls.Add(this.chkEnable7);
            this.Controls.Add(this.chkEnable6);
            this.Controls.Add(this.chkEnable5);
            this.Controls.Add(this.chkEnable4);
            this.Controls.Add(this.chkEnable3);
            this.Controls.Add(this.chkEnable2);
            this.Controls.Add(this.chkEnable1);
            this.Controls.Add(this.chkEnable0);
            this.Controls.Add(this.lblButtonText);
            this.Controls.Add(this.lblBandButton);
            this.Controls.Add(this.labelTS1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XVTRForm";
            this.Text = "XVTR Setup";
            this.Activated += new System.EventHandler(this.XVTRForm_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.XVTRForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udRXGain0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPower0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOError0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqEnd0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udFreqBegin0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLOOffset0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Misc Routines

		/// <summary>
		/// Returns an index that indicates which band the frequency is in.
		/// </summary>
		/// <param name="freq">The frequency in MHz</param>
		/// <returns>The index of the band that contains the frequency or -1 if
		/// the frequency is not found.</returns>
		public int XVTRFreq(double freq)
		{
			for(int i=0; i<16; i++)
			{
				if(enabled[i].Checked)
				{
					if(freq >= (double)begin[i].Value && freq <= (double)end[i].Value)
						return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Returns a translated frequency based on the xvtr data.  Takes into
		/// account the LO Offset and correction.
		/// </summary>
		/// <param name="freq">Input Frequency in MHz</param>
		/// <returns>The translated frequency based on the xvtr data.  If the
		/// frequency is not within a defined xvtr setup, then just return the
		/// input freq.</returns>
		public double TranslateFreq(double freq)
		{
			for(int i=0; i<16; i++)
			{
				if(enabled[i].Checked)
				{
					if(freq >= (double)begin[i].Value && freq <= (double)end[i].Value)
					{
						return (double)(freq - 
							(double)lo_offset[i].Value +
							((double)lo_error[i].Value / 1000.0));
					}
				}
			}

			return freq;
		}
        private bool _ignore_combo_events = false;
        private void SetupControlArrays()
		{
			begin = new NumericUpDownTS[16];
			begin[0] = udFreqBegin0;
			begin[1] = udFreqBegin1;
			begin[2] = udFreqBegin2;
			begin[3] = udFreqBegin3;
			begin[4] = udFreqBegin4;
			begin[5] = udFreqBegin5;
			begin[6] = udFreqBegin6;
			begin[7] = udFreqBegin7;
			begin[8] = udFreqBegin8;
			begin[9] = udFreqBegin9;
			begin[10] = udFreqBegin10;
			begin[11] = udFreqBegin11;
			begin[12] = udFreqBegin12;
			begin[13] = udFreqBegin13;
			begin[14] = udFreqBegin14;
			begin[15] = udFreqBegin15;

			end = new NumericUpDownTS[16];
			end[0] = udFreqEnd0;
			end[1] = udFreqEnd1;
			end[2] = udFreqEnd2;
			end[3] = udFreqEnd3;
			end[4] = udFreqEnd4;
			end[5] = udFreqEnd5;
			end[6] = udFreqEnd6;
			end[7] = udFreqEnd7;
			end[8] = udFreqEnd8;
			end[9] = udFreqEnd9;
			end[10] = udFreqEnd10;
			end[11] = udFreqEnd11;
			end[12] = udFreqEnd12;
			end[13] = udFreqEnd13;
			end[14] = udFreqEnd14;
			end[15] = udFreqEnd15;	

			enabled = new CheckBoxTS[16];
			enabled[0] = chkEnable0;
			enabled[1] = chkEnable1;
			enabled[2] = chkEnable2;
			enabled[3] = chkEnable3;
			enabled[4] = chkEnable4;
			enabled[5] = chkEnable5;
			enabled[6] = chkEnable6;
			enabled[7] = chkEnable7;
			enabled[8] = chkEnable8;
			enabled[9] = chkEnable9;
			enabled[10] = chkEnable10;
			enabled[11] = chkEnable11;
			enabled[12] = chkEnable12;
			enabled[13] = chkEnable13;
			enabled[14] = chkEnable14;
			enabled[15] = chkEnable15;

			lo_offset = new NumericUpDownTS[16];
			lo_offset[0] = udLOOffset0;
			lo_offset[1] = udLOOffset1;
			lo_offset[2] = udLOOffset2;
			lo_offset[3] = udLOOffset3;
			lo_offset[4] = udLOOffset4;
			lo_offset[5] = udLOOffset5;
			lo_offset[6] = udLOOffset6;
			lo_offset[7] = udLOOffset7;
			lo_offset[8] = udLOOffset8;
			lo_offset[9] = udLOOffset9;
			lo_offset[10] = udLOOffset10;
			lo_offset[11] = udLOOffset11;
			lo_offset[12] = udLOOffset12;
			lo_offset[13] = udLOOffset13;
			lo_offset[14] = udLOOffset14;
			lo_offset[15] = udLOOffset15;

			lo_error = new NumericUpDownTS[16];
			lo_error[0] = udLOError0;
			lo_error[1] = udLOError1;
			lo_error[2] = udLOError2;
			lo_error[3] = udLOError3;
			lo_error[4] = udLOError4;
			lo_error[5] = udLOError5;
			lo_error[6] = udLOError6;
			lo_error[7] = udLOError7;
			lo_error[8] = udLOError8;
			lo_error[9] = udLOError9;
			lo_error[10] = udLOError10;
			lo_error[11] = udLOError11;
			lo_error[12] = udLOError12;
			lo_error[13] = udLOError13;
			lo_error[14] = udLOError14;
			lo_error[15] = udLOError15;

			rx_gain = new NumericUpDownTS[16];
			rx_gain[0] = udRXGain0;
			rx_gain[1] = udRXGain1;
			rx_gain[2] = udRXGain2;
			rx_gain[3] = udRXGain3;
			rx_gain[4] = udRXGain4;
			rx_gain[5] = udRXGain5;
			rx_gain[6] = udRXGain6;
			rx_gain[7] = udRXGain7;
			rx_gain[8] = udRXGain8;
			rx_gain[9] = udRXGain9;
			rx_gain[10] = udRXGain10;
			rx_gain[11] = udRXGain11;
			rx_gain[12] = udRXGain12;
			rx_gain[13] = udRXGain13;
			rx_gain[14] = udRXGain14;
			rx_gain[15] = udRXGain15;

			rx_only = new CheckBoxTS[16];
			rx_only[0] = chkRXOnly0;
			rx_only[1] = chkRXOnly1;
			rx_only[2] = chkRXOnly2;
			rx_only[3] = chkRXOnly3;
			rx_only[4] = chkRXOnly4;
			rx_only[5] = chkRXOnly5;
			rx_only[6] = chkRXOnly6;
			rx_only[7] = chkRXOnly7;
			rx_only[8] = chkRXOnly8;
			rx_only[9] = chkRXOnly9;
			rx_only[10] = chkRXOnly10;
			rx_only[11] = chkRXOnly11;
			rx_only[12] = chkRXOnly12;
			rx_only[13] = chkRXOnly13;
			rx_only[14] = chkRXOnly14;
			rx_only[15] = chkRXOnly15;

			power = new NumericUpDownTS[16];
			power[0] = udPower0;
			power[1] = udPower1;
			power[2] = udPower2;
			power[3] = udPower3;
			power[4] = udPower4;
			power[5] = udPower5;
			power[6] = udPower6;
			power[7] = udPower7;
			power[8] = udPower8;
			power[9] = udPower9;
			power[10] = udPower10;
			power[11] = udPower11;
			power[12] = udPower12;
			power[13] = udPower13;
			power[14] = udPower14;
			power[15] = udPower15;

			xvtr_rf = new CheckBoxTS[16];
			xvtr_rf[0] = chkXVTRRF0;
			xvtr_rf[1] = chkXVTRRF1;
			xvtr_rf[2] = chkXVTRRF2;
			xvtr_rf[3] = chkXVTRRF3;
			xvtr_rf[4] = chkXVTRRF4;
			xvtr_rf[5] = chkXVTRRF5;
			xvtr_rf[6] = chkXVTRRF6;
			xvtr_rf[7] = chkXVTRRF7;
			xvtr_rf[8] = chkXVTRRF8;
			xvtr_rf[9] = chkXVTRRF9;
			xvtr_rf[10] = chkXVTRRF10;
			xvtr_rf[11] = chkXVTRRF11;
			xvtr_rf[12] = chkXVTRRF12;
			xvtr_rf[13] = chkXVTRRF13;
			xvtr_rf[14] = chkXVTRRF14;
			xvtr_rf[15] = chkXVTRRF15;

            disable_pa = new CheckBoxTS[16];
            disable_pa[0] = chkDisablePA0;
            disable_pa[1] = chkDisablePA1;
            disable_pa[2] = chkDisablePA2;
            disable_pa[3] = chkDisablePA3;
            disable_pa[4] = chkDisablePA4;
            disable_pa[5] = chkDisablePA5;
            disable_pa[6] = chkDisablePA6;
            disable_pa[7] = chkDisablePA7;
            disable_pa[8] = chkDisablePA8;
            disable_pa[9] = chkDisablePA9;
            disable_pa[10] = chkDisablePA10;
            disable_pa[11] = chkDisablePA11;
            disable_pa[12] = chkDisablePA12;
            disable_pa[13] = chkDisablePA13;
            disable_pa[14] = chkDisablePA14;
            disable_pa[15] = chkDisablePA15;

            rx_antennas = new ComboBoxTS[16];
            rx_antennas[0] = comboAnt0;
            rx_antennas[1] = comboAnt1;
            rx_antennas[2] = comboAnt2;                
            rx_antennas[3] = comboAnt3;
            rx_antennas[4] = comboAnt4;
            rx_antennas[5] = comboAnt5;
            rx_antennas[6] = comboAnt6;
            rx_antennas[7] = comboAnt7;
            rx_antennas[8] = comboAnt8;
            rx_antennas[9] = comboAnt9;
            rx_antennas[10] = comboAnt10;
            rx_antennas[11] = comboAnt11;
            rx_antennas[12] = comboAnt12;
            rx_antennas[13] = comboAnt13;
            rx_antennas[14] = comboAnt14;
            rx_antennas[15] = comboAnt15;

            _ignore_combo_events = true;
            //default the antennas to def, they will get updated when the form is restored
            for (int i = 0; i < rx_antennas.Length; i++)
                rx_antennas[i].SelectedIndex = 0;
            _ignore_combo_events = false;
        }

        public int GetRXAntenna(int index)
        {
            if (index < 0 || index > rx_antennas.Length - 1) return 0;
            if (rx_antennas[index].SelectedIndex == 0) return 0; // the def entry

            return rx_antennas[index].SelectedIndex; // 1-3 antenna
        }
		public bool GetEnabled(int index)
		{
			return enabled[index].Checked;
		}

		public float GetBegin(int index)
		{
			return (float)begin[index].Value;
		}

		public float GetEnd(int index)
		{
			return (float)end[index].Value;
		}

		public int GetPower(int index)
		{
			return (int)power[index].Value;
		}

		public void SetPower(int index, int pwr)
		{
			power[index].Value = pwr;
		}

		public bool GetRXOnly(int index)
		{
			return rx_only[index].Checked;
		}

		public void SetRXOnly(int index, bool b)
		{
			rx_only[index].Checked = b;
		}

		public float GetRXGain(int index)
		{
            float ret_val = 0.0f;
            ret_val = -(float)rx_gain[index].Value;
            return ret_val;
		}

	//	public byte GetXVTRAddr(int index)
		//{
			//return (byte)ucb_addr[index].Value;
		//}

		public bool GetXVTRRF(int index)
		{
			return xvtr_rf[index].Checked;
		}

        public bool GetDisablePA(int index)
        {
            if (index < 0) return false;
            else return disable_pa[index].Checked;
        }

		#endregion

		#region Event Handlers

		private void XVTRForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.Hide();
			e.Cancel = true;
			Common.SaveForm(this, "XVTR");
		}

		#region Enabled

		private void chkEnable0_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable0.Checked;
 			txtButtonText0.Enabled = b;
			udLOOffset0.Enabled = b;
			udLOError0.Enabled = b;
			udFreqBegin0.Enabled = b;
			udFreqEnd0.Enabled = b;
			udRXGain0.Enabled = b;
			chkRXOnly0.Enabled = b;
			udPower0.Enabled = b;
			chkXVTRRF0.Enabled = b;
            chkDisablePA0.Enabled = b;
            comboAnt0.Enabled = b;

			console.SetVHFEnabled(0, b);
		}

		private void chkEnable1_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable1.Checked;
			txtButtonText1.Enabled = b;
			udLOOffset1.Enabled = b;
			udLOError1.Enabled = b;
			udFreqBegin1.Enabled = b;
			udFreqEnd1.Enabled = b;
			udRXGain1.Enabled = b;
			chkRXOnly1.Enabled = b;
			udPower1.Enabled = b;
			chkXVTRRF1.Enabled = b;
            chkDisablePA1.Enabled = b;
            comboAnt1.Enabled = b;

            console.SetVHFEnabled(1, b);
		}

		private void chkEnable2_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable2.Checked;

			txtButtonText2.Enabled = b;
			udLOOffset2.Enabled = b;
			udLOError2.Enabled = b;
			udFreqBegin2.Enabled = b;
			udFreqEnd2.Enabled = b;
			udRXGain2.Enabled = b;
			chkRXOnly2.Enabled = b;
			udPower2.Enabled = b;
			chkXVTRRF2.Enabled = b;
            chkDisablePA2.Enabled = b;
            comboAnt2.Enabled = b;

            console.SetVHFEnabled(2, b);
		}

		private void chkEnable3_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable3.Checked;

			txtButtonText3.Enabled = b;
			udLOOffset3.Enabled = b;
			udLOError3.Enabled = b;
			udFreqBegin3.Enabled = b;
			udFreqEnd3.Enabled = b;
			udRXGain3.Enabled = b;
			chkRXOnly3.Enabled = b;
			udPower3.Enabled = b;
			chkXVTRRF3.Enabled = b;
            chkDisablePA3.Enabled = b;
            comboAnt3.Enabled = b;

            console.SetVHFEnabled(3, b);
		}

		private void chkEnable4_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable4.Checked;

			txtButtonText4.Enabled = b;
			udLOOffset4.Enabled = b;
			udLOError4.Enabled = b;
			udFreqBegin4.Enabled = b;
			udFreqEnd4.Enabled = b;
			udRXGain4.Enabled = b;
			chkRXOnly4.Enabled = b;
			udPower4.Enabled = b;
			chkXVTRRF4.Enabled = b;
            chkDisablePA4.Enabled = b;
            comboAnt4.Enabled = b;

            console.SetVHFEnabled(4, b);
		}

		private void chkEnable5_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable5.Checked;

 			txtButtonText5.Enabled = b;
			udLOOffset5.Enabled = b;
			udLOError5.Enabled = b;
			udFreqBegin5.Enabled = b;
			udFreqEnd5.Enabled = b;
			udRXGain5.Enabled = b;
			chkRXOnly5.Enabled = b;
			udPower5.Enabled = b;
			chkXVTRRF5.Enabled = b;
            chkDisablePA5.Enabled = b;
            comboAnt5.Enabled = b;

            console.SetVHFEnabled(5, b);
		}

		private void chkEnable6_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable6.Checked;

			txtButtonText6.Enabled = b;
			udLOOffset6.Enabled = b;
			udLOError6.Enabled = b;
			udFreqBegin6.Enabled = b;
			udFreqEnd6.Enabled = b;
			udRXGain6.Enabled = b;
			chkRXOnly6.Enabled = b;
			udPower6.Enabled = b;
			chkXVTRRF6.Enabled = b;
            chkDisablePA6.Enabled = b;
            comboAnt6.Enabled = b;

            console.SetVHFEnabled(6, b);
		}

		private void chkEnable7_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable7.Checked;

			txtButtonText7.Enabled = b;
			udLOOffset7.Enabled = b;
			udLOError7.Enabled = b;
			udFreqBegin7.Enabled = b;
			udFreqEnd7.Enabled = b;
			udRXGain7.Enabled = b;
			chkRXOnly7.Enabled = b;
			udPower7.Enabled = b;
			chkXVTRRF7.Enabled = b;
            chkDisablePA7.Enabled = b;
            comboAnt7.Enabled = b;

            console.SetVHFEnabled(7, b);
		}

		private void chkEnable8_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable8.Checked;

 			txtButtonText8.Enabled = b;
			udLOOffset8.Enabled = b;
			udLOError8.Enabled = b;
			udFreqBegin8.Enabled = b;
			udFreqEnd8.Enabled = b;
			udRXGain8.Enabled = b;
			chkRXOnly8.Enabled = b;
			udPower8.Enabled = b;
			chkXVTRRF8.Enabled = b;
            chkDisablePA8.Enabled = b;
            comboAnt8.Enabled = b;

            console.SetVHFEnabled(8, b);
		}

		private void chkEnable9_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable9.Checked;

 			txtButtonText9.Enabled = b;
			udLOOffset9.Enabled = b;
			udLOError9.Enabled = b;
			udFreqBegin9.Enabled = b;
			udFreqEnd9.Enabled = b;
			udRXGain9.Enabled = b;
			chkRXOnly9.Enabled = b;
			udPower9.Enabled = b;
			chkXVTRRF9.Enabled = b;
            chkDisablePA9.Enabled = b;
            comboAnt9.Enabled = b;

            console.SetVHFEnabled(9, b);
		}

		private void chkEnable10_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable10.Checked;

  			txtButtonText10.Enabled = b;
			udLOOffset10.Enabled = b;
			udLOError10.Enabled = b;
			udFreqBegin10.Enabled = b;
			udFreqEnd10.Enabled = b;
			udRXGain10.Enabled = b;
			chkRXOnly10.Enabled = b;
			udPower10.Enabled = b;
			chkXVTRRF10.Enabled = b;
            chkDisablePA10.Enabled = b;
            comboAnt10.Enabled = b;

            console.SetVHFEnabled(10, b);
		}

		private void chkEnable11_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable11.Checked;

 			txtButtonText11.Enabled = b;
			udLOOffset11.Enabled = b;
			udLOError11.Enabled = b;
			udFreqBegin11.Enabled = b;
			udFreqEnd11.Enabled = b;
			udRXGain11.Enabled = b;
			chkRXOnly11.Enabled = b;
			udPower11.Enabled = b;
			chkXVTRRF11.Enabled = b;
            chkDisablePA11.Enabled = b;
            comboAnt11.Enabled = b;

            console.SetVHFEnabled(11, b);
		}

		private void chkEnable12_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable12.Checked;

 			txtButtonText12.Enabled = b;
			udLOOffset12.Enabled = b;
			udLOError12.Enabled = b;
			udFreqBegin12.Enabled = b;
			udFreqEnd12.Enabled = b;
			udRXGain12.Enabled = b;
			chkRXOnly12.Enabled = b;
			udPower12.Enabled = b;
			chkXVTRRF12.Enabled = b;
            chkDisablePA12.Enabled = b;
            comboAnt2.Enabled = b;

            console.SetVHFEnabled(12, b);
		}

		private void chkEnable13_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable13.Checked;

 			txtButtonText13.Enabled = b;
			udLOOffset13.Enabled = b;
			udLOError13.Enabled = b;
			udFreqBegin13.Enabled = b;
			udFreqEnd13.Enabled = b;
			udRXGain13.Enabled = b;
			chkRXOnly13.Enabled = b;
			udPower13.Enabled = b;
			chkXVTRRF13.Enabled = b;
            chkDisablePA13.Enabled = b;
            comboAnt13.Enabled = b;

            console.SetVHFEnabled(13, b);
		}

		private void chkEnable14_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable14.Checked;

			txtButtonText14.Enabled = b;
			udLOOffset14.Enabled = b;
			udLOError14.Enabled = b;
			udFreqBegin14.Enabled = b;
			udFreqEnd14.Enabled = b;
			udRXGain14.Enabled = b;
			chkRXOnly14.Enabled = b;
			udPower14.Enabled = b;
			chkXVTRRF14.Enabled = b;
            chkDisablePA14.Enabled = b;
            comboAnt14.Enabled = b;
        }

		private void chkEnable15_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = chkEnable15.Checked;

 			txtButtonText15.Enabled = b;
			udLOOffset15.Enabled = b;
			udLOError15.Enabled = b;
			udFreqBegin15.Enabled = b;
			udFreqEnd15.Enabled = b;
			udRXGain15.Enabled = b;
			chkRXOnly15.Enabled = b;
			udPower15.Enabled = b;
			chkXVTRRF15.Enabled = b;
            chkDisablePA15.Enabled = b;
            comboAnt15.Enabled = b;
        }

		#endregion 

		private void txtButtonText_TextChanged(object sender, System.EventArgs e)
		{
			int val = Int32.Parse(((Control)sender).Name.Substring(13));
			console.SetVHFText(val, ((TextBoxTS)sender).Text);
		}

		#endregion

		private void chkUseXVTRTUNPWR_CheckedChanged(object sender, System.EventArgs e)
		{
			console.XVTRTunePower = chkUseXVTRTUNPWR.Checked;
		}

		private void chkXVTRRF_CheckedChanged(object sender, System.EventArgs e)
		{
			int index = int.Parse(((Control)sender).Name.Substring(9));
			if(console.RX1XVTRIndex == index)
			{
				console.RX1XVTRIndex = -1; // force reset
				console.VFOAFreq = console.VFOAFreq;
			}

			if(console.RX2XVTRIndex == index)
			{
				console.RX2XVTRIndex = -1; // force reset
				console.VFOBFreq = console.VFOBFreq;
			}

			if(console.TXXVTRIndex == index)
			{
				console.TXXVTRIndex = -1; // force reset
				if(console.RX2Enabled && console.VFOSplit)
					console.VFOASubFreq = console.VFOASubFreq;
				else if(console.VFOSplit)
					console.VFOBFreq = console.VFOBFreq;
				else
					console.VFOAFreq = console.VFOAFreq;
			}
		}

		private void udRXGain_ValueChanged(object sender, System.EventArgs e)
		{
			int index = int.Parse(((Control)sender).Name.Substring(8));
			if(console.RX1XVTRIndex == index)
			{
				console.RX1XVTRIndex = -1; // force reset
				console.VFOAFreq = console.VFOAFreq;
			}

			if(console.RX2XVTRIndex == index)
			{
				console.RX2XVTRIndex = -1; // force reset
				console.VFOBFreq = console.VFOBFreq;
			}
		}

        private void chkAlexTRRelay_CheckedChanged(object sender, EventArgs e)
        {
          //  console.VHFTRRelay = chkAlexTRRelay.Checked;
        }

        public bool AlexTRRelay
        {
            get
            {
                if (chkAlexTRRelay != null) return chkAlexTRRelay.Checked;
                else return false;
            }
            set
            {
                if (chkAlexTRRelay != null) chkAlexTRRelay.Checked = value;
            }
        }

        private void XVTRForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void udPower_ValueChanged(object sender, EventArgs e)
        {
            int index = int.Parse(((Control)sender).Name.Substring(7));
            console.SetPower((Band)((int)Band.VHF0 + index), (int)((NumericUpDownTS)sender).Value);
        }

        private void comboAnt0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ignore_combo_events) return;

            int index = int.Parse(((Control)sender).Name.Substring(8));
            if (console.RX1XVTRIndex == index)
            {
                console.RX1XVTRIndex = -1; // force reset
                console.VFOAFreq = console.VFOAFreq;
            }
        }

        private void XVTRForm_Activated(object sender, EventArgs e)
        {
            if (console.SetupForm.HL2IOBoardPresent == true)    // MI0BOT: Make Alt rx option available only for the HL2 with I/O Board
            {
                if (!comboAnt0.Items.Contains("Alt Rx"))
                {
                    comboAnt0.Items.Add("Alt Rx");
                    comboAnt1.Items.Add("Alt Rx");
                    comboAnt2.Items.Add("Alt Rx");
                    comboAnt3.Items.Add("Alt Rx");
                    comboAnt4.Items.Add("Alt Rx");
                    comboAnt5.Items.Add("Alt Rx");
                    comboAnt6.Items.Add("Alt Rx");
                    comboAnt7.Items.Add("Alt Rx");
                    comboAnt8.Items.Add("Alt Rx");
                    comboAnt9.Items.Add("Alt Rx");
                    comboAnt10.Items.Add("Alt Rx");
                    comboAnt11.Items.Add("Alt Rx");
                    comboAnt12.Items.Add("Alt Rx");
                    comboAnt13.Items.Add("Alt Rx");
                    comboAnt14.Items.Add("Alt Rx");
                    comboAnt15.Items.Add("Alt Rx");
                }
            }
            else
            {
                if (comboAnt0.Items.Contains("Alt Rx"))
                {
                    comboAnt0.Items.Remove("Alt Rx");
                    comboAnt1.Items.Remove("Alt Rx");
                    comboAnt2.Items.Remove("Alt Rx");
                    comboAnt3.Items.Remove("Alt Rx");
                    comboAnt4.Items.Remove("Alt Rx");
                    comboAnt5.Items.Remove("Alt Rx");
                    comboAnt6.Items.Remove("Alt Rx");
                    comboAnt7.Items.Remove("Alt Rx");
                    comboAnt8.Items.Remove("Alt Rx");
                    comboAnt9.Items.Remove("Alt Rx");
                    comboAnt10.Items.Remove("Alt Rx");
                    comboAnt11.Items.Remove("Alt Rx");
                    comboAnt12.Items.Remove("Alt Rx");
                    comboAnt13.Items.Remove("Alt Rx");
                    comboAnt14.Items.Remove("Alt Rx");
                    comboAnt15.Items.Remove("Alt Rx");
                }
            }
        }
    }
}
