using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGLDotNet;
using System.Media;

using Newtonsoft.Json;
using System.IO;

namespace BASE_OPEN_GL
{
   public class C_CARTE
   {
      public int Taille_Carte_X;
      public int Taille_Carte_Y;
      public int[,] Ma_Carte;


      public C_CARTE(int P_Taille_Carte_X, int P_Taille_Carte_Y)
      {
         Ma_Carte = new int[P_Taille_Carte_X, P_Taille_Carte_Y];
         Taille_Carte_X = P_Taille_Carte_X;
         Taille_Carte_Y = P_Taille_Carte_Y;
      }


      Random Generateur = new Random();

      C_DECOR Decor = new C_DECOR();
      C_PERSONNAGE Personnage = new C_PERSONNAGE();
      C_CONSOMMABLE Consommable = new C_CONSOMMABLE();
      C_SUPER_COMSOMMABLE Super_Consommable = new C_SUPER_COMSOMMABLE();
      C_MUR Mur = new C_MUR();

      //............................

      public void Change_Param_Qualite(bool P_Qualite_Plus, bool P_Qualite_Moins)
      {
         Decor.Change_Param_Qualite(P_Qualite_Plus, P_Qualite_Moins);
      }

      public int[] Return_Pos_Souris()
      {
         return Decor.Return_Pos_Souris();
      }

      public void Get_Pos_Souris(int P_Souris_X, int P_Souris_Y)
      {
         Decor.Get_Pos_Souris(P_Souris_X, P_Souris_Y);
      }

      public void Change_Param_Pos_Souris()
      {
         Decor.Change_Param_Pos_Souris();
      }

      public string Return_Param_Pos_Souris()
      {
         return Decor.Return_Param_Pos_Souris();
      }

      public string Return_Etat_Son()
      {
         return Decor.Return_Etat_Son();
      }

      public int Return_Score()
      {
         return Decor.Return_Score();
      }

      public int Return_Qualite_Decor()
      {
         return Decor.Return_Qualite();
      }

      public string Return_Description_Qualite()
      {
         return Decor.Return_Description_Qualite();
      }

      public void Change_Paramettre_Son()
      {
         if (Decor.Son == true) {
            Decor.Son = false;
         } else {
            Decor.Son = true;
         }
      }

      public void Initialise_Limite()
      {
         Ma_Carte[Personnage.Position_X, Personnage.Position_Y] = Personnage.Code;
         for (int Index = 0; Index < Taille_Carte_X; Index++) {
            Ma_Carte[Index, 0] = Mur.Code;
            Ma_Carte[Index, Taille_Carte_Y - 1] = Mur.Code;
            Ma_Carte[0, Index] = Mur.Code;
            Ma_Carte[Taille_Carte_X - 1, Index] = Mur.Code;
         }
      }

      public void Initialise_Murs_Random()
      {
         for (int Compteur = 0; Compteur < Mur.Nombre; Compteur++) {
            Mur.X = 1 + Generateur.Next() % (Taille_Carte_X - 2);
            Mur.Y = Generateur.Next() % (Taille_Carte_Y - 2) + 1;

            if (Ma_Carte[Mur.X, Mur.Y] == 0) {
               Ma_Carte[Mur.X, Mur.Y] = Mur.Code;
            }
         }
      }

      public void Innitialise_Consommables()
      {
         Innitialise_Super_Consommables();
         for (int Compteur = 0; Compteur < Consommable.Nombre; Compteur++) {
            Consommable.X = 1 + Generateur.Next() % (Taille_Carte_X - 2);
            Consommable.Y = Generateur.Next() % (Taille_Carte_Y - 2) + 1;

            if (Ma_Carte[Consommable.X, Consommable.Y] == 0) {
               Ma_Carte[Consommable.X, Consommable.Y] = Consommable.Code;
            }
         }
      }

      public void Innitialise_Super_Consommables()
      {
         for (int Compteur = 0; Compteur < Super_Consommable.Nombre; Compteur++) {
            Super_Consommable.X = 1 + Generateur.Next() % (Taille_Carte_X - 2);
            Super_Consommable.Y = Generateur.Next() % (Taille_Carte_Y - 2) + 1;

            if (Ma_Carte[Super_Consommable.X, Super_Consommable.Y] == 0) {
               Ma_Carte[Super_Consommable.X, Super_Consommable.Y] = Super_Consommable.Code;
            }
         }
      }

      public void Ajoute_Consommable_Random()
      {
         int RDM_Super_Consommable = Generateur.Next() % (7 + 1);
         int NB_Consommable = Generateur.Next() % (4 + 1);
         for (int Compteur = 0; Compteur < NB_Consommable; Compteur++) {
            Consommable.X = 1 + Generateur.Next() % (Taille_Carte_X - 2);
            Consommable.Y = Generateur.Next() % (Taille_Carte_Y - 2) + 1;
            if (Ma_Carte[Consommable.X, Consommable.Y] == 0) {
               if (RDM_Super_Consommable == 1) {
                  Ma_Carte[Consommable.X, Consommable.Y] = Super_Consommable.Code;
               } else {
                  Ma_Carte[Consommable.X, Consommable.Y] = Consommable.Code;
               }
            }
         }
      }

