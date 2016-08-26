// <copyright file="MainForm.cs" company="www.PublicDomain.tech">All rights waived.</copyright>

// Programmed by Victor L. Senior (VLS) <support@publicdomain.tech>, 2016
//
// Web: http://publicdomain.tech
//
// Sources: http://github.com/publicdomaintech/
//
// This software and associated documentation files (the "Software") is
// released under the CC0 Public Domain Dedication, version 1.0, as
// published by Creative Commons. To the extent possible under law, the
// author(s) have dedicated all copyright and related and neighboring
// rights to the Software to the public domain worldwide. The Software is
// distributed WITHOUT ANY WARRANTY.
//
// If you did not receive a copy of the CC0 Public Domain Dedication
// along with the Software, see
// <http://creativecommons.org/publicdomain/zero/1.0/>

/// <summary>
/// Main form.
/// </summary>
namespace Felt_32_European_32_Input_32_Tracker
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The history list.
        /// </summary>
        private List<int> historyList = new List<int>();

        /// <summary>
        /// The number appearances list.
        /// </summary>
        private List<int> numberAppearancesList = new List<int>();

        /// <summary>
        /// The number color list.
        /// </summary>
        private List<Color> numberColorList = new List<Color>();

        /// <summary>
        /// The default number color list.
        /// </summary>
        private List<Color> defaultNumberColorList = new List<Color>();

        /// <summary>
        /// The last reset spin.
        /// </summary>
        private int lastResetSpin = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Felt_32_European_32_Input_32_Tracker.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            // Set default number color list
            for (int i = 0; i < 37; i++)
            {
                // Set appearances
                this.numberAppearancesList.Add(0);

                // Set number color
                Color numberColor = this.Controls.Find("button" + i.ToString(), true)[0].BackColor;

                // Add to default number color list
                this.defaultNumberColorList.Add(numberColor);
            }

            // Set number color list
            for (int i = 0; i <= 10; i++)
            {
                // Colors by appearances
                switch (i)
                {
                // First
                    case 1:

                        // Yellow
                        this.numberColorList.Add(Color.Yellow);

                        // Halt flow
                        break;

                // Second
                    case 2:

                        // Set cyan
                        this.numberColorList.Add(Color.Cyan);

                        // Halt flow
                        break;

                // Third+
                    default:

                        // Set light pink
                        this.numberColorList.Add(Color.LightPink);

                        // Halt flow
                        break;
                }
            }
        }

        /// <summary>
        /// Raises the reset button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnResetButtonClick(object sender, EventArgs e)
        {
            // Code here
        }

        /// <summary>
        /// Raises the number button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNumberButtonClick(object sender, EventArgs e)
        {
            // Holds last number
            int lastNumber;

            // Try to parse last number
            if (!int.TryParse(((Button)sender).Name.Replace("button", string.Empty), out lastNumber))
            {
                // Halt flow
                return;
            }

            /* Process SPIN */

            // Validate range
            if (lastNumber >= 0 && lastNumber <= 36)
            {
                // Rise appearances
                this.numberAppearancesList[lastNumber]++;

                // Add to history list
                this.historyList.Add(lastNumber);

                // Colorize buttons
                this.ColorizeNumberButtons();
            }
        }

        /// <summary>
        /// Colorizes the number buttons.
        /// </summary>
        private void ColorizeNumberButtons()
        {
            // Colorize buttons
            for (int n = 0; n < 37; n++)
            {
                // Set current number button
                Button numberButton = (Button)this.mainTableLayoutPanel.Controls.Find("button" + n.ToString(), false)[0];

                // Update button fore color
                if (this.numberAppearancesList[n] > 0)
                {
                    // Set fore color to black
                    numberButton.ForeColor = Color.Black;

                    try
                    {
                        // Set back color
                        numberButton.BackColor = this.numberColorList[this.numberAppearancesList[n]];   
                    }
                    catch (Exception ex)
                    {
                        // TODO Use 3+ color [Perhaps add default color for 10+]
                        numberButton.BackColor = Color.LightPink;
                    }
                }

                if (this.numberAppearancesList[n] == 0)
                {
                    // Set fore color to white
                    numberButton.ForeColor = Color.White;

                    // Set default back color
                    numberButton.BackColor = this.defaultNumberColorList[n];
                }
            }

            // Compute reset difference
            int resetDifference = this.historyList.Count - this.lastResetSpin;

            // Update reset button count
            this.resetButton.Text = "Reset" + ((resetDifference < 1) ? string.Empty : " (" + resetDifference.ToString() + ")");

            // Set appended spins text
            string appendedSpinsText = this.historyList.Count == 0 ? string.Empty : " | " + this.historyList.Count.ToString() + " spin" + (this.historyList.Count > 1 ? "s" : string.Empty);
        }

        /// <summary>
        /// Raises the main form load event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormLoad(object sender, EventArgs e)
        {
            // Code here
        }

        /// <summary>
        /// Raises the new tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNewToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Code here
        }

        /// <summary>
        /// Raises the about tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Code here
        }

        /// <summary>
        /// Raises the undo tool strip menu item click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnUndoToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Code here
        }
    }
}
