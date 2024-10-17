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
  class C_MONDE
  {
    public C_CARTE Carte = new C_CARTE();

    //....................................

    public string Etat_Son()
    {
      return Carte.Return_Etat_Son();
    }

    public int[] Pos_Souris()
    {
      return Carte.Return_Pos_Souris();
    }

    public void Get_Pos_Souris(int P_Souris_X, int P_Souris_Y)
    {
      Carte.Get_Pos_Souris(P_Souris_X, P_Souris_Y);
    }

    public void Change_Param_Pos_Souris()
    {
      Carte.Change_Param_Pos_Souris();
    }

    public string Param_Pos_Souris()
    {
      return Carte.Return_Param_Pos_Souris();
    }

    public int Score()
    {
      return Carte.Return_Score();
    }

    public int Qualite_Decor()
    {
      return Carte.Return_Qualite_Decor();
    }

    public string Description_Qualite()
    {
      return Carte.Return_Description_Qualite();
    }

    public void Change_Param_Son()
    {
      Carte.Change_Paramettre_Son();
    }

    public void Change_Param_Qualite(bool P_Qualite_Plus, bool P_Qualite_Moins)
    {
      Carte.Change_Param_Qualite(P_Qualite_Plus, P_Qualite_Moins);
    }

    public void Initialisation()
    {
      Carte.Initialise_Limite();
      Carte.Initialise_Murs_Random();
      Carte.Innitialise_Consommables();
    }

    public void Afficher_Carte()
    {
      GL.Translated(-10, -9.5, 0);
      Carte.Afficher();
    }

    public void Deplace_Balle(int P_Direction_X, int P_Direction_Y)
    {
      Carte.Deplacer_Balle(P_Direction_X, P_Direction_Y);
    }

    public void Save(string P_Nom)
    {
      Carte.Sauvegarde(P_Nom);
    }

    public void Charge(string P_Nom)
    {
      Carte.Charge(P_Nom);
    }
  }
}