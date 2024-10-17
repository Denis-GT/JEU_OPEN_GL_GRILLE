using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGLDotNet;

namespace BASE_OPEN_GL
{
  class C_PERSONNAGE : C_OBJETS_GRAPHIQUE
  {
    new public int Code = 2;

    public double Taille = 0.5;

    public int Position_X = 1;
    public int Position_Y = 1;

    public int Direction_X;
    public int Direction_Y;

    public int Precedente_Position_Personnage_X;
    public int Precedente_Position_Personnage_Y;

    //............................................................

    public override void Afficher(int P_Qualite)
    {
      GL.Color3b(100, 100, 100);
      FG.SolidSphere(Taille, P_Qualite, 13);
    }

    public void Deplacement()
    {
      Precedente_Position_Personnage_X = Position_X;
      Precedente_Position_Personnage_Y = Position_Y;
      Position_X = Position_X + Direction_X;
      Position_Y = Position_Y + Direction_Y;

      Direction_Y = 0;
      Direction_X = 0;
    }
  }
}