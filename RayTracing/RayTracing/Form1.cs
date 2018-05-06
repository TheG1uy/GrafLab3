﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RayTracing
{
    public partial class Form1 : Form
    {
        Graphics gr;
        public Form1()
        {
            InitializeComponent();
            gr = new Graphics();
        }

        
private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            gr.Update();
            glControl1.SwapBuffers();
            gr.closeProgram();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            gr.Resize(glControl1.Width, glControl1.Height);
        }
    }
}
