using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGLDotNet;

namespace BASE_OPEN_GL
{
  class C_CONSOMMABLE : C_OBJETS_GRAPHIQUE
  {
    new public int Code = 3;

    public int Nombre = 30;
    public int X;
    public int Y;

    //.............................

    public override void Afficher(int P_Qualite)
    {
      GL.Color3b(0, 70, 0);
      FG.SolidTorus(0.1, 0.3, 10, P_Qualite);
    }
  }
}