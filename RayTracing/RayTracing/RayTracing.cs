using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace RayTracing
{
    class RayTracing
    {
        int BasicProgramID;
        int BasicVertexShader;             
        int BasicFragmentShader;
        void loadShader(String filename, ShaderType type, int program, out int addres)
        {
            addres = GL.CreateShader(type);
            if (addres == 0)
            {
                throw new Exception("Error, can't create shader");
            }
            using (StreamReader sr = new StreamReader(filename))
            {
                GL.ShaderSource(addres, sr.ReadToEnd());
            }
            GL.CompileShader(addres);
            GL.AttachShader(program, addres);
        }

        private void InitShaders()
        {
            BasicProgramID = GL.CreateProgram();
            loadShader("..\\raytracing.vert", ShaderType.VertexShader, BasicProgramID, out BasicVertexShader);
            loadShader("..\\raytracing.frag", ShaderType.FragmentShader, BasicProgramID, out BasicFragmentShader);
            GL.LinkProgram(BasicProgramID);
        }

    }
}
