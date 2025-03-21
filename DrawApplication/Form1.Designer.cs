﻿namespace DrawApplication
{
    partial class DrawCase
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
            panelDrawing = new Panel();
            Cizimİslemleri = new GroupBox();
            btnCircle = new Button();
            btnRectangle = new Button();
            btnTriangle = new Button();
            btnHexagon = new Button();
            Renkİslemleri = new GroupBox();
            btnOrange = new Button();
            btnBlack = new Button();
            btnYellow = new Button();
            btnPurple = new Button();
            btnBrown = new Button();
            btnWhite = new Button();
            btnGreen = new Button();
            btnBlue = new Button();
            btnRed = new Button();
            SekilIslemleri = new GroupBox();
            btnSelect = new Button();
            btnClean = new Button();
            btnDelete = new Button();
            Dosyaİslemleri = new GroupBox();
            btnSaveFile = new Button();
            btnOpenFile = new Button();
            OperationsGroup = new GroupBox();
            ShapePosition = new Label();
            Cizimİslemleri.SuspendLayout();
            Renkİslemleri.SuspendLayout();
            SekilIslemleri.SuspendLayout();
            Dosyaİslemleri.SuspendLayout();
            OperationsGroup.SuspendLayout();
            SuspendLayout();
            // 
            // panelDrawing
            // 
            panelDrawing.BackColor = Color.White;
            panelDrawing.BorderStyle = BorderStyle.FixedSingle;
            panelDrawing.Dock = DockStyle.Fill;
            panelDrawing.Location = new Point(0, 0);
            panelDrawing.Name = "panelDrawing";
            panelDrawing.RightToLeft = RightToLeft.Yes;
            panelDrawing.Size = new Size(1404, 792);
            panelDrawing.TabIndex = 1;
            panelDrawing.Paint += panelDrawing_Paint;
            panelDrawing.MouseClick += panelDrawing_MouseClick;
            panelDrawing.MouseDown += panelDrawing_MouseDown;
            panelDrawing.MouseMove += panelDrawing_MouseMove;
            panelDrawing.MouseUp += panelDrawing_MouseUp;
            // 
            // Cizimİslemleri
            // 
            Cizimİslemleri.Controls.Add(btnCircle);
            Cizimİslemleri.Controls.Add(btnRectangle);
            Cizimİslemleri.Controls.Add(btnTriangle);
            Cizimİslemleri.Controls.Add(btnHexagon);
            Cizimİslemleri.Location = new Point(12, 12);
            Cizimİslemleri.Name = "Cizimİslemleri";
            Cizimİslemleri.Size = new Size(245, 172);
            Cizimİslemleri.TabIndex = 0;
            Cizimİslemleri.TabStop = false;
            Cizimİslemleri.Text = "Çizim İşlemleri";
            // 
            // btnCircle
            // 
            btnCircle.Image = Properties.Resources._4;
            btnCircle.Location = new Point(131, 26);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(68, 60);
            btnCircle.TabIndex = 3;
            btnCircle.UseVisualStyleBackColor = true;
            btnCircle.Click += btnCircle_Click;
            // 
            // btnRectangle
            // 
            btnRectangle.Image = Properties.Resources._5;
            btnRectangle.Location = new Point(41, 26);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(68, 60);
            btnRectangle.TabIndex = 4;
            btnRectangle.Click += btnRectangle_Click;
            // 
            // btnTriangle
            // 
            btnTriangle.Image = Properties.Resources._2;
            btnTriangle.Location = new Point(41, 106);
            btnTriangle.Name = "btnTriangle";
            btnTriangle.Size = new Size(68, 60);
            btnTriangle.TabIndex = 1;
            btnTriangle.UseVisualStyleBackColor = true;
            btnTriangle.Click += btnTriangle_Click;
            // 
            // btnHexagon
            // 
            btnHexagon.Image = Properties.Resources._3;
            btnHexagon.Location = new Point(131, 106);
            btnHexagon.Name = "btnHexagon";
            btnHexagon.Size = new Size(68, 60);
            btnHexagon.TabIndex = 0;
            btnHexagon.UseVisualStyleBackColor = true;
            btnHexagon.Click += btnHexagon_Click;
            // 
            // Renkİslemleri
            // 
            Renkİslemleri.Controls.Add(btnOrange);
            Renkİslemleri.Controls.Add(btnBlack);
            Renkİslemleri.Controls.Add(btnYellow);
            Renkİslemleri.Controls.Add(btnPurple);
            Renkİslemleri.Controls.Add(btnBrown);
            Renkİslemleri.Controls.Add(btnWhite);
            Renkİslemleri.Controls.Add(btnGreen);
            Renkİslemleri.Controls.Add(btnBlue);
            Renkİslemleri.Controls.Add(btnRed);
            Renkİslemleri.Location = new Point(21, 190);
            Renkİslemleri.Name = "Renkİslemleri";
            Renkİslemleri.Size = new Size(236, 205);
            Renkİslemleri.TabIndex = 1;
            Renkİslemleri.TabStop = false;
            Renkİslemleri.Text = "Renk İşlemleri";
            // 
            // btnOrange
            // 
            btnOrange.BackColor = Color.Orange;
            btnOrange.Location = new Point(22, 83);
            btnOrange.Name = "btnOrange";
            btnOrange.Size = new Size(62, 51);
            btnOrange.TabIndex = 1;
            btnOrange.UseVisualStyleBackColor = false;
            btnOrange.Click += btnOrange_Click;
            // 
            // btnBlack
            // 
            btnBlack.BackColor = Color.Black;
            btnBlack.Location = new Point(99, 83);
            btnBlack.Name = "btnBlack";
            btnBlack.Size = new Size(62, 51);
            btnBlack.TabIndex = 2;
            btnBlack.UseVisualStyleBackColor = false;
            btnBlack.Click += btnBlack_Click;
            // 
            // btnYellow
            // 
            btnYellow.BackColor = Color.Yellow;
            btnYellow.ForeColor = SystemColors.ControlText;
            btnYellow.Location = new Point(167, 83);
            btnYellow.Name = "btnYellow";
            btnYellow.Size = new Size(62, 51);
            btnYellow.TabIndex = 3;
            btnYellow.UseVisualStyleBackColor = false;
            btnYellow.Click += btnYellow_Click;
            // 
            // btnPurple
            // 
            btnPurple.BackColor = Color.Purple;
            btnPurple.Location = new Point(22, 140);
            btnPurple.Name = "btnPurple";
            btnPurple.Size = new Size(62, 51);
            btnPurple.TabIndex = 4;
            btnPurple.UseVisualStyleBackColor = false;
            btnPurple.Click += btnPurple_Click;
            // 
            // btnBrown
            // 
            btnBrown.BackColor = Color.Brown;
            btnBrown.Location = new Point(99, 140);
            btnBrown.Name = "btnBrown";
            btnBrown.Size = new Size(62, 51);
            btnBrown.TabIndex = 5;
            btnBrown.UseVisualStyleBackColor = false;
            btnBrown.Click += btnBrown_Click;
            // 
            // btnWhite
            // 
            btnWhite.BackColor = Color.White;
            btnWhite.Location = new Point(167, 140);
            btnWhite.Name = "btnWhite";
            btnWhite.Size = new Size(62, 51);
            btnWhite.TabIndex = 6;
            btnWhite.UseVisualStyleBackColor = false;
            btnWhite.Click += btnWhite_Click;
            // 
            // btnGreen
            // 
            btnGreen.BackColor = Color.Green;
            btnGreen.Location = new Point(167, 26);
            btnGreen.Name = "btnGreen";
            btnGreen.Size = new Size(62, 51);
            btnGreen.TabIndex = 2;
            btnGreen.UseVisualStyleBackColor = false;
            btnGreen.Click += btnGreen_Click;
            // 
            // btnBlue
            // 
            btnBlue.BackColor = Color.Blue;
            btnBlue.Location = new Point(99, 26);
            btnBlue.Name = "btnBlue";
            btnBlue.Size = new Size(62, 51);
            btnBlue.TabIndex = 1;
            btnBlue.UseVisualStyleBackColor = false;
            btnBlue.Click += btnBlue_Click;
            // 
            // btnRed
            // 
            btnRed.BackColor = Color.Red;
            btnRed.Location = new Point(22, 26);
            btnRed.Name = "btnRed";
            btnRed.Size = new Size(62, 51);
            btnRed.TabIndex = 0;
            btnRed.UseVisualStyleBackColor = false;
            btnRed.Click += btnRed_Click;
            // 
            // SekilIslemleri
            // 
            SekilIslemleri.Controls.Add(btnSelect);
            SekilIslemleri.Controls.Add(btnClean);
            SekilIslemleri.Controls.Add(btnDelete);
            SekilIslemleri.Location = new Point(21, 413);
            SekilIslemleri.Name = "SekilIslemleri";
            SekilIslemleri.Size = new Size(236, 125);
            SekilIslemleri.TabIndex = 1;
            SekilIslemleri.TabStop = false;
            SekilIslemleri.Text = "Şekil İşlemleri";
            // 
            // btnSelect
            // 
            btnSelect.Image = Properties.Resources._6;
            btnSelect.Location = new Point(22, 26);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(62, 70);
            btnSelect.TabIndex = 10;
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnClean
            // 
            btnClean.Image = Properties.Resources._8;
            btnClean.Location = new Point(158, 26);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(62, 70);
            btnClean.TabIndex = 9;
            btnClean.UseVisualStyleBackColor = true;
            btnClean.Click += btnClean_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = Properties.Resources._7;
            btnDelete.Location = new Point(90, 26);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(62, 70);
            btnDelete.TabIndex = 8;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // Dosyaİslemleri
            // 
            Dosyaİslemleri.Controls.Add(btnSaveFile);
            Dosyaİslemleri.Controls.Add(btnOpenFile);
            Dosyaİslemleri.Location = new Point(21, 544);
            Dosyaİslemleri.Name = "Dosyaİslemleri";
            Dosyaİslemleri.Size = new Size(236, 125);
            Dosyaİslemleri.TabIndex = 1;
            Dosyaİslemleri.TabStop = false;
            Dosyaİslemleri.Text = "Dosya İşlemleri";
            // 
            // btnSaveFile
            // 
            btnSaveFile.Image = Properties.Resources._10;
            btnSaveFile.Location = new Point(39, 42);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(76, 60);
            btnSaveFile.TabIndex = 10;
            btnSaveFile.UseVisualStyleBackColor = true;
            btnSaveFile.Click += btnSaveFile_Click;
            // 
            // btnOpenFile
            // 
            btnOpenFile.Image = Properties.Resources._9;
            btnOpenFile.Location = new Point(142, 42);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(73, 60);
            btnOpenFile.TabIndex = 11;
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // OperationsGroup
            // 
            OperationsGroup.Controls.Add(ShapePosition);
            OperationsGroup.Controls.Add(Dosyaİslemleri);
            OperationsGroup.Controls.Add(Cizimİslemleri);
            OperationsGroup.Controls.Add(SekilIslemleri);
            OperationsGroup.Controls.Add(Renkİslemleri);
            OperationsGroup.Dock = DockStyle.Right;
            OperationsGroup.Location = new Point(1135, 0);
            OperationsGroup.Name = "OperationsGroup";
            OperationsGroup.Size = new Size(269, 792);
            OperationsGroup.TabIndex = 2;
            OperationsGroup.TabStop = false;
            // 
            // ShapePosition
            // 
            ShapePosition.AutoSize = true;
            ShapePosition.Location = new Point(43, 695);
            ShapePosition.Name = "ShapePosition";
            ShapePosition.Size = new Size(0, 20);
            ShapePosition.TabIndex = 2;
            // 
            // DrawCase
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1404, 792);
            Controls.Add(OperationsGroup);
            Controls.Add(panelDrawing);
            Name = "DrawCase";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DrawCase";
            WindowState = FormWindowState.Maximized;
            Cizimİslemleri.ResumeLayout(false);
            Renkİslemleri.ResumeLayout(false);
            SekilIslemleri.ResumeLayout(false);
            Dosyaİslemleri.ResumeLayout(false);
            OperationsGroup.ResumeLayout(false);
            OperationsGroup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelDrawing;
        private GroupBox Cizimİslemleri;
        private GroupBox Renkİslemleri;
        private GroupBox SekilIslemleri;
        private GroupBox Dosyaİslemleri;
        private Button btnCircle;
        private Button btnRectangle;
        private Button btnTriangle;
        private Button btnHexagon;
        private Button btnGreen;
        private Button btnBlue;
        private Button btnRed;
        private Button btnOrange;
        private Button btnBlack;
        private Button btnYellow;
        private Button btnPurple;
        private Button btnBrown;
        private Button btnWhite;
        private Button btnSelect;
        private Button btnClean;
        private Button btnDelete;
        private Button btnSaveFile;
        private Button btnOpenFile;
        private GroupBox OperationsGroup;
        private Label ShapePosition;
    }
}
