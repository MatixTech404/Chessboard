namespace Chessboard
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSzach = new Panel();
            menuStrip1 = new MenuStrip();
            graToolStripMenuItem = new ToolStripMenuItem();
            nowaGraToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            wyjdźToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelSzach
            // 
            panelSzach.Location = new Point(12, 27);
            panelSzach.Name = "panelSzach";
            panelSzach.Size = new Size(400, 400);
            panelSzach.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { graToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // graToolStripMenuItem
            // 
            graToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nowaGraToolStripMenuItem, toolStripSeparator1, wyjdźToolStripMenuItem });
            graToolStripMenuItem.Name = "graToolStripMenuItem";
            graToolStripMenuItem.Size = new Size(38, 20);
            graToolStripMenuItem.Text = "Plik";
            // 
            // nowaGraToolStripMenuItem
            // 
            nowaGraToolStripMenuItem.Name = "nowaGraToolStripMenuItem";
            nowaGraToolStripMenuItem.Size = new Size(126, 22);
            nowaGraToolStripMenuItem.Text = "Nowa Gra";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(123, 6);
            // 
            // wyjdźToolStripMenuItem
            // 
            wyjdźToolStripMenuItem.Name = "wyjdźToolStripMenuItem";
            wyjdźToolStripMenuItem.Size = new Size(126, 22);
            wyjdźToolStripMenuItem.Text = "Wyjdź";
            // 
            // button1
            // 
            button1.Location = new Point(418, 404);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Zrezygnuj";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 435);
            Controls.Add(button1);
            Controls.Add(panelSzach);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelSzach;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem graToolStripMenuItem;
        private ToolStripMenuItem nowaGraToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem wyjdźToolStripMenuItem;
        private Button button1;
    }
}