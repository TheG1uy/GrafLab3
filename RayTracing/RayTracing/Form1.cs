using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace RayTracing
{
    public partial class Form1 : Form
    {
        Graphics gr;
        RayTracing scene;
        public Form1()
        {
            InitializeComponent();
            gr = new Graphics();
            scene = new RayTracing();
        }

        
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            // gr.Update();
            scene.Update();
            glControl1.SwapBuffers();
            //gr.closeProgram();
            scene.closeProgram();
        }
        private void Application_Idle(object sender, PaintEventArgs e)
        {
            
                glControl1_Paint(sender, e);
            
        }
        private void glControl1_Load(object sender, EventArgs e)
        {
            scene.Resize(glControl1.Width, glControl1.Height);
            //gr.Resize(glControl1.Width, glControl1.Height);
        }


    }
}
