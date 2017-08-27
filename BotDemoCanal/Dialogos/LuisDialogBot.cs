using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotDemoCanal.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace BotDemoCanal.Dialogos
{
    [Serializable]
    public class LuisDialogBot:LuisDialog<object>
    {
        public LuisDialogBot(LuisService service) : base(service)
        {
            
        }

        [LuisIntent("")]
        public async Task NoneAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"Lo siento, no te he entendido '{result.Query}'");
            await context.PostAsync("Que quieres saber?");
            context.Wait(MessageReceived);
        }

        private async Task ManageDefaultResponse(IEnumerable<BaseModel> data, IDialogContext context, string msg)
        {
            await context.PostAsync(msg);
            await context.PostAsync("Tenemos estos");
            var mensaje = BaseModel.ToMessage(data, context);
            await context.PostAsync(mensaje);


        }

        [LuisIntent("Personajes")]
        // We define the function we want to execute
        public async Task PersonajesAsync(IDialogContext context, LuisResult result)
        {

            EntityRecommendation nombreEntRec;
            if (result.TryFindEntity("Per", out nombreEntRec))
            {
                var personaje = FakeData.Personajes.ContainsKey(nombreEntRec.Entity.ToLower()) ? FakeData.Personajes[nombreEntRec.Entity.ToLower()] : null;
                if (personaje != null)
                {
                    await context.PostAsync(personaje.ToMessage(context));
                }
                else
                {
                    await ManageDefaultResponse(FakeData.Ubicaciones.Values.ToList(), context,
                            $"Personaje no encontrado {result.Query}");
                }



            }
            else
            {
                await ManageDefaultResponse(FakeData.Ubicaciones.Values.ToList(), context,
                            $"Personaje no encontrado {result.Query}");
            }



            context.Wait(MessageReceived);
        }

        [LuisIntent("Lugar")]
        // We define the function we want to execute
        public async Task LugaressAsync(IDialogContext context, LuisResult result)
        {

            EntityRecommendation nombreEntRec;
            if (result.TryFindEntity("Lugares", out nombreEntRec))
            {
                if (nombreEntRec.Resolution.Any())
                {
                    var fin = nombreEntRec.Resolution.First().Value as List<object>;

                    if (fin == null || !fin.Any() || !FakeData.Ubicaciones.ContainsKey(fin.First().ToString()))
                    {
                        await ManageDefaultResponse(FakeData.Ubicaciones.Values.ToList(), context,
                            $"Lugar no encontrado {result.Query}");
                    }

                    else
                    {
                        var model = FakeData.Ubicaciones[fin.First().ToString()];
                        await context.PostAsync(model.ToMessage(context));
                    }

                }
                else
                {
                    await ManageDefaultResponse(FakeData.Ubicaciones.Values.ToList(), context,
                            $"Lugar no encontrado {result.Query}");
                }


            }
            else
            {
                await ManageDefaultResponse(FakeData.Ubicaciones.Values.ToList(), context,
                            $"Lugar no encontrado {result.Query}");
            }



            context.Wait(MessageReceived);
        }
    }
}