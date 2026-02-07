using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE_OPEN_GL
{
   internal class C_CONFIGURATION_JEU
   {
      [JsonProperty("TailleCarteX")]
      public int Taille_Carte_X;

      [JsonProperty("TailleCarteY")]
      public int Taille_Carte_Y;
   }
}
