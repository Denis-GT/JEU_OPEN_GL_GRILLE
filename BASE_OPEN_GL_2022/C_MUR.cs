using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Security.Policy;
using System.Text;
using System.Threading;
using Microsoft.SqlServer.Server;
using OpenGLDotNet;



namespace BASE_OPEN_GL
{
  class C_MUR : C_OBJETS_GRAPHIQUE
  {
    new public int Code = 1;

    public int Nombre = 40;
    public int X;
    public int Y;

    //........................

    public override void Afficher(int P_Qualite)
    {
      GL.Color3b(0, 30, 60);
      FG.SolidCube(1);
    }
  }
}

