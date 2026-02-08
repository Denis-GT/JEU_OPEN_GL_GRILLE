using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using OpenGLDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Security.Policy;
using System.Text;
using System.Threading;



namespace BASE_OPEN_GL
{
   class C_MONDE
   {
      public (int X, int Y) Direcion_Balle { get; set; }
      public C_CONFIGURATION_JEU Configuration_Jeu { get; set; }

      public C_CARTE Carte;
      public C_MONDE()
      {
         string Data_Json = File.ReadAllText("CONFIGURATION_JEU.json");
         Configuration_Jeu = JsonConvert.DeserializeObject<C_CONFIGURATION_JEU>(Data_Json);
         int X = Configuration_Jeu.Taille_Carte_X < 3 ? 3 : Configuration_Jeu.Taille_Carte_X;
         int Y = Configuration_Jeu.Taille_Carte_Y < 3 ? 3 : Configuration_Jeu.Taille_Carte_Y;
         Carte = new C_CARTE(X, Y);
      }

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
         double X = Configuration_Jeu.Taille_Carte_X * -0.5;
         double Y = Configuration_Jeu.Taille_Carte_Y * -0.475;
         double Z = -((Configuration_Jeu.Taille_Carte_X + Configuration_Jeu.Taille_Carte_Y) / 2) + 20;
         if (Z < -80) Z = -80;

         GL.Translated(X, Y, Z);
         Carte.Afficher();
      }

      public void Deplace_Balle()
      {
         Carte.Deplacer_Balle(Direcion_Balle.X, Direcion_Balle.Y);
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