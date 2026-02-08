using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGLDotNet;
using System.Media;
using System.Runtime.InteropServices;

namespace BASE_OPEN_GL
{
  public class C_DECOR
  {
    public bool Son = true;
    public bool Pos_Souris_Info = true;
    public int Score = 0;

    public double Taille = 0.5;
    public int Qualite = 30;
    public string Description_Qualite = "moyen";

    public int Souris_X;
    public int Souris_Y;

    //..............................................

    public void Joue_Son()
    {

    }

    public void Change_Param_Son()
    {
      if (Son == true) {
        Son = false;
      } else {
        Son = true;
      }
    }

    public void Change_Param_Pos_Souris()
    {
      if (Pos_Souris_Info == true) {
        Pos_Souris_Info = false;
      } else {
        Pos_Souris_Info = true;
      }
    }

    public string Return_Param_Pos_Souris()
    {
      if (Pos_Souris_Info == false) {
        return "OFF";
      } else {
        return "ON";
      }
    }

    public string Return_Etat_Son()
    {
      if (Son == false) {
        return "OFF";
      } else {
        return "ON";
      }
    }

    public string Return_Description_Qualite()
    {
      if (Qualite < 6 || Qualite == 6) {
        Description_Qualite = "Minimum";
        Qualite = 6;
      }
      if (Qualite < 10 && Qualite > 6) {
        Description_Qualite = "Faible";
      }
      if (Qualite < 30 && Qualite > 9) {
        Description_Qualite = "Moyen";
      }
      if (Qualite < 50 && Qualite > 29) {
        Description_Qualite = "Élevé";
      }
      if (Qualite < 80 && Qualite > 49) {
        Description_Qualite = "Très Élevé";
      }
      if (Qualite < 100 && Qualite > 79) {
        Description_Qualite = "Ultra";
      }
      if (Qualite > 100 || Qualite == 100) {
        Description_Qualite = "Maximum";
        Qualite = 100;
      }
      return Description_Qualite;
    }

    public int Return_Qualite()
    {
      return Qualite;
    }

    public int Return_Score()
    {
      return Score;
    }

    public int[] Return_Pos_Souris()
    {
      int[] Tableau = new int[2] { Souris_X, Souris_Y };
      return Tableau;
    }

    public void Get_Pos_Souris(int P_Souris_X, int P_Souris_Y)
    {
      Souris_X = P_Souris_X;
      Souris_Y = P_Souris_Y;
    }

    public void Change_Param_Qualite(bool P_Qualite_Plus, bool P_Qualite_Moins)
    {
      if (P_Qualite_Plus == true) Qualite++;
      if (P_Qualite_Moins == true) Qualite--;
    }

    //public void Afficher()
    //{
    //  GL.Begin(GL.GL_LINE_STRIP);
    //    GL.Vertex2f(-2, -0.5F);
    //    GL.Vertex2f(-2, 0.5F);
    //    GL.Vertex2f(2, 0.5F);
    //    GL.Vertex2f(2, -0.5F);
    //    GL.Vertex2f(-2, -0.5F);
    //  GL.End();
    //}
  }
}