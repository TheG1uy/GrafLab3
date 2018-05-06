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
    class Shaders
    {
        string glVersion;
        string glsVersion;
        int BasicProgramID;
        int BasicVertexShader;
        int BasicFragmentShader;
        int[] vboHandlers = new int[2];
        int vaoHandle;
        Shaders()
        {
            glVersion = GL.GetString(StringName.Version);
            glsVersion = GL.GetString(StringName.ShadingLanguageVersion);
        }

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
            Console.WriteLine(GL.GetShaderInfoLog(addres));
        }

        private void InitShaders()
        {
            //Создание программы
            BasicProgramID = GL.CreateProgram();
            loadShader("..\\basic.fs", ShaderType.VertexShader, BasicProgramID, out BasicVertexShader);
            loadShader("..\\basic.vs", ShaderType.FragmentShader, BasicProgramID, out BasicFragmentShader);

            //Линковка программы
            GL.LinkProgram(BasicProgramID);

            int status = 0;
            GL.GetProgram(BasicProgramID, GetProgramParameterName.LinkStatus, out status);
            Console.WriteLine(GL.GetProgramInfoLog(BasicProgramID));
            float[] positionData = { -0.8f, -0.8f, 0.0f, 0.8f, -0.8f, 0.0f, 0.0f, 0.8f, 0.0f };
            float[] colorData = { 1.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f };
            GL.GenBuffers(2, vboHandlers);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandlers[0]);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(sizeof(float) * positionData.Length),
                            positionData, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandlers[1]);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(sizeof(float) * colorData.Length),
                            colorData, BufferUsageHint.StaticDraw);
            vaoHandle = GL.GenVertexArray();
            GL.BindVertexArray(vaoHandle);
            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandlers[0]);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandlers[1]);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 0, 0);
        }

    }
}
