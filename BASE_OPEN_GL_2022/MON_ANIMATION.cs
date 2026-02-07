using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Security.Policy;
using System.Text;
using System.Threading;
using Microsoft.SqlServer.Server;
using OpenGLDotNet;
using System.CodeDom;
using System.IO;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;

//using System.Text.Json;


/*
 * 
 * 
 * Exemple de base d'une application OPENGL. Cet exemple est destiné au SIO 1B CCI de nimes. 
 * C'est une base pour développer un ensemble de projets - session 2022
 */
namespace BASE_OPEN_GL
{

  partial class Program
  {
    static C_MONDE Monde;

    static double IPS;
    static double Compteur_Images;
    static Stopwatch Chrono;



    static void Initialisation_Animation()
    {
      FG.FullScreen();
      Monde = new C_MONDE();
      Chrono = new Stopwatch();
      Monde.Initialisation();
      Chrono.Start();

      OPENGL_Active_Reflexion();
    }

    static void Afficher_Ma_Scene()
    {

      GL.Color3b(100, 100, 100);
      OPENGL_Affiche_Chaine(12, 8, "Score : " + Monde.Score(), 8);
      OPENGL_Affiche_Chaine(12, 7, "Qualité du décor (Molette) : " + Monde.Description_Qualite() + " : " + Monde.Qualite_Decor(), 8);
      OPENGL_Affiche_Chaine(12, 6, "Son (N) : " + Monde.Etat_Son(), 8);
      OPENGL_Affiche_Chaine(-18, 5, "IPS : " + IPS, 8);
      OPENGL_Affiche_Chaine(12, 5, "Coord souris (M) : " + Monde.Param_Pos_Souris(), 8);
      //OPENGL_Affiche_Chaine(12, 4, "Sauvegarder (Ecrase la sauvegarde précédente) (Y)", 8);
      //OPENGL_Affiche_Chaine(12, 3, "Charger la dernière sauvegarde (T)", 8);
      if (Monde.Param_Pos_Souris() == "ON") {
        OPENGL_Affiche_Chaine(17, -6, "Souris_X : " + Monde.Pos_Souris()[0], 8);
        OPENGL_Affiche_Chaine(17, -7, "Souris_Y : " + Monde.Pos_Souris()[1], 8);
      }
      //OPENGL_Affiche_Chaine(17, -10, "Paramètres", 8);
      //OPENGL_Affiche_Chaine(16.75f, -8, "Sauvegarder", 8);
      //if (Sauver) {
      //  OPENGL_Affiche_Chaine(16.75f, -4, "Sauvegarde", 8);
      //}


      Monde.Afficher_Carte();

      // Calculateur IPS ---------------------------------------------------------------------------------------------------------------

      Compteur_Images++;

      if (Chrono.ElapsedMilliseconds >= 1000) {
        IPS = Compteur_Images;
        Compteur_Images = 0;
        Chrono.Restart();
      }
    }
    
    //=========================================================
    // cette fonction est invoquée en boucle par openGl.
    // Peut être utilisée pour modifier des variables globales utilisée dans "Afficher_Ma_Scene"
    static void Animation_Scene()
    {
      //fortement recommandé
      FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }

    //======================================================================
    // cette fonction est invoquée par OpenGl lorsqu'on appuie sur une touche spéciale (flèches, Fx, ...)
    // P_Touche contient le code de la touche, P_X et P_Y contiennent les coordonnées de la souris quand on appuie sur une touche
    static void Gestion_Touches_Speciales(int P_Touche, int P_X, int P_Y)
    {
      //if (P_Touche == FG.GLUT_KEY_F1) FG.FullScreen();
      //if (P_Touche == FG.GLUT_KEY_F2) FG.LeaveFullScreen();

      //fortement recommandé
      FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }

    //======================================================================
    // cette fonction est invoquée par OpenGl lorsqu'on appuie sur une touche normale (A,Z,E, ...)
    // P_Touche contient le code de la touche, P_X et P_Y contiennent les coordonnées de la souris quand on appuie sur une touche
    static void Gestion_Clavier(byte P_Touche, int P_X, int P_Y)
    {
      if (P_Touche == 27) FG.LeaveMainLoop();

      if (P_Touche == 122 || P_Touche == 90) Monde.Deplace_Balle(0, 1);

      if (P_Touche == 115 || P_Touche == 83) Monde.Deplace_Balle(0, -1);

      if (P_Touche == 100 || P_Touche == 68) Monde.Deplace_Balle(1, 0);

      if (P_Touche == 113 || P_Touche == 81) Monde.Deplace_Balle(-1, 0);

      if (P_Touche == 78 || P_Touche == 110) Monde.Change_Param_Son();

      if (P_Touche == 109 || P_Touche == 77) Monde.Change_Param_Pos_Souris();

      //if (P_Touche == 'Y') Monde.Save("DataGame.json");

      //if (P_Touche == 'T') Monde.Charge("DataGame.json");






      //fortement recommandé
      FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }

    //======================================================================
    // cette fonction est invoquée par OpenGl lorsqu'on relache une touche normale (A,Z,E, ...)
    // P_Touche contient le code de la touche, P_X et P_Y contiennent les coordonnées de la souris quand on relache sur une touche
    static void Gestion_Clavier_Relache(byte P_Touche, int P_X, int P_Y)
    {


      // FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }

    //==================================================================================
    // cette fonction est invoquée par OpenGl lorsqu'on appuie sur un bouton de la souris
    // P_Bouton contient le code du bouton (gauche ou droite), P_Etat son etat, les coordonnées de la souris quand on appuie sur un bouton sont dans P_X et P_Y

    static void Gestion_Bouton_Souris(int P_Bouton, int P_Etat, int P_X, int P_Y)
    {

      //fortement recommandé
      FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }

    //====================================================================
    // cette fonction est invoquée par OpenGl lorsqu'on tourne la molette de la souris
    // P_Molette contient le code de la molette, P_Sens son sens de rotation, les coordonnées de la souris quand on tourne la molette sont dans P_X et P_Y

    static void Gestion_Molette(int P_Molette, int P_Sens, int P_X, int P_Y)
    {
      if (P_Sens == 1) Monde.Change_Param_Qualite(false, true);
      if (P_Sens == -1) Monde.Change_Param_Qualite(true, false);

      //  FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }

    //====================================================================
    // cette fonction est invoquée par OpenGl lorsqu'on bouge la souris sans appuyer sur un bouton
    // les coordonnées de la souris ont dans P_X et P_Y
    static void Gestion_Souris_Libre(int P_X, int P_Y)
    {
      Monde.Get_Pos_Souris(P_X, P_Y);

      // FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }


    //====================================================================
    // cette fonction est invoquée par OpenGl lorsqu'on bouge la souris tout en appuyant sur un bouton
    // les coordonnées de la souris ont dans P_X et P_Y
    static void Gestion_Souris_Clique(int P_X, int P_Y)
    {

      // FG.PostRedisplay(); // Pour demander de réafficher une Frame afin de tenir compte des modifications
    }
  }
}