      public void Deplacer_Balle(int P_Direction_X, int P_Direction_Y)
      {
         Personnage.Direction_X = P_Direction_X;
         Personnage.Direction_Y = P_Direction_Y;
         int Prochaine_Case_X = Personnage.Position_X + Personnage.Direction_X;
         int Prochaine_Case_Y = Personnage.Position_Y + Personnage.Direction_Y;
         if (Prochaine_Case_X < Taille_Carte_X && Prochaine_Case_X > 0 && Prochaine_Case_Y < Taille_Carte_Y && Prochaine_Case_Y > 0) {
            int Ma_Carte_Prochaine_Case = Ma_Carte[Prochaine_Case_X, Prochaine_Case_Y];
            if (Ma_Carte_Prochaine_Case == 0) {
               Personnage.Deplacement();
               Ma_Carte[Personnage.Position_X, Personnage.Position_Y] = Personnage.Code;
               Ma_Carte[Personnage.Precedente_Position_Personnage_X, Personnage.Precedente_Position_Personnage_Y] = 0;
            }
            if (Ma_Carte_Prochaine_Case != Mur.Code) {
               if (Ma_Carte_Prochaine_Case == Consommable.Code) {
                  Personnage.Deplacement();
                  Ma_Carte[Personnage.Position_X, Personnage.Position_Y] = Personnage.Code;
                  Ma_Carte[Personnage.Precedente_Position_Personnage_X, Personnage.Precedente_Position_Personnage_Y] = 0;
                  Decor.Score += 1;
                  if (Decor.Son == true) {
                     Task.Run(() => Console.Beep(200, 50));
                  }
                  Ajoute_Consommable_Random();
               }
               if (Ma_Carte_Prochaine_Case == Super_Consommable.Code) {
                  Personnage.Deplacement();
                  Decor.Score += 5;
                  Ma_Carte[Personnage.Position_X, Personnage.Position_Y] = Personnage.Code;
                  Ma_Carte[Personnage.Precedente_Position_Personnage_X, Personnage.Precedente_Position_Personnage_Y] = 0;
                  if (Decor.Son == true) {
                     Task.Run(() => Console.Beep(400, 50));
                  }
                  Ajoute_Consommable_Random();
               }
            } else {
               Personnage.Direction_Y = 0;
               Personnage.Direction_X = 0;
            }
         } else {
            Personnage.Direction_Y = 0;
            Personnage.Direction_X = 0;
         }
      }

      public void Afficher()
      {
         for (int Index_X = 0; Index_X < Taille_Carte_X; Index_X++) {

            for (int Index_Y = 0; Index_Y < Taille_Carte_Y; Index_Y++) {
               GL.PushMatrix();
               GL.Translated(Index_X, Index_Y, 0);
               switch (Ma_Carte[Index_X, Index_Y]) {
                  case 0: break;
                  case 1: Mur.Afficher(Decor.Qualite); break;
                  case 2: Personnage.Afficher(Decor.Qualite); break;
                  case 3: Consommable.Afficher(Decor.Qualite); break;
                  case 4: Super_Consommable.Afficher(Decor.Qualite); break;
               }

               GL.PopMatrix();
            }
         }
         GL.PushMatrix();
         GL.Translated(27.9, -0.35, 0);
         //Decor.Afficher();
         GL.PopMatrix();

         GL.PushMatrix();
         GL.Translated(27.9, 1.65, 0);
         //Decor.Afficher();
         GL.PopMatrix();
      }

      public void Sauvegarde(string P_Nom)
      {
         var Ma_Liste = new List<List<int>>();
         for (int Index_Y = 0; Index_Y < Taille_Carte_X; Index_Y++) {
            var Colonne_X = new List<int>();
            for (int Index_X = 0; Index_X < Taille_Carte_Y; Index_X++) {
               Colonne_X.Add(Ma_Carte[Index_Y, Index_X]);
            }
            Ma_Liste.Add(Colonne_X);
         }
         string Data_Json = JsonConvert.SerializeObject(Ma_Liste);
         File.WriteAllText(P_Nom, Data_Json);
      }

      public void Charge(string P_Nom)
      {
         //Ma_Carte = null;
         try {
            string Data_Json = File.ReadAllText(P_Nom);


            var Ma_Liste = new List<List<int>>();
            Ma_Liste = JsonConvert.DeserializeObject<List<List<int>>>(Data_Json);

            int Lignes = Ma_Liste.Count;
            int Colonnes = Ma_Liste[0].Count;

            for (int Index_Y = 0; Index_Y < 20; Index_Y++) {
               for (int Index_X = 0; Index_X < 20; Index_X++) {
                  Ma_Carte[Index_Y, Index_X] = Ma_Liste[Index_Y][Index_X];
               }
            }
         } catch (Exception Message) {
            Console.WriteLine(Message);
         }
      }
   }
}