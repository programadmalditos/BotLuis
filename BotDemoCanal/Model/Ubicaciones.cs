using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotDemoCanal.Extension;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BotDemoCanal.Model
{
    [Serializable]
    public class Ubicaciones:BaseModel
    {
        public string Descripcion { get; set; }
        
        public Ubicaciones() { }

        public Ubicaciones(string nombre, string foto, string descripcion)
        {
            Nombre = nombre;
            Foto = foto.Image2Base64();
            Descripcion = descripcion;
        }

      
        public override Attachment ToAttachment(IDialogContext context)
        {
            HeroCard hc = new HeroCard()
            {
                Title = Nombre,
                Text = Descripcion,
                Images = new List<CardImage>()
        {
            new CardImage()
            {

                Url =   Foto
            }
        }
            };

            return hc.ToAttachment();
        }

    }
}