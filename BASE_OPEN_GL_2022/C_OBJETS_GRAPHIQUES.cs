using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGLDotNet;

namespace BASE_OPEN_GL
{
  abstract class C_OBJETS_GRAPHIQUE
  {
    public int Code;

    //................................

    public abstract void Afficher(int P_Qualite);
  }
}